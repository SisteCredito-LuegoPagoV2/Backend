using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class UserRole
    {
        public int id {get;set;}
        [Required(ErrorMessage = "This field is necessary")]
        public int user_id {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        public int role_id {get;set;}

        //Relaciòn: UserRole lists to Role -
        public Role? Role {get;set;}

        //Relaciòn : UserRole is listed by MarketingUser -
        [JsonIgnore]
        public MarketingUser? MarketingUser {get;set;}
    }
}