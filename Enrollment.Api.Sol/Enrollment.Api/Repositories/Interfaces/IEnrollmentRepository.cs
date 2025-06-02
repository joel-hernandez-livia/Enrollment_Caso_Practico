using Enrollment.Api.Models;
namespace Enrollment.Api.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<bool> CreateEnrollmentAsync(int studentId, int courseId, string status);
        Task<bool> UpdateStatusAsync(int enrollmentId, string newStatus);
        Task<bool> DeleteEnrollmentAsync(int enrollmentId);
   
        Task<EnrollmentEntity> GetByIdAsync(int id);
        Task<IEnumerable<EnrollmentEntity>> GetByStudentIdAsync(int studentId);
        Task<IEnumerable<EnrollmentEntity>> GetByCourseIdAsync(int courseId);
        Task<IEnumerable<EnrollmentEntity>> GetByStatusAsync(string status);
  
    }

}
