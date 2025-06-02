using Enrollment.Api.Models;
using Enrollment.Api.Repositories;
using Enrollment.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace Enrollment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _repository;

        public EnrollmentController(IEnrollmentRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] int studentId, [FromQuery] int courseId, [FromQuery] string status)
        {
            if (studentId <= 0 || courseId <= 0 || string.IsNullOrWhiteSpace(status))
                return BadRequest("Parámetros inválidos.");

            var result = await _repository.CreateEnrollmentAsync(studentId, courseId, status);
            return result ? Ok("Matrícula creada") : BadRequest("No se pudo crear la matrícula");
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(status))
                return BadRequest("Parámetros inválidos.");

            var result = await _repository.UpdateStatusAsync(id, status);
            return result ? Ok("Estado actualizado") : BadRequest("No se pudo actualizar el estado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("ID inválido.");

            var result = await _repository.DeleteEnrollmentAsync(id);
            return result ? Ok("Matrícula eliminada") : BadRequest("No se pudo eliminar la matrícula");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("ID inválido.");

            var enrollment = await _repository.GetByIdAsync(id);
            return enrollment != null ? Ok(enrollment) : NotFound("Matrícula no encontrada");
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId)
        {
            if (studentId <= 0)
                return BadRequest("ID de estudiante inválido.");

            var enrollments = await _repository.GetByStudentIdAsync(studentId);
            return Ok(enrollments);
        }

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetByCourseId(int courseId)
        {
            if (courseId <= 0)
                return BadRequest("ID de curso inválido.");

            var enrollments = await _repository.GetByCourseIdAsync(courseId);
            return Ok(enrollments);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return BadRequest("Estado inválido.");

            var enrollments = await _repository.GetByStatusAsync(status);
            return Ok(enrollments);
        }
    }
}
