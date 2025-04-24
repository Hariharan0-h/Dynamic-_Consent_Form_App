using System.ComponentModel.DataAnnotations;

namespace Consent_Form.Model
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Eye { get; set; }
        public string Gender { get; set; }
        public string UIN { get; set; }
        public string Diagnosis { get; set; }
        public string Procedure { get; set; }
        public string Implant { get; set; }
        public string DoctorName { get; set; }
        public string MICRNo { get; set; }
        public DateTimeOffset Date { get; set; }

    }
}
