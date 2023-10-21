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
        public DocTypeInfo(Type type, string relativePathToDocs, string originalFilePath)
        {
            this.type = type;
            this.relativePathToDocs = relativePathToDocs;
            this.originalFilePath = originalFilePath;
        }
    }

}
