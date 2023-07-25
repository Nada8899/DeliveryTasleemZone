using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class Delivery : IBaseModel<string>
    {

        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string ?FullName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string? Address { get; set; }
        public byte[] ?ProfileImg { get; set; }
        public double ?Balance { get; set; }
        public int ?Points { get; set; }
        public string ?OverView { get; set; }
        public virtual IEnumerable<Skill>? Skills  { get; set; }
        public double ?YearExperinces { get; set; }
        public virtual IEnumerable<SavedJob> ?SavedJobs { get; set; }
        public virtual IEnumerable<Job>? PreviousJobs { get; set; }

        public virtual IEnumerable<Review> ?Reviews { get; set; }
        public virtual IEnumerable<Language> ?Languges { get; set; }
        public virtual IEnumerable<Proposal> ?Proposals { get; set; }

        [ForeignKey("EducationLevel")]
        public int ?EducationLevelID { get; set; }

        public virtual EducationLevel ?EducationLevel { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }




    }
}