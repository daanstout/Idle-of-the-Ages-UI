using Godot;
using IdleOfTheAgesLib;
using System;

namespace IdleOfTheAges.Scripts.Services;

[Service<ILogger>(Key = "Godot Console")]
public class ConsoleLogger : ILogger {
    public string Namespace { get; } = "Godot UI";

    public ConsoleLogger() { }

    public void Error(string message, params object[] objects) => GD.PrintErr(string.Format("({0}) [{1}] - {2}", DateTime.UtcNow, Namespace, string.Format(message, objects)));
    public void Info(string message, params object[] objects) => GD.Print(string.Format("({0}) [{1}] - {2}", DateTime.UtcNow, Namespace, string.Format(message, objects)));
    public void Warning(string message, params object[] objects) => GD.Print(string.Format("({0}) [{1}] - {2}", DateTime.UtcNow, Namespace, string.Format(message, objects)));
    public void LogResult(Result result) {
        if (result) {
            GD.Print("The result was succesful");
        } else {
            GD.Print($"The result was unsuccesful! Encountered {result.Errors} issues");
            foreach(var error in result.Errors) {
                GD.Print($"\t{error.Message}");
            }
        }
    }
    public void LogResult<T>(Result<T> result) {
        if (result) {
            GD.Print("The result was succesful");
        } else {
            GD.Print($"The result was unsuccesful! Encountered {result.Errors} issues");
            foreach (var error in result.Errors) {
                GD.Print($"\t{error.Message}");
            }
        }
    }
}
