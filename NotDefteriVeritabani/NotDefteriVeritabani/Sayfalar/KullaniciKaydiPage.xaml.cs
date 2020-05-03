using NotDefteriVeritabani.Veriler;
using NotDefteriVeritabani.VeriModelleri;
using NotDefteriVeritabani.YardimciSiniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotDefteriVeritabani.Sayfalar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KullaniciKaydiPage : ContentPage
    {
        public KullaniciKaydiPage()
        {
            InitializeComponent();
        }

        private async void KullaniciKaydet(object sender, EventArgs e)
        {
            var kullanici = (Kullanicilar)kullaniciKaydiSL.BindingContext;
            bool sonuc = await App.KullaniciVeritabani.KullaniciEkle(kullanici);
            if (emailEntry.Text.Equals(emailDogrulaEntry) && passwordEntry.Text.Equals(passwordDogrulaEntry))
            {
                if (sonuc)
                {
                    await DisplayAlert("İşlem Başarılı", "Başarılı bir şekilde kayıt oldunuz. Giriş sayfasına yönlendiriliyorsunuz", "Tamam");
                    await Task.Delay(2000);
                    await Navigation.PushAsync(new LoginPage());

                }
                else
                {
                    await DisplayAlert("İşlem Başarısız", "Bu epostayla daha önce kayıt yapılmış", "Tamam");
                    FormuTemizle();
                }
            }
            else
            {
                await DisplayAlert("İşlem Başarısız", "Parola ya da eposta adresleri birbiriyle uyuşmyor", "Tamam");
                FormuTemizle();
            }
        }

        void FormuTemizle()
        {
            emailEntry.Text = String.Empty;
            emailDogrulaEntry.Text= String.Empty;
            passwordEntry.Text = String.Empty;
            passwordDogrulaEntry.Text = String.Empty;
        }

        private void EpostayiKontrolEt(object sender, EventArgs e)
        {
            var entry = (Entry)sender;
            string eposta = entry.Text;
            bool sonuc = EpostaKontrol.EpostayiKontrolEt(eposta);
            if (sonuc)
                hataLabel.Text = String.Empty;
            else
                hataLabel.Text = "Geçerli bir eposta giriniz";      
        }
    }
}