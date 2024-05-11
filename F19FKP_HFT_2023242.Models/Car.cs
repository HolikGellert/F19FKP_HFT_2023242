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
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Repair> Repairs { get; set; }

        public Car()
        {
            this.Repairs = new HashSet<Repair>();
        }
    }
}