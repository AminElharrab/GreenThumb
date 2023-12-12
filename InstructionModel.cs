using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.models
{
    public class InstructionModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int PlantId { get; set; }
        public Plantmodel Plant { get; set; } = null!;
    }
}
