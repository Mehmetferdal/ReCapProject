using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constains
{
    public static class Messages
    {
        public static string Added = "Eklendi";
        public static string Updated = "Güncellendi";
        public static string Deleted = "Silindi";
        public static string NameInvalid = "İsim Geçersiz en az 2 karekterden oluşmalı";
        public static string MaintenanceTime = "Araçlar Kullanımda Değil";
        public static string Listed = "Listelenme Gerçekleşti";
        public static string Alert = "İşlem Başarısız";
        public static string Limit = "Limit Aşıldı Lütfen Veritabanınız Kontrol Ediniz?";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
    }
}
