namespace GameEngineProject.Libraries.AutoDocumentation
{
    /// <summary>
    /// Base class for holding documentation info for AutoDocumentation
    /// </summary>
    public class DocTypeInfo
    {
        public Type type;
        public string relativePathToDocs;
        public DocTypeInfo(Type type, string relativePathToDocs)
        {
            this.type = type;
            this.relativePathToDocs = relativePathToDocs;
        }
    }

}
