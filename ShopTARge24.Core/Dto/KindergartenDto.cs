using System;
using System.ComponentModel.DataAnnotations;

namespace ShopTARge24.Core.Dto
{
    public class KindergartenDto
    {
        public int Id { get; set; }

        [Display(Name = "Group Name")]
        [Required, StringLength(100)]
        public string GroupName { get; set; } = default!;

        [Display(Name = "Children Count")]
        [Range(0, 1000)]
        public int ChildrenCount { get; set; }

        [Display(Name = "Kindergarten Name")]
        [Required, StringLength(150)]
        public string KindergartenName { get; set; } = default!;

        [Display(Name = "Teacher Name")]
        [Required, StringLength(100)]
        public string TeacherName { get; set; } = default!;

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }
    }
}

