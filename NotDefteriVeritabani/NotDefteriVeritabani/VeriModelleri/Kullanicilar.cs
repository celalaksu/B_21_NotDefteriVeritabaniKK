using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotDefteriVeritabani.VeriModelleri
{
    public class Kullanicilar
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Eposta { get; set; }
        [MaxLength(12)]
        public string Parola { get; set; }

        public Kullanicilar()
        {

        }
    }

}
