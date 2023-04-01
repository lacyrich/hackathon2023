namespace Hackathon2023.Models
{
    public class ApplicantsTagsVM
    {
        public Applicants Applicants { get; set; }
        public Tags Tags { get; set; }  
        public List<TagsApplicants> TagsApplicants { get; set;}
    }
}
