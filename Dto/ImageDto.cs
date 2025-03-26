using System.Text.Json.Serialization;

namespace server.Dto
{
    public class ImageDtoRes
    {
        private string _imageUrl;

        public ImageDtoRes(string imageUrl = "")
        {
            _imageUrl = imageUrl;
        }

        public int Id { get; set; }
        public string ImageUrl
        {
            get { return Path.Combine("image", _imageUrl ?? string.Empty); }
        }
    }
}