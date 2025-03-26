using server.Entities;
using server.Interface.Repository;
using server.Interface.Service;

namespace server.Service
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment environment;
        private readonly IImageRepository imageRepository;
        private readonly S3Service _s3Service;

        public ImageService(IWebHostEnvironment environment, IImageRepository imageRepository, S3Service s3Service)
        {
            this.environment = environment;
            this.imageRepository = imageRepository;
            _s3Service = s3Service;
        }
        public async Task DeleteImageAsync(int Id)
        {
            Image? image = await imageRepository.GetByIdAsync(Id);
            if (image == null) throw new ArgumentNullException($"No Image found with id {Id}");
            var contentPath = environment.ContentRootPath;
            var imagePath = Path.Combine(contentPath, "Uploads");
            var fileNameWithPath = Path.Combine(imagePath, image.Url);

            if (File.Exists(fileNameWithPath))
            {
                File.Delete(fileNameWithPath);
            }
            await imageRepository.DeleteAsync(image);
        }

        public async Task<Image> SaveImageAsync(IFormFile file)
        {
            if (file == null) throw new ArgumentNullException("File is empty");

            //var contentPath = environment.ContentRootPath;
            //var imagePath = Path.Combine(contentPath, "Uploads");

            //if (!Directory.Exists(imagePath))
            //{
            //    Directory.CreateDirectory(imagePath);
            //}

            //var fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
            //var fileNameWithPath = Path.Combine(imagePath, fileName);

            //using var fileStream = new FileStream(fileNameWithPath, FileMode.Create);
            //await file.CopyToAsync(fileStream);
            string imageUrl = await _s3Service.UploadFileAsync(file);

            Image image = new Image()
            {
                Url = imageUrl,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = 1,
                IsDeleted = false
            };

            return await imageRepository.AddAsync(image);
        }
    }
}