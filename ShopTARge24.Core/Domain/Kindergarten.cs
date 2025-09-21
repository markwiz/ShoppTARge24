using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel.DataAnnotations;

namespace ShopTARge24.Core.Domain
{
    public class Kindergarten
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string GroupName { get; set; } = default!;

        [Range(0, 1000)]
        public int ChildrenCount { get; set; }

        [Required, StringLength(150)]
        public string KindergartenName { get; set; } = default!;

        [Required, StringLength(100)]
        public string TeacherName { get; set; } = default!;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

