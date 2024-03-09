using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(0,20)]
        public int DisplayOrder { get; set; }
    }
}
