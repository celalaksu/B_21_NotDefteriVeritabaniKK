using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NotDefteriVeritabani.YardimciSiniflar
{
    public static class EpostaKontrol
    {
        private const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        
        public static bool EpostayiKontrolEt(string eposta)
        {
            bool IsValid = false;
            IsValid = (Regex.IsMatch(eposta, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            if (IsValid)
                return true;
            else
                return false;
        }
    }
}
