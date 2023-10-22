using System.Text;

namespace GameEngineProject.Libraries.AutoDocumentation
{
    /// <summary>
    /// Base class for holding elements for automatic documentation
    /// </summary>
    public class DocsMember
    {
        public string Title { get; set; }
        public Type ReturnType { get; set; }
        public string Summary { get; set; } = "";
        public string Signature { get; set; }
        public List<ParameterInfo> Parameters { get; set; } = new();
        public enum DocType { Field, Property, Method }
        public DocType type = DocType.Field;
        public string BasicSignature = "";

        public string HTMLHighlightKeywords(string text)
        {
            string str = " " + text;
            Dictionary<string, string> keywordHighlights = new Dictionary<string, string>()
            {
                {" public ", " <span class='code-keyword'>public</span> " },
                {" private ", " <span class='code-keyword'>private</span> " },
                {" static ", " <span class='code-keyword'>static</span> " },
                {" get ", " <span class='code-keyword'>get</span> " },
                {" set ", " <span class='code-keyword'>set</span> " },
                {" virtual ", " <span class='code-keyword'>virtual</span> " },
                {" override ", " <span class='code-keyword'>override</span> " },
                {" void ", " <span class='code-keyword'>void</span> " },
                {" int ", " <span class='code-keyword'>int</span> " },
                {" Public ", " <span class='code-keyword'>public</span> " },
                {" Private ", " <span class='code-keyword'>private</span> " },
                {" Static ", " <span class='code-keyword'>static</span> " },
                {" Get ", " <span class='code-keyword'>get</span> " },
                {" Set ", " <span class='code-keyword'>set</span> " },
                {" Virtual ", " <span class='code-keyword'>virtual</span> " },
                {" Override ", " <span class='code-keyword'>override</span> " },
                {" Void ", " <span class='code-keyword'>void</span> " },
                {" Int ", " <span class='code-keyword'>int</span> " },
            };
            foreach (var kvp in keywordHighlights)
            {
                str = str.Replace(kvp.Key, kvp.Value);
            }

            str = str.Replace(Title, $"<span class='code-method'>{Title}</span>");
            str = str.Replace(ReturnType.Name, $"<span class='code-type'>{ReturnType.Name}</span>");

            return str;
        }

        public string ToHTML()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<div class='member'>"); 
            html.Append($"<h2><memberType>{type}</memberType> {Title}</h3>");
            html.AppendLine($"<p>{Summary}</p>");
            html.AppendLine($"<pre><code>{HTMLHighlightKeywords(Signature)}</code></pre>");

            if (Parameters.Count > 0)
            {
                html.AppendLine("<h3>Parameters</h3>");
                html.AppendLine("<table>");
                html.AppendLine("<tr>\r\n            <th>Parameter Name</th>\r\n            <th>Type</th>\r\n            <th>Description</th>\r\n        </tr>");
                foreach (var param in Parameters)
                {
                    html.AppendLine($"<tr>\r\n<td>{param.Name}</td>\r\n<td>{param.Type.Name}</td>\r\n<td>{param.Description}</td>\r\n</tr>");
                }
                html.AppendLine("</table>");
            }
            html.AppendLine("</div>");
            return html.ToString();
        }
        public override string ToString()
        {
            return ToMarkdown();
        }

        private string ToMarkdown()
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
