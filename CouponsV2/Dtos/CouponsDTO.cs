using System.ComponentModel.DataAnnotations;

namespace CouponsV2.Dtos
{
    public class CouponsDTO
    {
        public int ? id { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string ? name { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string ? description { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly ? start_date { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly ? end_date { get; set; }

        [Required(ErrorMessage = "This field is necessary")]
        public string ? discount_type { get; set; }
        [Required(ErrorMessage = "This field is necessary")]

        public string ? discount_value { get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int ? usage_limit {get; set;}
        [Required(ErrorMessage = "This field is necessary")]

        public decimal ? min_purchase_amount {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public decimal ? max_purchase_amount {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public string ? status {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int? created_by {get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public string? code {get; set;}
        [Required(ErrorMessage = "This field is necessary")]
        public DateOnly? CreatedAt {get; set;}
    }
}
