namespace PhnomPenhVaccineCardSystem.Models
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
