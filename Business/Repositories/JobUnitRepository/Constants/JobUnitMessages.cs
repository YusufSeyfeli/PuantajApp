using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.JobUnitRepository.Constants
{
    public class JobUnitMessages
    {
        public static string Added = "İş Bölümü başarıyla oluşturuldu";
        public static string Updated = "İş Bölümü başarıyla güncellendi";
        public static string Deleted = "İş Bölümü başarıyla silindi";
        public static string NameIsNotAvaible = "Bu iş bölümü adı daha önce kullanılmış";
        public static string JobDepartmentIdIsNotAvaible = "Böyle bir departman bulunmuyor";
        public static string CannotConvertGuidId = "Böyle bir departman bulunmuyor";


    }
}
