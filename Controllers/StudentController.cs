using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentWebAPI.Model;
using StudentWebAPI.Services;

namespace StudentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices) 
        {
            _studentServices = studentServices;
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentsDTO studentinfo)
        {
            try
            {
                var result = await _studentServices.AddStudent(studentinfo);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentsDTO studentinfo)
        {
            try
            {
                if (studentinfo.StudentID > 0)
                {
                    var result = await _studentServices.UpdateStudent(studentinfo);

                    return Ok(result);
                }
                else
                    return BadRequest("Invalid Student ID");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("DeleteStudent/{StudentID}")]
        public async Task<IActionResult> DeleteStudent(int StudentID)
        {
            try
            {
                if (StudentID > 0)
                {
                    var result = await _studentServices.DeleteStudent(StudentID);

                    return Ok(result);
                }
                else
                    return BadRequest("Invalid Student ID");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetStudent/{StudentID}")]
        public async Task<IActionResult> GetStudent(int StudentID)
        {
            try
            {
                if (StudentID > 0)
                {
                    var result = await _studentServices.GetStudent(StudentID);

                    return Ok(result);
                }
                else
                    return BadRequest("Invalid Student ID");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            try
            { 
                    var result = await _studentServices.GetAllStudent();

                    return Ok(result); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
