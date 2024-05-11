using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace F19FKP_HFT_2023242.Models
{
    internal class Repair
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RepairId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        public double Cost { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Car Car { get; set; }

        
    }
}
