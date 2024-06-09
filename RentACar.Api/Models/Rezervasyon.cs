namespace RentACarAPI.Models
{
    public class Rezervasyon
    {
        public int Id { get; set; }
        public int kullaniciId { get; set; }
        public int aracId { get; set; }
        public DateTime baslangicTarihi { get; set; }
        public DateTime bitisTarihi { get; set; }
        public bool onayDurumu { get; set; }
        public decimal toplamUcret { get; set; }

        public Kullanici Kullanici { get; set; }
        public Arac Arac { get; set; }
    }
}
