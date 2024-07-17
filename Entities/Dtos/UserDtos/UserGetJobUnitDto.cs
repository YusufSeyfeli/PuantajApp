using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserDtos
{
    public class UserGetJobUnitDto
    {
        public Guid UserGuidId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
    }
}
