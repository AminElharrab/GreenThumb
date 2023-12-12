using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.models
{
    public class Plantmodel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<InstructionModel> Instructions { get; set; } = new();


    }
}
