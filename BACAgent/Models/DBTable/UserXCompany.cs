using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACAgent.Models.DBTable
{
    public class UserXCompany:AuditBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserXCompanyId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ApplicationUser User { get; set; }
    }
}