using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnc2.Com.Virtual
{
    public class Enums
    {
        public enum BannerPosition
        {
            Top = 1,
            Right = 2,
            Bottom = 3,
            Left = 4
        }

        public enum CatalogOrderFilters
        {
            [Display(Name = "Tarihe Göre Sıralama")]
            TariheGoreSiralama = 1,
            [Display(Name = "Puana Göre Sıralama")]
            PuanaGoreSiralama = 2,
            [Display(Name = "Alfabetik Sıralama (A-Z)")]
            AlfabetikSiralamaAZ = 3,
            [Display(Name = "Alfabetik Sıralama (Z-A)")]
            AlfabetikSiralamaZA = 4
        }

        public enum Cities
        {
            [Display(Name = "Adana")]
            Adana = 1,
            [Display(Name = "Adıyaman")]
            Adiyaman = 2,
            [Display(Name = "Afyon")]
            Afyon = 3,
            [Display(Name = "Ağrı")]
            Agri = 4,
            [Display(Name = "Amasya")]
            Amasya = 5,
            [Display(Name = "Ankara")]
            Ankara = 6,
            [Display(Name = "Antalya")]
            Antalya = 7,
            [Display(Name = "Artvin")]
            Artvin = 8,
            [Display(Name = "Aydın")]
            Aydin = 9,
            [Display(Name = "Balıkesir")]
            Balikesir = 10,
            [Display(Name = "Bilecik")]
            Bilecik = 11,
            [Display(Name = "Bingöl")]
            Bingol = 12,
            [Display(Name = "Bitlis")]
            Bitlis = 13,
            [Display(Name = "Bolu")]
            Bolu = 14,
            [Display(Name = "Burdur")]
            Burdur = 15,
            [Display(Name = "Bursa")]
            Bursa = 16,
            [Display(Name = "Çanakkale")]
            Canakkale = 17,
            [Display(Name = "Çankırı")]
            Cankiri = 18,
            [Display(Name = "Çorum")]
            Corum = 19,
            [Display(Name = "Denizli")]
            Denizli = 20,
            [Display(Name = "Diyarbakır")]
            Diyarbakir = 21,
            [Display(Name = "Edirne")]
            Edirne = 22,
            [Display(Name = "Elazığ")]
            Elazig = 23,
            [Display(Name = "Erzincan")]
            Erzincan = 24,
            [Display(Name = "Erzurum")]
            Erzurum = 25,
            [Display(Name = "Eskişehir")]
            Eskisehir = 26,
            [Display(Name = "Gaziantep")]
            Gaziantep = 27,
            [Display(Name = "Giresun")]
            Giresun = 28,
            [Display(Name = "Gümüşhane")]
            Gumushane = 29,
            [Display(Name = "Hakkari")]
            Hakkari = 30,
            [Display(Name = "Hatay")]
            Hatay = 31,
            [Display(Name = "Isparta")]
            Isparta = 32,
            [Display(Name = "İçel")]
            Icel = 33,
            [Display(Name = "İstanbul")]
            Istanbul = 34,
            [Display(Name = "İzmir")]
            İzmir = 35,
            [Display(Name = "Kars")]
            Kars = 36,
            [Display(Name = "Kastamonu")]
            Kastamonu = 37,
            [Display(Name = "Kayseri")]
            Kayseri = 38,
            [Display(Name = "Kırklareli")]
            Kirklareli = 39,
            [Display(Name = "Kırşehir")]
            Kirsehir = 40,
            [Display(Name = "Kocaeli")]
            Kocaeli = 41,
            [Display(Name = "Konya")]
            Konya = 42,
            [Display(Name = "Kütahya")]
            Kutahya = 43,
            [Display(Name = "Malatya")]
            Malatya = 44,
            [Display(Name = "Manisa")]
            Manisa = 45,
            [Display(Name = "Kahramanmaraş")]
            Kahramanmaras = 46,
            [Display(Name = "Mardin")]
            Mardin = 47,
            [Display(Name = "Muğla")]
            Mugla = 48,
            [Display(Name = "Muş")]
            Mus = 49,
            [Display(Name = "Nevşehir")]
            Nevsehir = 50,
            [Display(Name = "Niğde")]
            Nigde = 51,
            [Display(Name = "Ordu")]
            Ordu = 52,
            [Display(Name = "Rize")]
            Rize = 53,
            [Display(Name = "Sakarya")]
            Sakarya = 54,
            [Display(Name = "Samsun")]
            Samsun = 55,
            [Display(Name = "Siirt")]
            Siirt = 56,
            [Display(Name = "Sinop")]
            Sinop = 57,
            [Display(Name = "Sivas")]
            Sivas = 58,
            [Display(Name = "Tekirdağ")]
            Tekirdag = 59,
            [Display(Name = "Tokat")]
            Tokat = 60,
            [Display(Name = "Trabzon")]
            Trabzon = 61,
            [Display(Name = "Tunceli")]
            Tunceli = 62,
            [Display(Name = "Şanlıurfa")]
            Sanliurfa = 63,
            [Display(Name = "Uşak")]
            Usak = 64,
            [Display(Name = "Van")]
            Van = 65,
            [Display(Name = "Yozgat")]
            Yozgat = 66,
            [Display(Name = "Zonguldak")]
            Zonguldak = 67,
            [Display(Name = "Aksaray")]
            Aksaray = 68,
            [Display(Name = "Bayburt")]
            Bayburt = 69,
            [Display(Name = "Karaman")]
            Karaman = 70,
            [Display(Name = "Kırıkkale")]
            Kırıkkale = 71,
            [Display(Name = "Batman")]
            Batman = 72,
            [Display(Name = "Şırnak")]
            Sirnak = 73,
            [Display(Name = "Bartın")]
            Bartın = 74,
            [Display(Name = "Ardahan")]
            Ardahan = 75,
            [Display(Name = "Iğdır")]
            Igdir = 76,
            [Display(Name = "Yalova")]
            Yalova = 77,
            [Display(Name = "Karabük")]
            Karabuk = 78,
            [Display(Name = "Kilis")]
            Kilis = 79,
            [Display(Name = "Osmaniye")]
            Osmaniye = 80,
            [Display(Name = "Düzce")]
            Düzce = 81
        }

        public enum Genders
        {
            [Display(Name = "Erkek")]
            Erkek = 1,

            [Display(Name = "Kadın")]
            Kadin = 2
        }

        public enum ImageSizeNaming
        {
            Original = 0,
            Default = 1,
            Preview = 2
        }

        public enum ImageSizes
        {
            None = 0,

            AdminUser_Default_W = 200,

            Preview_W = 50,
            Preview_H = 50,

            Offer_Default_W = 60,
            Offer_Default_H = 60
        }

        public enum AdminModulGroup
        {
            IcerikYonetimi = 1,
            AdminKullaniciYonetimi = 2,
            ParametreYonetimi = 11,
            LogYonetimi = 19,

            ContentManagement = 6,
            Admin = 7,
            Parameter = 14,
            Log = 21
        }

    }
}
