using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business.Services.Validation
{
    public class ServiceMessages
    {
        public static string TallyCountHourNegative = "Başlangıç saati bitiş saatinden önce olamaz.";
        public static string WorkTimeWeekend = "Haftasonunda çalışamazsınız.";
        public static string IsWorkTimeFirst = "Başlangıç saatiniz çalışma saatleri dışında.";
        public static string IsWorkTimeFinish = "Son tarih çalışma saatleri dışında.";
        public static string IsFirstDayHolidayTime = "Başlangıç tarihi tatil gününde.";
        public static string IsFinishDayHolidayTime = "Bitiş tarihi tatil gününde.";
        public static string MonthHourExceed = "Aylık çalışma sürenizi aşıyorsunuz.";
        public static string IsSameMonth = "Başlangıç veya bitiş saatiniz aynı ayda değil.";
        public static string IsSameWeek = "Başlangıç veya bitiş saatiniz aynı haftada değil.";
        public static string WeekHourExceed = "Haftalık çalışma sürenizi aşıyorsunuz.";
        public static string IsSyllabusOverlap = "Ders saatinde çalışamazsınız.";
    }
}
