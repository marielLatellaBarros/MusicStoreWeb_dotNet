namespace MusicStore.Web.Services
{
    public interface IFileProvider
    {
        byte[] GetBytes(string relativePath);
    }
}
