using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Enrollment.Api.Models
{
    [Table("Enrollment")]
    [Index("StudentId", "CourseId", Name = "UQ_Student_Course", IsUnique = true)]
    public partial class EnrollmentEntity
    {
        [Key]
        public int EnrollmentId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Status { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime EnrollmentDate { get; set; }
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        [InverseProperty("Enrollments")]
        [JsonIgnore]
        public virtual Course Course { get; set; } = null!;
        [ForeignKey("StudentId")]
        [InverseProperty("Enrollments")]
        [JsonIgnore]
        public virtual Student Student { get; set; } = null!;
    }
}
