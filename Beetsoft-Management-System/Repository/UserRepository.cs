using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Interface;

namespace Beetsoft_Management_System.Repository
{
    

    public class UserRepository : IUserRepository
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<(byte[] Data, string FileType, string FileName)> GetPhoto(string id)
        {
            var file = context.User.Where(u => u.Id == id).FirstOrDefault();
            var path = Path.Combine(AppDirectory, file?.ImagePath);

            var memory = new MemoryStream();
            using(var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            var contentType = $"image/{file.ImageExtension}";
            var fileName = Path.GetFileName(path);

            return(memory.ToArray(), contentType, fileName);
        }
    }
}