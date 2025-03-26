using Amazon.S3.Model;
using Amazon.S3;
using Amazon;
using Microsoft.AspNetCore.Routing;
using Amazon.Runtime;

namespace server.Service;

public class S3Service
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;

    public S3Service(IConfiguration configuration)
    {

        //var credentials = FallbackCredentialsFactory.GetCredentials();
        //_s3Client = new AmazonS3Client(credentials, RegionEndpoint.GetBySystemName(configuration["AWS:Region"])); // Change region as needed
        _s3Client = new AmazonS3Client(
          configuration["AWS:AccessKey"],
          configuration["AWS:SecretKey"],
          RegionEndpoint.GetBySystemName(configuration["AWS:Region"])
      );

        _bucketName = configuration["AWS:BucketName"];
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is empty");

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = $"mitonlineimages/{fileName}";
        using var stream = file.OpenReadStream();

        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = filePath,
            InputStream = stream,
            ContentType = file.ContentType,
            CannedACL = S3CannedACL.PublicRead // Make the file public
        };

        await _s3Client.PutObjectAsync(request);

        return $"https://{_bucketName}.s3.amazonaws.com/{filePath}";
    }
}
