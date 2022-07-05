using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace HrOffice.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        [Required(ErrorMessage = "This field required")]
        [MaxLength(250)]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "This field required")]
        [MaxLength(250)]
        [DisplayName("Database Name")]
        public string DBName { get; set; }

        [Required(ErrorMessage = "This field required")]
        [MaxLength(250)]
        [DisplayName("Database UserId")]
        public string DBUserId { get; set; }

        [Required(ErrorMessage = "This field required")]
        [MaxLength(250)]
        [DisplayName("Database password")]
        public string DBUserPassword { get; set; }

        [Required(ErrorMessage = "This field required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [DisplayName("Email")]
        public string EmailId { get; set; }
        
        [MaxLength(200)]
        [DisplayName("Work Location")]
        public string Location { get; set; }
    }
}
