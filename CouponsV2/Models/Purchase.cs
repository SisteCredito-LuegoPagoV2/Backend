namespace CouponsV2.Models
{
    public class Purchase
    {
        public int id {get;set;}
        public int user_id {get;set;}
        public DateTime date {get;set;}
        public decimal amount {get;set;}

    }
}