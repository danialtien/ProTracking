using System.ComponentModel.DataAnnotations;

namespace ProTracking.Domain.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? QRCode  { get; set; }
        public string? AccessKey { get; set; }
        public string? PrivateKey { get; set; }
    }
}
