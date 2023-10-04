using System.ComponentModel.DataAnnotations;

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
        [Required]
        public int HistoryNo { get; set; }
        public DateTime? ExportDateTime { get; set; }
        [Required]
        public bool Processed { get; set; }
        public byte[]? ProcessedData { get; set; }
        public string? ProcessedFilename { get; set; }
        public string? ProcessedFiletype { get; set; }
        public string? ProcessedFreetext { get; set; }
    }
}
