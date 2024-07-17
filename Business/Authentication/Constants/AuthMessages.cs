using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Authentication.Constants
{
    public class AuthMessages
    {
        public static string Added = "Yetki başarıyla oluşturuldu";
        public static string Updated = "Yetki başarıyla güncellendi";
        public static string Deleted = "Yetki başarıyla silindi";
        public static string NameIsNotAvaible = "Bu yetki adı daha önce kullanılmış";
        public static string BulkUpdatead = "Bulk update yapıldı";
        public static string IsEmailorPasswordIncorrect = "Kullanıcı maili ya da şifre bilgisi yanlış.";
        public static string IsEmailNotFound = "Kullanıcı maili sistemde bulunamadı!";
        public static string IsEmailAlreadyUse = "Bu mail adresi daha önce kullanılmış";
        public static string IsImageOneByte = "Yüklediğiniz resmi boyutu en fazla 1mb olmalıdır";
        public static string IsImageJpeg = "Eklediğiniz resim .jpg, .jpeg, .gif, .png türlerinden biri olmalıdır!";
    }
}
