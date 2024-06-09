
namespace RentACarAPI.Models
{
    public class Arac
    {
        public int id { get; set; }
        public string? marka { get; set; }
        public string? model { get; set; }
        public string? tipi { get; set; }
        public string? resim { get; set; }
        public string? vitesTuru { get; set; }
        public string? yakitTuru { get; set; }
        public decimal? gunlukKiralamaUcreti { get; set; }
        public int? kisiSayisi { get; set; }
        public int? kapiSayisi { get; set; }
        public bool? klima { get; set; }
        public string? plaka { get; set; }
        public int? modelYili { get; set; }
    }
}