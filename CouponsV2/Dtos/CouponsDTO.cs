using System.ComponentModel.DataAnnotations;

namespace CouponsV2.Dtos
{
    public class CouponsDTO
    {
       public int ? Id { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string ? Name { get; set; }


        [Required(ErrorMessage = "This field is necessary")]
        public string ? Description { get; set; }


        [Required(ErrorMessage = "This field is necessary")]
        public string? Code {get; set;}


        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly ? Start_Date { get; set; }


        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly ? End_Date { get; set; }


        [Required(ErrorMessage = "This field is necessary")]
        public string ? Discount_Type { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public decimal ? Discount_Value { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public int ? Usage_Limit {get; set;}

        [Required(ErrorMessage = "This field is necessary")]
        public decimal ? Min_Purchase_Amount {get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public decimal ? Max_Purchase_Amount {get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string ? Status {get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly? Created_At {get; set;}

        [Required(ErrorMessage = "This field is necessary")]
        public int? Uses {get; set;}

        [Required(ErrorMessage = "This field is necessary")]
        public int? Created_By {get; set; }
        

        
    }
}
