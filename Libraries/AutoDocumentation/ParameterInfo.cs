namespace GameEngineProject.Libraries.AutoDocumentation
{
    /// <summary>
    /// Base class for holding data about parameters for automatic documentation
    /// </summary>

    public class ParameterInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Type Type { get; set; }
        public string LinkPath { get; set; }

        public ParameterInfo(string name, Type type, string linkPath = "", string description = "No description.")
        {
            Name = name;
            Description = description;
            Type = type;
            LinkPath = linkPath;
        }
    }

}
