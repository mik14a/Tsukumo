using System;
using Newtonsoft.Json.Linq;

namespace Tsukumo.ComfyUI.Models
{
    public class Workflow
    {
        public Workflow(JObject graph) {
            Graph = graph ?? throw new ArgumentNullException(nameof(graph));
        }

        public static Workflow FromJson(string json) {
            return new Workflow(JObject.Parse(json));
        }

        public JObject Graph { get; }

        public Workflow SetText(string nodeId, JToken text) {
            SetInput(nodeId, "text", text);
            return this;
        }

        public Workflow SetSize(string nodeId, JToken width, JToken height) {
            SetInput(nodeId, "width", width);
            SetInput(nodeId, "height", height);
            return this;
        }

        public Workflow Replace(string placeholder, string value) {
            foreach (var property in Graph.Properties()) {
                if (property.Value is JObject node && node["inputs"] is JObject inputs)
                    Walk(inputs);
            }
            return this;

            void Walk(JToken token) {
                switch (token.Type) {
                case JTokenType.Object:
                    foreach (var child in ((JObject)token).Properties())
                        Walk(child.Value);
                    break;
                case JTokenType.Array:
                    foreach (var item in (JArray)token)
                        Walk(item);
                    break;
                case JTokenType.String:
                    var text = (string)token;
                    if (text.Contains(placeholder))
                        ((JValue)token).Value = text.Replace(placeholder, value);
                    break;
                }
            }
        }

        Workflow SetInput(string nodeId, string inputName, JToken value) {
            if (Graph[nodeId] is not JObject node) throw new InvalidOperationException($"Node '{nodeId}' not found.");
            if (node["inputs"] is not JObject inputs) throw new InvalidOperationException($"Node '{nodeId}' has no inputs.");
            inputs[inputName] = value;
            return this;
        }
    }
}
