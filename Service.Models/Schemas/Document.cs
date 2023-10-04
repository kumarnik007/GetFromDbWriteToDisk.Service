using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Models.Schemas
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        [Required]
        public required string Type { get; set; }
        [Required]
        public required byte[] Data { get; set; }
    }
}
