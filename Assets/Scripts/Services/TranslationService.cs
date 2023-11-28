using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Translation;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IdleOfTheAges.Translation {
    [Service(typeof(ITranslationService), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class TranslationService : ITranslationService {
        public Language CurrentLanguage { get; private set; }

        public event Action<Language> LanguageChangedEvent;

        private readonly Dictionary<Language, HashSet<string>> languagePaths = new();
        private readonly Dictionary<string, string> translations = new();

        public TranslationService() {
            foreach (var language in Enum.GetValues(typeof(Language)).Cast<Language>()) {
                languagePaths[language] = new HashSet<string>();
            }
        }

        public Result ChangeLanguage(Language language) {
            if (language == CurrentLanguage) {
                return true;
            }

            CurrentLanguage = language;

            LoadLanguage(CurrentLanguage);

            return true;
        }

        public Result<string> GetLanguageString(string key) {
            return translations[key];
        }

        public Result LoadLanguagePath(Language language, string path) {
            languagePaths[language].Add(path);

            if(language == CurrentLanguage) {
                LoadFile(path);
            }

            return true;
        }

        private void LoadLanguage(Language language) {
            translations.Clear();

            foreach (var file in languagePaths[language]) {
                LoadFile(file);
            }
        }

        private void LoadFile(string path) {
            var contents = File.ReadAllLines(path);

            foreach(var line in contents) {
                var split = line.Split('=');
                if (!translations.ContainsKey(split[0])) {
                    translations[split[0]] = split[1];
                }
            }
        }
    }
}
