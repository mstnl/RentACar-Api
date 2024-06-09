

namespace RentACarAPI.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public string eposta { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public bool adminMi { get; set; }
    }
}