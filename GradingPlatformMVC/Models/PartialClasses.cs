using Microsoft.AspNetCore.Mvc;
using GradingPlatformMVC.Models.Metadata;
using System;
using System.ComponentModel.DataAnnotations;


namespace GradingPlatformMVC.Models
{

    [ModelMetadataType(typeof(ProfessorsCoursesMetadata))]
    public partial class Course
    {
        /*[Display(Name = "Professor")]
        public string? professor { get; set; }*/
    }

}
