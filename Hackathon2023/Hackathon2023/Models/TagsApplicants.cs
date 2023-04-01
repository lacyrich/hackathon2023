using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon2023.Models
{
    public class TagsApplicants
    {
        public int Id { get; set; }
        [ForeignKey("Tags")]
        public int? TagID { get; set; }
        public Tags? Tags { get; set; }
        [ForeignKey("Applicants")]
        public int? ApplicantID { get; set;}
        public Applicants? Applicants { get; set; }
    }
}
