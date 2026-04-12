using System.ComponentModel.DataAnnotations;

namespace PromocodeFactory.Models
{
    public class EmployeeUpdateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int RoleId { get; set; }
    }
}
