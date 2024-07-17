using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserDtos
{
    public class UserUpdateDto: UserDto
    {
        [Key]
        public Guid UserGuidId { get; set; }

    }
}
