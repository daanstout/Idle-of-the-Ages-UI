using Godot;
using IdleOfTheAgesLib.Translation;
using IdleOfTheAgesRuntime;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace IdleOfTheAges;

public partial class Application : Node {
    private App app;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        app = new App();

        Assembly selfAssembly = Assembly.GetExecutingAssembly();

        app.Initialize(selfAssembly);

        var result = app.LoadMods(ProjectSettings.GlobalizePath("res://Resources/Mods"), AssemblyLoadContext.GetLoadContext(selfAssembly));

        if (!result) {
            GD.Print($"Errors while loading mods (count = {result.Errors.Count()})");
            foreach (var error in result.Errors) {
                GD.Print(error.Message);
            }
        } else {
            GD.Print("No errors while loading mods");
        }

        app.GameLoaded();

        app.ServiceLibrary.Get<ITranslationService>().ChangeLanguage(Languages.EN_US);
    }
}
