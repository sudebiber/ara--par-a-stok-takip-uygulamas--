using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Net.NetworkInformation;

public class Kullanıcı
{
    //KAPSÜLLEME
    string kullaniciAdi;
    string sifre;

    public string Kullaniciadi
    {
        get { return kullaniciAdi; }
        set
        {
            if (value == null)
            {
                Console.WriteLine("Kullanıcı adınınızı giriniz!");
            }
            else
            {
                kullaniciAdi = value;
            }
        }
    }
    public string Sİfre
    {
        get { return sifre; }
        set
        {
            if (value == null)
            {
                Console.WriteLine("Şifreyi giriniz!");
            }
            else
            {
                sifre = value;
            }
        }
    }
    public static string GetHiddenPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine(); // Enter tuşuna basıldığında yeni satıra geç

        return password;
    }

}
//ABSTRACT SINIF => SOYUTLAMA
public abstract class AracParca //ana class
{
    public string ParcaId { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 6);
    public string ParcaTuru { get; set; }
    public int StokAdeti { get; set; }

    public abstract void ParcaBilgileriGoster();

}
//KALITIM
public class Far : AracParca
{
    public string FarTuru { get; set; }

    public override void ParcaBilgileriGoster() //OVERRİDE => AŞIRI YÜKLEME
    {
        Console.WriteLine("Parça Id : {0} Far Aydınlatma Turu : {1}, Stokta {2} adet var", ParcaId, FarTuru, StokAdeti);
    }
    public static void ParcaTanimla(List<AracParca> parcalar, string farTuru, int stokAdeti)
    {
        parcalar.Add(new Far { ParcaTuru = "Far", FarTuru = farTuru, StokAdeti = stokAdeti });
    }


}

public class Lastik : AracParca
{
    public string Lastik_Mevsimi { get; set; }
    public int JantCapi { get; set; }
    public int KesitOranı { get; set; }
    public override void ParcaBilgileriGoster()
    {
        Console.WriteLine("Parça Id : {0} Lastik Mevsimi : {1}, Jant Çapı : {2}, Kesit Oranı : {3} Stokta {4} adet var ", ParcaId, Lastik_Mevsimi, JantCapi, KesitOranı, StokAdeti);
    }
    public static void ParcaTanimla(List<AracParca> parcalar, string mevsim, int jantCapi, int kesitOrani, int stokAdeti)
    {
        parcalar.Add(new Lastik { ParcaTuru = "Lastik", JantCapi = jantCapi, KesitOranı = kesitOrani, Lastik_Mevsimi = mevsim, StokAdeti = stokAdeti });
    }


}

public class Motor : AracParca
{
    public string YakitTipineGöre { get; set; }
    public string YanmaYerineGöre { get; set; }
    public string SilindirlerineGöre { get; set; }
    public override void ParcaBilgileriGoster()
    {
        Console.WriteLine("Parça Id : {0}  Yakıt Tipine Göre Motor : {1}, Yanma Yerine Göre Motor : {2}, Silindirlerine Göre Motor : {3}, Stokta {4} adet var", ParcaId, YakitTipineGöre, YanmaYerineGöre, SilindirlerineGöre, StokAdeti);

    }
    public static void ParcaTanimla(List<AracParca> parcalar, string yakitTipi, string yanmaYeri, string silindir, int stokAdeti)
    {
        parcalar.Add(new Motor { ParcaTuru = "Motor", SilindirlerineGöre = silindir, YakitTipineGöre = yakitTipi, YanmaYerineGöre = yanmaYeri, StokAdeti = stokAdeti });
    }


}
public class Fren : AracParca
{
    public string FrenSistemiTuru { get; set; }
    public override void ParcaBilgileriGoster()
    {
        Console.WriteLine("Parça Id : {0} Fren Sistemi Türü : {1}, Stokta {2} adet var ", ParcaId, FrenSistemiTuru, StokAdeti);
    }
    public static void ParcaTanimla(List<AracParca> parcalar, string frenSistemiTuru, int stokAdeti)
    {
        parcalar.Add(new Fren { ParcaTuru = "Fren", FrenSistemiTuru = frenSistemiTuru, StokAdeti = stokAdeti });
    }


}
public class Sanziman : AracParca
{
    public string SanzımanTuru { get; set; }
    public override void ParcaBilgileriGoster()
    {
        Console.WriteLine("Parça Id : {0} Şanzıman Türü : {1} Stokta {2} adet var ,  ", ParcaId, SanzımanTuru, StokAdeti);
    }

    public static void ParcaTanimla(List<AracParca> parcalar, string sanzimanTuru, int stokAdeti)
    {
        parcalar.Add(new Sanziman { ParcaTuru = "Sanziman", SanzımanTuru = sanzimanTuru, StokAdeti = stokAdeti });
    }
}
public class StokTakip
{
    private List<AracParca> _parcalar;
    private List<Kullanıcı> _kullanicilar;
    private Kullanıcı _aktifKullanici;

    public StokTakip(List<AracParca> parcalar, List<Kullanıcı> kullanicilar)
    {
        _parcalar = parcalar;
        _kullanicilar = kullanicilar;
    }


    public void GirisYap(string kullaniciAdi, string Sifre)
    {
        _aktifKullanici = _kullanicilar.Find(k => k.Kullaniciadi == kullaniciAdi && k.Sİfre == Sifre);
        if (_aktifKullanici == null)
        {
            Console.WriteLine("Hatalı Giriş! Lütfen kullanıcı adı ve şifrenizi kontrol ediniz.");
        }
        else
        {
            Console.WriteLine($"Hoş Geldiniz {_aktifKullanici.Kullaniciadi} !");
        }

    }


    public void ParcaSil(string parcaId, int Miktar)
    {
        if (_aktifKullanici != null)
        {
            AracParca parca = _parcalar.Find(p => p.ParcaId == parcaId);
            if (parca != null)
            {
                if (parca.StokAdeti >= Miktar)
                {
                    Console.WriteLine("Parçayı silmek istediğinize emin misiniz? ");
                    string karar = Console.ReadLine().ToLower();
                    if (karar == "evet")
                    {
                        parca.StokAdeti -= Miktar;
                        Console.WriteLine($"{Miktar} adet {parca.ParcaTuru} parçası stoklardan çıkarıldı. Yeni stok miktarı : {parca.StokAdeti}");
                    }
                    else
                    {
                        Console.WriteLine($"Verdiğiniz karar algılanamadı. ");
                    }
                }
                else
                {
                    Console.WriteLine($"Stokta yeterli miktarda {parca.ParcaTuru} parçası bulunmamaktadır.");
                }
            }
        }
        else
        {
            Console.WriteLine("Önce giriş yapmalısınız.");
        }
    }
    public void ParcaEkle(string parcaId, int Miktar)
    {
        AracParca parca = _parcalar.Find(p => p.ParcaId == parcaId);
        if (_aktifKullanici != null)
        {
            if (parca != null)
            {
                parca.StokAdeti += Miktar;
                Console.WriteLine($"{Miktar} adet {parca.ParcaTuru} parçası stoklara eklendi. Yeni stok miktarı : {parca.StokAdeti}");
            }
            else
            {
                Console.WriteLine($"{parca.ParcaTuru} parçası bulunamadı.");
            }
        }
        else
        {
            Console.WriteLine("Önce giriş yapmalısınız.");
        }
    }



    public void StokDurumu()
    {
        foreach (var parca in _parcalar)
        {
            parca.ParcaBilgileriGoster();
        }
    }

    public void MenuGoster()
    {
        Console.WriteLine("Araç Parça Stok Takip Uygulaması");
        Console.WriteLine("\nMENU");
        Console.WriteLine("1-Kullanıcı Girişi");
        Console.WriteLine("2-Stok Detayları");
        Console.WriteLine("3-Stok Ekle");
        Console.WriteLine("4-Stok Sil");
        Console.WriteLine("5-Parca Tanimla");
        Console.WriteLine("6-Programdan Çıkış");
        Console.WriteLine("7-Konsolu Temizle");


    }

}

class Program
{
    static void Main(string[] args)
    {
        Far far = new Far()
        {
            ParcaTuru = "Far",
            StokAdeti = 50,
            FarTuru = "LED far"
        };


        Lastik lastik = new Lastik()
        {
            ParcaTuru = "Lastik",
            StokAdeti = 20,
            Lastik_Mevsimi = "Yaz",
            JantCapi = 19,
            KesitOranı = 60
        };

        Motor motor = new Motor()
        {
            ParcaTuru = "Motor",
            StokAdeti = 10,
            YakitTipineGöre = "Dizel",
            YanmaYerineGöre = "Dıştan Yanmalı",
            SilindirlerineGöre = "Tek silindirli"
        };

        Fren fren = new Fren()
        {
            ParcaTuru = "Fren",
            StokAdeti = 35,
            FrenSistemiTuru = "Hidrolik fren sistemi"
        };
        Sanziman sanziman = new Sanziman()
        {
            ParcaTuru = "Şanzıman",
            StokAdeti = 10,
            SanzımanTuru = "Manuel şanzıman"
        };
        Kullanıcı kullanıcı = new Kullanıcı()
        {
            Kullaniciadi = "yönetici",
            Sİfre = "1234"
        };
        Kullanıcı kullanıcı2 = new Kullanıcı()
        {
            Kullaniciadi = "çalışan",
            Sİfre = "9876"
        };
        var kullaniciListesi = new List<Kullanıcı>();
        kullaniciListesi.Add(kullanıcı);
        kullaniciListesi.Add(kullanıcı2);
        var parcaListesi = new List<AracParca>();
        parcaListesi.Add(far);
        parcaListesi.Add(lastik);
        parcaListesi.Add(motor);
        parcaListesi.Add(fren);
        parcaListesi.Add(sanziman);
        StokTakip stokTakip = new StokTakip(parcaListesi, kullaniciListesi);


        stokTakip.MenuGoster();

        while (true)
        {
            Console.WriteLine("Seçiminiz : ");
            if (int.TryParse(Console.ReadLine(), out int secim))
            {

                switch (secim)
                {
                    case 1:
                        {
                            Console.WriteLine("Kullanıcı adınızı giriniz (yönetici/çalışan) : ");
                            string KullaniciAdi = Console.ReadLine();
                            Console.WriteLine("Şifrenizi giriniz : ");
                            string Sifre = Kullanıcı.GetHiddenPassword();
                            stokTakip.GirisYap(KullaniciAdi, Sifre);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Stok Durumu :");
                            stokTakip.StokDurumu();
                        }
                        break;
                    case 3:
                        {
                            Console.Write("Eklenecek parçanın id bilgisini giriniz: ");
                            string parca = Console.ReadLine();
                            Console.Write("Eklenecek stok miktarını giriniz: ");
                            if (int.TryParse(Console.ReadLine(), out int Miktar))
                            {
                                stokTakip.ParcaEkle(parca, Miktar);
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz miktar girişi!");
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Silinecek parçanın id bilgisini giriniz: ");
                            string parca = Console.ReadLine();
                            Console.WriteLine("Silinecek stok miktarını giriniz: ");
                            if (int.TryParse(Console.ReadLine(), out int Miktar))
                            {
                                stokTakip.ParcaSil(parca, Miktar);
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz miktar girişi!");
                            }


                        }
                        break;

                    case 5:
                        {

                            Console.WriteLine("Hangi Parcayi Tanımlayacaksınız : ");
                            Console.WriteLine("1 - Far");
                            Console.WriteLine("2 - Lastik");
                            Console.WriteLine("3 - Motor");
                            Console.WriteLine("4 - Fren");
                            Console.WriteLine("5 - Sanziman");
                            var tanimSecim = int.Parse(Console.ReadLine());
                            Console.WriteLine("Stokta Kaç Adet Var : ");
                            var mevcutAdet = int.Parse(Console.ReadLine());
                            switch (tanimSecim)
                            {
                                case 1:
                                    Console.WriteLine("Far Türü : ");
                                    var farTuru = Console.ReadLine();
                                    Far.ParcaTanimla(parcaListesi, farTuru, mevcutAdet);
                                    Console.WriteLine("Parça Tanımlandı");
                                    break;
                                case 2:
                                    Console.WriteLine("Mevsim : ");
                                    var mevsim = Console.ReadLine();
                                    Console.WriteLine("Jant Capi : ");
                                    var jantCapi = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Kesit Orani : ");
                                    var kesitOrani = int.Parse(Console.ReadLine());
                                    Lastik.ParcaTanimla(parcaListesi, mevsim, jantCapi, kesitOrani, mevcutAdet);
                                    Console.WriteLine("Parça Tanımlandı");
                                    break;
                                case 3:
                                    Console.WriteLine("Yakıt tipi : ");
                                    var yakitTipi = Console.ReadLine();
                                    Console.WriteLine("Yanma Yeri : ");
                                    var yanmaYeri = Console.ReadLine();
                                    Console.WriteLine("Silindir : ");
                                    var silindir = Console.ReadLine();
                                    Motor.ParcaTanimla(parcaListesi, yakitTipi, yanmaYeri, silindir, mevcutAdet);
                                    Console.WriteLine("Parça Tanımlandı");
                                    break;
                                case 4:
                                    Console.WriteLine("Fren sistemi türü : ");
                                    var frentipi = Console.ReadLine();
                                    Fren.ParcaTanimla(parcaListesi, frentipi, mevcutAdet);
                                    Console.WriteLine("Parça Tanımlandı");
                                    break;
                                case 5:
                                    Console.WriteLine("Sanziman Turu");
                                    var sanzimanTuru = Console.ReadLine();
                                    Sanziman.ParcaTanimla(parcaListesi, sanzimanTuru, mevcutAdet);
                                    Console.WriteLine("Parça Tanımlandı");
                                    break;
                                default: Console.WriteLine("Yanlis secim yaptiniz"); break;
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Programdan çıkılıyor.");
                            return;
                        }
                    case 7:
                        Console.Clear();
                        stokTakip.MenuGoster();
                        break;

                    default:
                        {
                            Console.WriteLine("Hatalı seçim yaptınız. Lütfen tekrar deneyiniz.");
                        }
                        break;
                }
            }
        }



    }
}
