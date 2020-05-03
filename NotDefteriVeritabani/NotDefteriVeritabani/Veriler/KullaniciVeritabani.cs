using NotDefteriVeritabani.Sayfalar;
using NotDefteriVeritabani.VeriModelleri;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteriVeritabani.Veriler
{
    public class KullaniciVeritabani
    {
        SQLiteAsyncConnection veritabani;

        public KullaniciVeritabani(string dosyaYolu)
        {
            veritabani = new SQLiteAsyncConnection(dosyaYolu);
            veritabani.CreateTableAsync<Kullanicilar>().Wait();
        }

        public async Task<bool> KullaniciEkle(Kullanicilar kullanici)
        {            
            string eposta = kullanici.Eposta;
            bool kullaniciKontrol = await KullaniciKontrol(eposta);
            if (kullaniciKontrol)
            {
                return false;                
            }
            else
            {
                await veritabani.InsertAsync(kullanici);
                return true;               
            }
        }

        public async Task<bool> KullaniciKontrol(string eposta)
        {
            var kullanici = await veritabani.Table<Kullanicilar>().Where((u) => u.Eposta.Equals(eposta)).FirstOrDefaultAsync();
            
            if (kullanici != null)
                return true;
            else
                return false;
        }

        public async Task<bool> GirisYap(string eposta, string parola)
        {
            var kullanici = await veritabani.Table<Kullanicilar>().Where((u) => u.Eposta.Equals(eposta) && u.Parola.Equals(parola)).FirstOrDefaultAsync();
            if (kullanici != null)
                return true;
            else
                return false;
        }
    }
}
