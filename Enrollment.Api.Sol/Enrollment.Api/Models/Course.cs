using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Enrollment.Api.Models
{
    [Table("Course")]
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<EnrollmentEntity>();
        }

        [Key]
        public int CourseId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string CourseName { get; set; } = null!;

        [InverseProperty("Course")]
        public virtual ICollection<EnrollmentEntity> Enrollments { get; set; }
    }
}
