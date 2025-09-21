using System;

namespace ShopTARge24.Models.Kindergartens
{
    public class KindergartenDeleteViewModel
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = default!;
        public int ChildrenCount { get; set; }
        public string KindergartenName { get; set; } = default!;
        public string TeacherName { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
