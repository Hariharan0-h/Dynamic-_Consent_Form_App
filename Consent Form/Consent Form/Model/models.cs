using System.ComponentModel.DataAnnotations;

namespace Consent_Form.Model
{
    public class models
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string template { get; set; }
    }
}
