using System.Text;

namespace GameEngineProject.Libraries.AutoDocumentation
{
    /// <summary>
    /// Base class for holding documentation info for AutoDocumentation
    /// </summary>
    public class DocTypeInfo
    {
        public Type type;
        public string relativePathToDocs;
        public string originalFilePath;
        public List<DocsMember> members = new();
        public DocTypeInfo(Type type, string relativePathToDocs, string originalFilePath)
        {
            this.type = type;
            this.relativePathToDocs = relativePathToDocs;
            this.originalFilePath = originalFilePath;
        }

        public string ToHTML(List<DocTypeInfo> types, string RootWebsite)
        {
            Console.WriteLine(relativePathToDocs);
            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine($"<title>{type.Name}</title>");

            int parentFolders = relativePathToDocs.Replace('\\', '/').Split('/').Length - 1;

            html.AppendLine($"<link rel='stylesheet' type='text/css' href='{string.Concat(Enumerable.Repeat("../", parentFolders)) + "style.css"}'>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            // Create a sidebar
            html.AppendLine("<div class='sidebar'>");
            html.AppendLine("<h2>Documentation</h2>");

            // Add links to different sections or classes in your documentation
            html.AppendLine("<ul>");
            foreach(var type in types)
            html.AppendLine($"<li><a href='{RootWebsite}{type.relativePathToDocs.Replace(".md",".html").Replace('\\','/')}'>{type.type.Name}</a></li>");
            html.AppendLine("</ul>");
            html.AppendLine("</div>");

            // Create a content area
            html.AppendLine("<div class='content'>");

            html.AppendLine($"<h1>{type.Name}</h1>");

            // Type Information
            // Include your type information here
            html.AppendLine("</section>");

            // Members
            html.AppendLine("<section id='members'>");
            html.AppendLine("<h3>Members</h2>");
            foreach(var member in members) html.AppendLine(member.ToHTML());

            html.AppendLine("</section>");

            html.AppendLine("</div>");  // Close content div
            html.AppendLine("</body>");
            html.AppendLine("</html>");
            return html.ToString(); 
        }
    }

}
