using Microsoft.AspNetCore.Mvc;
using GradingPlatformMVC.Models.Metadata;
using System;
using System.ComponentModel.DataAnnotations;


namespace GradingPlatformMVC.Models
{
    [ModelMetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
    }

    [ModelMetadataType(typeof(ProfessorsCoursesMetadata))]
    public partial class Course
    {
    }

}
