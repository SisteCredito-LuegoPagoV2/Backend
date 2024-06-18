using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class UserRole
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "This field is necessary")]
        [ForeignKey("MarketingUsers")]
        public int User_Id {get;set;}

        [Required(ErrorMessage = "This field is necessary")]
        [ForeignKey("Roles")]
        public int Role_Id {get;set;}

        //Relaciòn: UserRole lists to Role -
        // public Role? Role {get;set;}

        // //Relaciòn : UserRole is listed by MarketingUser -
        // [JsonIgnore]
        // public List<MarketingUser>? MarketingUsers {get;set;}
    }
}