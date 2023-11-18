using UnityEngine;

namespace IdleOfTheAges {
    internal class Logger : IdleOfTheAgesLib.ILogger {
        public string Namespace { get; }

        public Logger(string @namespace) {
            Namespace = @namespace;
        }

        public void Error(string message, params object[] objects) {
            Debug.LogErrorFormat("[{0}] {1}", Namespace, string.Format(message, objects));
        }

        public void Info(string message, params object[] objects) {
            Debug.LogFormat("[{0}] {1}", Namespace, string.Format(message, objects));
        }

        public void Warn(string message, params object[] objects) {
            Debug.LogWarningFormat("[{0}] {1}", Namespace, string.Format(message, objects));
        }
    }
}
