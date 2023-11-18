using IdleOfTheAges.Data;
using IdleOfTheAges.DependencyInjection;
using IdleOfTheAges.Services;
using IdleOfTheAges.Services.UI;

using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Data;
using IdleOfTheAgesLib.DependencyInjection;
using IdleOfTheAgesLib.Services;
using IdleOfTheAgesLib.Services.UI;

using Newtonsoft.Json;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using UnityEngine;

namespace IdleOfTheAges {
    /// <summary>
    /// Main application class of the runtime.
    /// </summary>
    public class Application : MonoBehaviour {
        private ServiceLibrary mainServiceLibrary;
        private ServiceLibrary publicServiceLibrary;
        private ElementLibrary mainElementLibrary;
        private IModLibrary modLibrary;

        private void Start() {
            mainServiceLibrary = new ServiceLibrary(null);
            mainServiceLibrary.Bind<IServiceLibrary>().ToInstance(mainServiceLibrary);
            publicServiceLibrary = new ServiceLibrary(mainServiceLibrary);
            publicServiceLibrary.Bind<IServiceLibrary>().ToInstance(publicServiceLibrary);

            RegisterServices(Assembly.GetExecutingAssembly(), mainServiceLibrary, publicServiceLibrary);

            mainElementLibrary = new ElementLibrary(null, mainServiceLibrary, mainServiceLibrary.Get<IUIService>());
            mainServiceLibrary.Bind<IElementLibrary>().ToInstance(mainElementLibrary);
            RegisterUI(Assembly.GetExecutingAssembly(), mainElementLibrary);

            modLibrary = mainServiceLibrary.Get<IModLibrary>();

            var modDirectories = Directory.GetDirectories(Path.Combine(UnityEngine.Application.streamingAssetsPath, "Mods"));

            foreach (var modFolder in modDirectories) {
                LoadMod(modFolder);
            }

            mainServiceLibrary.Get<ITranslationService>().ChangeLanguage(Language.en_US);

            mainServiceLibrary.Get<IPrefabSpawner>().SpawnPrefab("UIRoot");
        }

        private void LoadMod(string path) {
            var manifest = JsonConvert.DeserializeObject<ModManifest>(File.ReadAllText(Path.Combine(path, "Manifest.json")));

            if (manifest == null) {
                return;
            }

            var assembly = Assembly.LoadFrom(Path.Combine(path, $"{manifest.Namespace}.dll"));

            var modClass = assembly.GetType($"{manifest.Namespace}.{manifest.ModClass}");

            if (modClass == null) {
                return;
            }

            var modServiceLibrary = new ServiceLibrary(publicServiceLibrary);
            var modElementLibrary = new ElementLibrary(mainElementLibrary, modServiceLibrary, mainServiceLibrary.Get<IUIService>());

            modServiceLibrary.Bind<IServiceLibrary>().ToInstance(modServiceLibrary);
            modServiceLibrary.Bind<IElementLibrary>().ToInstance(modElementLibrary);

            ModObject modObject = new ModObject {
                Namespace = manifest.Namespace,
                Mod = (IMod)Activator.CreateInstance(modClass),
                Logger = new Logger(manifest.Namespace),
                ServiceLibrary = modServiceLibrary,
                ServiceRegistry = modServiceLibrary
            };

            modLibrary.RegisterMod(manifest.Namespace, modObject);

            modObject.Init();
            RegisterModSpecificServices(modObject.ServiceRegistry);
            RegisterServices(assembly, publicServiceLibrary, modObject.ServiceRegistry);
            RegisterUI(assembly, modElementLibrary);
            modObject.Mod.RegisterPublicServices(publicServiceLibrary);
            modObject.Mod.RegisterServices(modServiceLibrary);
            modObject.Mod.ModLoaded(modObject.ServiceLibrary);
            modObject.Mod.AppLoaded(modObject.ServiceLibrary);
            modObject.Mod.GameLoaded(modObject.ServiceLibrary);
            RegisterSkills(assembly, mainServiceLibrary.Get<ISkillService>());
        }

        private void RegisterModSpecificServices(IServiceRegistry serviceRegistry) {
            serviceRegistry.RegisterService<IDataLoader, DataLoader>(null);
        }

        private void RegisterUI(Assembly assembly, IElementLibrary elementLibrary) {
            foreach (var type in assembly.GetTypes()) {
                var attrib = type.GetCustomAttribute<UIElementAttribute>();

                if (attrib == null)
                    continue;

                elementLibrary.RegisterElement(type, attrib.Identifier);
            }
        }

        private void RegisterServices(Assembly assembly, IServiceRegistry publicServiceRegistry, IServiceRegistry modServiceRegistry) {
            foreach (var type in assembly.GetTypes()) {
                var serviceAttribute = type.GetCustomAttribute<ServiceAttribute>();

                if (serviceAttribute == null) {
                    continue;
                }

                var targetRegistry = serviceAttribute.ServiceLevel == ServiceAttribute.ServiceLevelEnum.Public ? publicServiceRegistry : modServiceRegistry;

                targetRegistry.RegisterService(serviceAttribute.InterfaceType, type, serviceAttribute.Key);
            }
        }

        private void RegisterSkills(Assembly assembly, ISkillService skillService) {
            foreach (var type in assembly.GetTypes()) {
                var skillAttribute = type.GetCustomAttribute<SkillAttribute>();

                if (skillAttribute == null) {
                    continue;
                }

                skillService.RegisterSkillImplementation(type, skillAttribute.SkillID);
            }
        }
    }
}
