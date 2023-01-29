using System.ComponentModel.DataAnnotations;

namespace GradingPlatformMVC.Models.Metadata
{
    public class StudentMetadata
    {
        [Display(Name="Registration Number")]
        public string RegistrationNum { get; set; } = null!;
    }
}
