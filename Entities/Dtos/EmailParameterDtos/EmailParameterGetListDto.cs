using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.EmailParameterDtos
{
    public class EmailParameterGetListDto
    {
        public Guid EmailParameterGuidId { get; set; }
        public string Smtp { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}
