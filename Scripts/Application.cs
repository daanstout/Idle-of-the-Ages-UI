using Godot;
using HtmlAgilityPack;
using IdleOfTheAgesLib.IO;
using IdleOfTheAgesLib.Translation;
using IdleOfTheAgesLib.UI.Services;
using IdleOfTheAgesLib.UI.Templates;
using IdleOfTheAgesRuntime;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace IdleOfTheAges;

public partial class Application : Node {
    [Export]
    private Panel uiRoot;

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

        app.ServiceLibrary.Get<ICssLibrary>().LoadCSS();

        app.GameLoaded();

        app.ServiceLibrary.Get<ITranslationService>().ChangeLanguage(Languages.EN_US);
        var contents = app.ServiceLibrary.Get<IFileLoader>().GetFileContents(".html", "IdleOfTheAgesCore:root");
        if (!contents) {
            GD.PrintErr("Could not load root UI!");
            return;
        }
        var rootResult = app.ServiceLibrary.Get<ITemplateLibrary>().GetTemplate("IdleOfTheAgesCore:root");
        if (!rootResult) {
            GD.PrintErr("Could not load root UI Template");
            return;
        }
        var root = rootResult.Value;
        GD.Print(root.HtmlDocument.DocumentNode.OuterHtml);
        CreateUI(root, uiRoot);
    }

    private static void CreateUI(Template root, Panel uiRoot) {
        Queue<(HtmlNode htmlNode, Node uiNode)> nodes = [];

        foreach(var child in root.HtmlDocument.DocumentNode.ChildNodes) {
            nodes.Enqueue((child, uiRoot));
        }

        do {
            var (htmlNode, uiNode) = nodes.Dequeue();

            var newNode = ProcessHtmlNode(htmlNode, uiNode);

            foreach(var child in htmlNode.ChildNodes) {
                nodes.Enqueue((child, newNode));
            }
        } while (nodes.Count > 0);
    }

    private static Node ProcessHtmlNode(HtmlNode node, Node parent) {
        var newNode = CreateNode(node);
        parent.AddChild(newNode);
        return newNode;
    }

    private static Node CreateNode(HtmlNode node) {
        return node.Name switch {
            "div" => CreateDiv(node),
            "#text" => CreateText(node),
            _ => CreateDiv(node)
        };
    }

    private static Panel CreateDiv(HtmlNode node) {
        return new Panel {
            Size = new Vector2 {
                X = 10,
                Y = 10
            }
        };
    }

    private static Label CreateText(HtmlNode node) {
        return new Label {
            Text = node.InnerHtml
        };
    }
}
