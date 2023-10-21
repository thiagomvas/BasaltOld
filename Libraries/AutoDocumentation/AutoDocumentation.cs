using GameEngineProject.Source.Components;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GameEngineProject.Libraries.AutoDocumentation
{

    public static class AutoDocumentation
    {
        public static string GithubPagesLink;
        public static string DocsRootDirectory;
        public static string SourceNamespace;
        public static string SourceDirectory;

        private static List<DocTypeInfo> typesFound = new();

        /// <summary>
        /// Generates markdown documentation for every single class in the SourceDirectory. Do keep in mind this replaces the files, so any modifications made by you will be lost.
        /// </summary>
        public static void GenerateAutoDocumentation()
        {
            typesFound.Clear();
            ReflectFolders(SourceDirectory);
            FetchAllTypes(SourceDirectory, "");

            foreach(DocTypeInfo type in typesFound)
            {
                string documentation = "# " + type.type.Name + "\n";
                string text = File.ReadAllText(type.originalFilePath);
                var members = ClassDoc(type.type, typesFound);
                var lines = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
             
                foreach (var member in members)
                {
                    ExtractSummary(lines, member);

                    //Extract Param Description
                    ExtractParamDescriptions(lines, member);

                    documentation += member;

                }
                WriteTextToFile(documentation, Path.Combine(DocsRootDirectory, type.relativePathToDocs));
            }
            
        }

        private static void ExtractParamDescriptions(string[] lines, DocsMember member)
        {
            int lineIndex = 0;
            foreach (var line in lines)
            {
                if (line.ToLower().Replace(" ", "").Contains(member.Signature.ToLower().Replace(" ", "")))
                {
                    lineIndex = Array.IndexOf(lines, line);
                    break;
                }
            }

            foreach (var param in member.Parameters)
            {
                for (int i = lineIndex; i > 0; i--)
                {
                    if (lines[i].Contains("<summary>")) break;
                    else if (lines[i].Contains($"<param name=\"{param.Name}\">"))
                    {
                        string desc = lines[i].Replace($"<param name=\"{param.Name}\">", "").Replace("</param>", "").Replace("///", "").TrimStart();
                        param.Description = desc;
                    }
                }
            }
        }

        private static void ExtractSummary(string[] lines, DocsMember member)
        {
            int lineIndex = 0;
            int x = 0;
            foreach (var line in lines)
            {
                if (line.ToLower().Replace(" ", "").Contains(member.Signature.ToLower().Replace(" ", "")))
                {
                    lineIndex = Array.IndexOf(lines, line);
                    break;
                }
                else if (member.type == DocsMember.DocType.Property && line.ToLower().Replace(" ", "").Contains(member.BasicSignature.ToLower().Replace(" ", "")))
                {
                    lineIndex = Array.IndexOf(lines, line);
                    break;
                }
            }
            List<string> summaryLines = new();
            bool insideSummary = false;
            for (int i = lineIndex; i > 0; i--)
            {
                if (lines[i].Contains("<summary>")) break;
                else if (insideSummary) summaryLines.Add(lines[i]);
                else if (lines[i].Contains("</summary>")) insideSummary = true;
            }

            summaryLines.Reverse();



            if (summaryLines.Count > 0)
            {
                var summary = summaryLines.Aggregate((a, b) => a + b).Replace("///", "").TrimStart();
                member.Summary = summary;
            }
        }

        private static void ReflectFolders(string directoryPath, string currentPath = "")
        {
            string[] subdirectories = Directory.GetDirectories(directoryPath);
            foreach (string subdirectory in subdirectories)
            {
                string subdirectoryName = Path.GetFileName(subdirectory);

                // Skip specific folders (e.g., "obj", "bin", ".vs")
                if (!ShouldSkipFolder(subdirectoryName))
                {
                    var path = Path.Combine(DocsRootDirectory, Path.Combine(currentPath,subdirectoryName));
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    ReflectFolders(subdirectory, Path.Combine(currentPath, subdirectoryName));
                }
            }
        }

        private static void FetchAllTypes(string directoryPath, string currentPath)
        {
            try
            {
                // Process files in the current directory
                string[] files = Directory.GetFiles(directoryPath);
                foreach (string file in files)
                {
                    if (file.Substring(file.IndexOf('.') + 1) != "cs") continue;
                    string fileName = Path.GetFileName(file.Substring(0, file.IndexOf('.')));
                    string path = Path.Combine(new string[] { Path.GetFileName(DocsRootDirectory), currentPath, $"{fileName}.md" });



                    Type type = Type.GetType($"{SourceNamespace}.{currentPath.Replace('\\', '.')}.{fileName}");
                    if (type != null)
                    {
                        typesFound.Add(new(type, path, file));
                    }

                }

                // Recursively process subdirectories
                string[] subdirectories = Directory.GetDirectories(directoryPath);
                foreach (string subdirectory in subdirectories)
                {
                    string subdirectoryName = Path.GetFileName(subdirectory);

                    // Skip specific folders (e.g., "obj", "bin", ".vs")
                    if (!ShouldSkipFolder(subdirectoryName))
                    {
                        var path = Path.Combine(DocsRootDirectory, Path.Combine(currentPath, subdirectoryName));
                        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                        FetchAllTypes(subdirectory, Path.Combine(currentPath, subdirectoryName));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }

            typesFound = typesFound.GroupBy(x => x.type).Select(y => y.First()).OrderBy(e => e.type.Name).ToList();
        }

        // Method to determine whether to skip a folder
        private static bool ShouldSkipFolder(string folderName)
        {
            string[] foldersToSkip = { "obj", "bin", ".vs", ".git", "docs" }; // Add more folder names as needed

            foreach (string folderToSkip in foldersToSkip)
            {
                if (string.Equals(folderName, folderToSkip))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<DocsMember> ClassDoc(Type type, List<DocTypeInfo> typesToLink)
        {
            List<DocsMember> members = new();
            // Get all fields
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                if (field.Name.Contains("k__BackingField")) continue;
                DocsMember doc = new();
                doc.Title = $"{field.Name}";

                StringBuilder sig = new();
                if (field.IsPublic) sig.Append("public ");
                if (field.IsPrivate) sig.Append("private ");
                if (field.IsStatic) sig.Append("static ");
                sig.Append($"{FormatTypes(field.FieldType.Name)} ");
                sig.Append(field.Name);
                doc.Signature = sig.ToString();
                members.Add(doc);
            }

            // Get all properties
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {
                DocsMember doc = new();
                doc.type = DocsMember.DocType.Property;
                doc.Title = property.Name;

                var getMethod = property.GetGetMethod();
                var setMethod = property.GetSetMethod();
                if (getMethod != null)
                {
                    string getText = $"{(getMethod.IsPublic ? "public" : "private")} get;";
                    string setText = $"{(setMethod != null ? (setMethod.IsPublic ? "public " : "private ") : "")}set;";
                    doc.Signature = $"{(getMethod.IsPublic ? "public" : "private")} {property.PropertyType.Name} {property.Name} {{ {getText} {setText} }}";
                    doc.BasicSignature = $"{(getMethod.IsPublic ? "public" : "private")} {FormatTypes(property.PropertyType.Name)} {property.Name}";
                }
                members.Add(doc);

            }

            // Get all methods
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                if (BlacklistedMethod(method)) continue;
                DocsMember doc = new();
                doc.type = DocsMember.DocType.Method;
                doc.Title = method.Name;
                StringBuilder sig = new();
                if (method.IsPublic) sig.Append("public ");
                if (method.IsPrivate) sig.Append("private ");
                if (method.IsStatic) sig.Append("static ");
                if (method.IsVirtual && method.GetBaseDefinition() == method && !type.IsAbstract) sig.Append("virtual ");
                if (method.IsVirtual && method.GetBaseDefinition() == method && type.IsAbstract) sig.Append("abstract ");
                if (method.GetBaseDefinition() != method) sig.Append("override ");
                sig.Append($"{FormatTypes(method.ReturnType.Name)} ");
                sig.Append($"{method.Name}(");
          
                var parameters = method.GetParameters();
                foreach (var param in parameters)
                {
                    sig.Append($"{FormatTypes(param.ParameterType.Name)} {param.Name}, ");
                }
                string text = sig.ToString();
                if (parameters.Length > 0) text = text.Substring(0, text.Length - 2);
                text += ")";

                doc.Signature = text;

                foreach (var param in method.GetParameters())
                {
                    string link = string.Empty;
                    foreach (var t in typesToLink)
                    {
                        if (t.type == param.ParameterType)
                        {
                            link = Path.Combine(GithubPagesLink, t.relativePathToDocs.Split("docs\\")[0].Replace('\\', '/').Replace(".md", ".html"));
                            break;
                        }

                    }
                    doc.Parameters.Add(new(param.Name, param.ParameterType, link));
                }
                members.Add(doc);
            }
            return members;
        }

        private static bool BlacklistedMethod(MethodInfo method)
        {
            string[] blacklist = new string[] { "get_", "set_", "add_", "remove_" };
            foreach (string black in blacklist) if(method.Name.Contains(black)) return true;
            return false;
        }
        public static bool IsNullable<T>(T? t) where T : struct { return true; }

        private static string FormatTypes(string text)
        {
            Dictionary<string, string> typeConversions = new()
            {
                {"Single", "float" },
                {"Boolean", "bool"},
                {"String", "string" },
                {"Void", "void" },
                {"Int32", "int" },     
                {"Int64", "long" },    
                {"Decimal", "decimal"},
                {"Char", "char"},
                {"EventHandler`1", "EventHandler" },
                {"Action", "event Action" } //Bandaid Fix for getting event actions

            };

            if (typeConversions.ContainsKey(text)) return typeConversions[text];
            else return text;
        }


        static void WriteTextToFile(string text, string fileName)
        {
            string filePath = Path.Combine(DocsRootDirectory, fileName);
            try
            {
                // Write the text to the specified file.
                File.WriteAllText(filePath, text);

                Console.WriteLine($"Text successfully written to the file: {fileName}");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }

}
