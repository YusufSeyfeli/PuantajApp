using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.CompetencyDtos
{
    public  class CompetencyUpdateDto :CompetencyDto
    {
        [Key]
        public Guid CompetencyGuidId { get; set; }
    }
}
