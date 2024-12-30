using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Not girişi yapacağınız öğrenci sayısını giriniz: ");
            int ogrenciSayisi = int.Parse(Console.ReadLine());

            string[,] ogrenciler = new string[ogrenciSayisi, 6];
            double toplamOrtalama = 0;
            double enYuksek = 0;
            double enDusuk = 100;

            for (int i = 0; i < ogrenciSayisi; i++)
            {
                Console.WriteLine($"{i + 1}. Öğrencinin bilgilerini giriniz:");

                Console.Write("Numara: ");
                ogrenciler[i, 0] = Console.ReadLine();
                Console.Write("Ad: ");
                ogrenciler[i, 1] = Console.ReadLine();
                Console.Write("Soyad: ");
                ogrenciler[i, 2] = Console.ReadLine();

                ogrenciler[i, 3] = not("Vize Notu: ").ToString();
                ogrenciler[i, 4] = not("Final Notu: ").ToString();

                double vize = double.Parse(ogrenciler[i, 3]);
                double final = double.Parse(ogrenciler[i, 4]);

                double ortalama = (vize * 0.4) + (final * 0.6);
                ogrenciler[i, 5] = ortalama.ToString("0.00");

                toplamOrtalama += ortalama;

                if (ortalama > enYuksek) enYuksek = ortalama;
                if (ortalama < enDusuk) enDusuk = ortalama;

                Console.WriteLine($"Ortalama: {ortalama:0.00}, Harf Notu: {harfnotu(ortalama)}");
            }

            Console.WriteLine("\nNumara\tAd\tSoyad\tVize\tFinal\tOrtalama\tHarf Notu");
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                double ortalama = double.Parse(ogrenciler[i, 5]);
                Console.WriteLine($"{ogrenciler[i, 0]}\t{ogrenciler[i, 1]}\t{ogrenciler[i, 2]}\t{ogrenciler[i, 3]}\t{ogrenciler[i, 4]}\t{ogrenciler[i, 5]}\t{harfnotu(ortalama)}");
            }

            Console.WriteLine($"Sınıf Ortalaması: {toplamOrtalama / ogrenciSayisi:0.00}");
            Console.WriteLine($"En Yüksek Not: {enYuksek:0.00}");
            Console.WriteLine($"En Düşük Not: {enDusuk:0.00}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Hatalı giriş yaptınız! Lütfen sayısal bir değer girin.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Bir hata oluştu: {ex.Message}");
        }
    }

    static int not(string bilgi)
    {
        int not;
        do
        {
            try
            {
                Console.Write(bilgi);
                not = int.Parse(Console.ReadLine());
                if (not < 0 || not > 100)
                    Console.WriteLine("Not 0 ile 100 arasında olmalıdır.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Hatalı giriş yaptınız! Lütfen sayısal bir değer girin.");
                not = -1;
            }
        } while (not < 0 || not > 100);
        return not;
    }

    static string harfnotu(double ortalama)
    {
        if (ortalama >= 85) return "AA";
        else if (ortalama >= 75) return "BA";
        else if (ortalama >= 60) return "BB";
        else if (ortalama >= 50) return "CB";
        else if (ortalama >= 40) return "CC";
        else if (ortalama >= 30) return "DC";
        else if (ortalama >= 20) return "DD";
        else if (ortalama >= 10) return "FD";
        return "FF";
    }
	//Taki Samed KARATEPE 24380101014
}
