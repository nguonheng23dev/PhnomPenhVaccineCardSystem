namespace PhnomPenhVaccineCardSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public DateTime VisitDate { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public List<VaccineCard> VaccineCards { get; set; } = new List<VaccineCard>();
    }
}
