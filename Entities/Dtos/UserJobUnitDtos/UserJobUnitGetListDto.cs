using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserJobUnitDtos
{
    public class UserJobUnitGetListDto
    {
        public Guid UserJobUnitGuidId { get; set; }
        public Guid UserGuidId { get; set; }
        public Guid JobUnitGuidId { get; set; }
    }
}
