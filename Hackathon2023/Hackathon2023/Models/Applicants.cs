using System;

namespace Hackathon2023.Models
{
    public class Applicants
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Major1 { get; set; }
        public string Degree1 { get; set; }
        public string? Major2 { get; set; }
        public string? Degree2 { get; set; }
        public string? Major3 { get; set; }
        public string? Degree3 { get; set; }
        public string GraduationMonth { get; set; }
        public int GraduationYear { get; set; }
        public decimal GPA { get; set; }
        public string School { get; set; }
        public string PositionType { get; set; }
        public string SponsorshipNeeded { get; set; }
        public string? LinkedInURL { get; set; }
        public byte[]? Resume { get; set; }
        public bool Active { get; set; }

    }
}
