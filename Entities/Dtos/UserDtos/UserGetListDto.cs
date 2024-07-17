using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.Dtos.JobUnitDtos;
using Entities.Dtos.OperationClaimDtos;

namespace Entities.Dtos.UserDtos
{
    public class UserGetListDto
    {
        public Guid UserGuidId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string ImageByte { get; set; }
        public List<JobUnitDto> jobUnitDtos { get; set; }
        public List<OperationClaimGetUserDto> operationClaimGetListDtos { get; set; }

    }
}
