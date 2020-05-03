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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void KullaniciKayitButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KullaniciKaydiPage());
        }

        private async void GirisYap(object sender, EventArgs e)
        {
            bool sonuc = await App.KullaniciVeritabani.GirisYap(emailEntry.Text, passwordEntry.Text);
            if (sonuc)
            {                
                await Task.Delay(2000);
                await Navigation.PushAsync(new NotGirisPage());
            }
            else
            {
                await DisplayAlert("İşlem Başarısız", "Yanlış kullanıcı adı ya da parola girdiniz", "Tamam");                
            }
        }
    }
}