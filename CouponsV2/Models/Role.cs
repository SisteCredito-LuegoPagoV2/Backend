using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CouponsV2.Models
{
    public class Role
    {
        public int id {get;set;}
        [Required(ErrorMessage = "This field is necessary")]
        public string? name {get;set;}
        
        //Relaciòn : Role is listed by UserRole -
        [JsonIgnore]
        public ICollection<UserRole>? UserRoles {get;set;}
    }
}