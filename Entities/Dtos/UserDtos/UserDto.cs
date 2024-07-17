using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.UserDtos
{
    public class UserDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string ImageByteString { get; set; }

    }
}
