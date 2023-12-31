using StudentWebAPI.Context;
using StudentWebAPI.Data;
using StudentWebAPI.Model;
using System.Security.Cryptography.Xml;

namespace StudentWebAPI.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly StudentDbContext _context;
        public StudentServices(StudentDbContext _context)
        {
            this._context = _context;
        }
        public async Task<MainResponse> AddStudent(StudentsDTO studentDTO)
        {
            MainResponse response = new();
            try
            {

                if (_context.Students.Any(s => s.Email.ToLower() == studentDTO.Email.ToLower()))
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = "Student already exist with this Email";
                }
                else
                {
                    await _context.Students.AddAsync(new Student
                    {
                        FirstName = studentDTO.FirstName,
                        LastName = studentDTO.LastName,
                        Email = studentDTO.Email,
                        Gender = studentDTO.Gender,
                        Address = studentDTO.Address,
                    });
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Student Added";
                }
                
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
                return response;
            }
            return response;
        }
         
        public async Task<MainResponse> UpdateStudent(UpdateStudentDTO studentDTO)
        {
            MainResponse response = new();
            try
            {
                var rec = _context.Students.FirstOrDefault(s => s.StudentID == studentDTO.StudentID);
                if (rec == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = "Student not found";
                }
                else
                {
                    rec.FirstName = studentDTO.FirstName;
                    rec.LastName = studentDTO.LastName;
                    rec.Gender = studentDTO.Gender;
                    rec.Address = studentDTO.Address;
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Student Updated";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
                return response;
            }
            return response;
        }
        public async Task<MainResponse> DeleteStudent(int studentID)
        {
            MainResponse response = new();
            try
            {
                var rec = _context.Students.FirstOrDefault(s => s.StudentID == studentID);
                if (rec == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = "Student not found";
                }
                else
                {
                    _context.Remove(rec);
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Student Deleted";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
                return response;
            }
            return response;
        }
        public async Task<MainResponse> GetStudent(int studentID)
        {
            MainResponse response = new();
            try
            {
                var rec = _context.Students.FirstOrDefault(s => s.StudentID == studentID);
                if (rec == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = "Student not found";
                }
                else
                {
                    response.Content = rec;
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
                return response;
            }
            return response;
        }
        public async Task<MainResponse> GetAllStudent()
        {
            MainResponse response = new();
            try
            {
                if (_context.Students.Count() == 0 )
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = "Students not found";
                }
                else
                {
                    response.Content = _context.Students.ToList();
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
                return response;
            }
            return response;
        }
          
    }
}
