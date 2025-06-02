using Enrollment.Api.Data;
using Enrollment.Api.Models;
using Enrollment.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enrollment.Api.Repositories
{

    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEnrollmentAsync(int studentId, int courseId, string status)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC CreateEnrollment @p0, @p1, @p2",
                    studentId, courseId, status);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateStatusAsync(int enrollmentId, string newStatus)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC UpdateEnrollmentStatus @p0, @p1",
                    enrollmentId, newStatus);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteEnrollmentAsync(int enrollmentId)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC DeleteEnrollment @p0",
                    enrollmentId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<EnrollmentEntity> GetByIdAsync(int id)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.EnrollmentId == id);
        }

        public async Task<IEnumerable<EnrollmentEntity>> GetByStudentIdAsync(int studentId)
        {
            return await _context.Enrollments
                .Include(e => e.Course)
                .Where(e => e.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<EnrollmentEntity>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Where(e => e.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<IEnumerable<EnrollmentEntity>> GetByStatusAsync(string status)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.Status == status)
                .ToListAsync();
        }

    }

}
