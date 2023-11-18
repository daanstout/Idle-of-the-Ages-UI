using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Data;
using IdleOfTheAgesLib.Models.ModJsonData;
using IdleOfTheAgesLib.Services;
using IdleOfTheAgesLib.Services.UI;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IdleOfTheAges.Services {
    public class DataLoader : IDataLoader {
        private static readonly JsonSerializerSettings settings = new() {
            ContractResolver = new DefaultContractResolver {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        private readonly IModObject modObject;
        private readonly IAgeService ageService;
        private readonly ISkillService skillService;
        private readonly ITextureLibrary textureLibrary;
        private readonly ITranslationService translationService;

        public DataLoader(IModObject modObject, IAgeService ageService, ISkillService skillService, ITextureLibrary textureLibrary, ITranslationService translationService) {
            this.modObject = modObject;
            this.ageService = ageService;
            this.skillService = skillService;
            this.textureLibrary = textureLibrary;
            this.translationService = translationService;
        }

        public Result LoadData(params string[] pathSegments) {
            var path = Path.Combine(UnityEngine.Application.streamingAssetsPath, "Mods", modObject.Namespace, Path.Combine(pathSegments));

            if (!File.Exists(path)) {
                return (false, $"File does not exist: {path}");
            }

            var json = File.ReadAllText(path);

            ModData data;
            try {
                data = JsonConvert.DeserializeObject<ModData>(json, settings);
            } catch (Exception e) {
                return (false, $"Error parsing the json for file at path: {path}", e);
            }

            foreach (var age in data.Ages) {
                age.Namespace = data.Namespace;
                ageService.RegisterAge(age);
            }

            foreach(var skill in data.Skills) {
                skill.Namespace = data.Namespace;
                skillService.RegisterSkillData(skill);
            }

            return true;
        }

        public Result LoadLanguages(params string[] pathSegments) {
            var path = Path.Combine(UnityEngine.Application.streamingAssetsPath, "Mods", modObject.Namespace, Path.Combine(pathSegments));

            if (!Directory.Exists(path)) {
                return (false, "Directory does not exist");
            }

            List<string> failedFiles = new List<string>();

            foreach (var file in Directory.GetFiles(path)) {
                if (Enum.TryParse<Language>(Path.GetFileNameWithoutExtension(file), true, out var language)) {
                    translationService.LoadLanguagePath(language, file);
                } else {
                    failedFiles.Add(Path.GetFileName(path));
                }
            }

            if (failedFiles.Count > 0) {
                return (false, $"Failed loading {failedFiles.Count} files!{failedFiles.Aggregate(string.Empty, (acc, str) => Environment.NewLine + acc + str)}");
            } else {
                return true;
            }
        }

        public Result RegisterTextures(params string[] pathSegments) {
            var rootPath = Path.Combine(UnityEngine.Application.streamingAssetsPath, "Mods", modObject.Namespace, Path.Combine(pathSegments));

            if (!Directory.Exists(rootPath)) {
                return (false, "Directory does not exist");
            }

            Queue<string> Directories = new Queue<string>();
            Directories.Enqueue(rootPath);

            while (Directories.Count > 0) {
                var directory = Directories.Dequeue();

                foreach (var subFolder in Directory.GetDirectories(directory)) {
                    Directories.Enqueue(subFolder);
                }

                foreach (var filePath in Directory.GetFiles(directory)) {
                    var fileExtension = Path.GetExtension(filePath);

                    if (fileExtension != ".png" && fileExtension != ".jpg") {
                        continue;
                    }

                    textureLibrary.RegisterTextures($"{modObject.Namespace}:{Path.GetFileNameWithoutExtension(filePath)}", filePath);
                }
            }

            return true;
        }
    }
}
