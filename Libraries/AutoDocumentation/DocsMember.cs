using System.Text;

namespace GameEngineProject.Libraries.AutoDocumentation
{
    /// <summary>
    /// Base class for holding elements for automatic documentation
    /// </summary>
    public class DocsMember
    {
        public string Title { get; set; }
        public string Summary { get; set; } = "";
        public string Signature { get; set; }
        public List<ParameterInfo> Parameters { get; set; } = new();
        public enum DocType { Field, Property, Method }
        public DocType type = DocType.Field;


        public override string ToString()
        {
            StringBuilder doc = new();
            doc.AppendLine();
            doc.AppendLine($"## `{type}` {Title}");
            doc.AppendLine(Summary);
            doc.AppendLine("```csharp");
            doc.AppendLine(Signature);
            doc.AppendLine("```");

            if (Parameters.Count > 0)
            {
                doc.AppendLine("### Parameters");
                doc.AppendLine("");
                doc.AppendLine("| Parameter Name | Type | Description |");
                doc.AppendLine("| --------- | --------- | --------- |");
            }
            foreach (ParameterInfo param in Parameters)
            {
                doc.AppendLine($"| {param.Name} | {(!string.IsNullOrWhiteSpace(param.LinkPath) ? $"[{param.Type.Name}]({param.LinkPath})" : param.Type.Name)} | {param.Description} |");
            }

            doc.AppendLine();
            return doc.ToString();
        }

    }

}
