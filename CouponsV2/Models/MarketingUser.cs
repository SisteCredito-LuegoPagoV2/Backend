using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class MarketingUser
    {
        public int? Id {get;set;}
        [Required(ErrorMessage = "This field is necessary")]
        public string ? Username {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public string ? Password {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public string ? Email {get;set;}

        //Relaciòn : MarketingUser is listed by Coupon -

        // [JsonIgnore]
        // public List<Coupon>? Coupons {get;set;}

        // //Relaciòn : MarketingUser lists to UserRole -
        // public UserRole? UserRoles {get;set;}

    }
}

