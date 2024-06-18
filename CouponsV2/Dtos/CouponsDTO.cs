using System.ComponentModel.DataAnnotations;

namespace CouponsV2.Dtos
{
    public class CouponsDTO
    {
        public int ? Id { get; set; }

        public string ? Name { get; set; }


        public string ? Description { get; set; }


        public string? Code {get; set;}


        public DateOnly ? Start_Date { get; set; }


        public DateOnly ? End_Date { get; set; }


        public string ? Discount_Type { get; set; }

        public decimal ? Discount_Value { get; set; }

        public int ? Usage_Limit {get; set;}

        public decimal ? Min_Purchase_Amount {get; set; }

        public decimal ? Max_Purchase_Amount {get; set; }

        public string ? Status {get; set; }

        public DateOnly? Created_At {get; set;}

        public int? Uses {get; set;}

        public int? Created_By {get; set; }
        

        
    }
}
