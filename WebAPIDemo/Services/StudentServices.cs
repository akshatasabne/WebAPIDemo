using WebAPIDemo.Entities;
using WebAPIDemo.Repositories;

namespace WebAPIDemo.Services
{
    public class StudentServices : IStudentService
    {
        private readonly IStudentRepository repo;
        public StudentServices(IStudentRepository repo)
        {
            this.repo = repo;
        }

        public int AddStudent(Student student)
        {
            return repo.AddStudent(student);
        }

        public int DeleteStudent(int id)
        {
            return repo.DeleteStudent(id);
        }

        public Student GetStudentById(int id)
        {
            return repo.GetStudentById(id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return repo.GetStudents();
        }

        public int UpdateStudent(Student student)
        {
            return repo.UpdateStudent(student);
        }
    }
}
