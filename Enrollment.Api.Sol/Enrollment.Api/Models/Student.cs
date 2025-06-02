using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Enrollment.Api.Models
{
    [Table("Student")]
    public partial class Student
    {
        public Student()
        {
            Enrollments = new HashSet<EnrollmentEntity>();
        }

        [Key]
        public int StudentId { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string StudentName { get; set; } = null!;

        [InverseProperty("Student")]
        public virtual ICollection<EnrollmentEntity> Enrollments { get; set; }
    }
}
