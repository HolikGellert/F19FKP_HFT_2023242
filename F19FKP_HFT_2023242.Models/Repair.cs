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
    public class Repair
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RepairId { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Car Car { get; set; }
    }
}
