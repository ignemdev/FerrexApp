namespace Ferrex.Core.Handlers
{
    public interface IImageHandler
    {
        public string ImageName { get; }
        public string ImageExtension { get; set; }
        void CopyImage(params string[] pathParts);
        void CopyImage(string name, bool withGuid, params string[] pathParts);
        void DeleteImage(params string[] pathParts);
    }
}
