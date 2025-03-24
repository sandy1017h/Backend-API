using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace server.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
        [JsonIgnore]
        public Brand Brand { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
