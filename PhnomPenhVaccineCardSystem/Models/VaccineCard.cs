namespace PhnomPenhVaccineCardSystem.Models
{
    public class VaccineCard
    {

            public int VaccineCardId { get; set; }
            public string CardNumber { get; set; }
            public VaccineCardType CardType { get; set; }
            public int CustomerId { get; set; }
            public Customer Customer { get; set; }
        }

        public enum VaccineCardType
        {
            MOH,
            MOD
        }
}
