using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
