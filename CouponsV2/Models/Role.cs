using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class Role
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "This field is necessary")]
        public string? Name {get;set;}
        
        //Relaciòn : Role is listed by UserRole -
        // [JsonIgnore]
        // public List<UserRole>? UserRoles {get;set;}
    }
}