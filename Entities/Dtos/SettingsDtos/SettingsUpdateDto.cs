using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.SettingsDtos
{
    public class SettingsUpdateDto :SettingsDto
    {
        [Key]
        public Guid SettingsGuidId { get; set; }
    }
}
