namespace Beetsoft_Management_System.Interface
{
    public interface IUserRepository
    {
        Task<(byte[] Data, string FileType, string FileName)> GetPhoto(string id);
    }
}