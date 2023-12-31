using StudentWebAPI.Model;

namespace StudentWebAPI.Services
{
    public interface IStudentServices
    {
        Task<MainResponse> GetAllStudent();
        Task<MainResponse> GetStudent(int StudentID);
        Task<MainResponse> AddStudent(StudentsDTO studentDTO);
        Task<MainResponse> UpdateStudent(StudentsDTO studentDTO);
        Task<MainResponse> DeleteStudent(int StudentID);
        
    }
}
