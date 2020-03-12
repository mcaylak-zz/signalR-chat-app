using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Contants
{
    public static class Messages
    {
        public static string Added = "Ekleme işlemi başarılı";
        public static string Deleted = "Silme işlemi başarılı";
        public static string Updated = "Update işlemi başarılı";

        public static string ProductAdded = "Ürün başarıyla eklendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";
        public static string UserNotFound = "Kullanici bulunamadi";
        public static string PasswordError = "Hatalı Parola";
        public static string SuccessLogin = "Sisteme Giris Basarili";
        public static string AlreadyExists = "Zaten mevcut";
        public static string UserRegistered = "Kullanici basariyla kayit edildi";
        public static string AccessTokenCreated = "Access Token Basariyla Olusturuldu";
    }
}
