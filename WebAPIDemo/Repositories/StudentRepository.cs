using WebAPIDemo.Entities;

namespace WebAPIDemo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext context;

        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public int AddStudent(Student student)
        {
            int result = 0;
            student.IsActive = 1;
            context.students.Add(student);
            result = context.SaveChanges();
            return result;
        }

        public int DeleteStudent(int id)
        {
            int result = 0;
            var stu = context.students.Where(x => x.Id == id).FirstOrDefault();
            if (stu != null)
            {
                stu.IsActive = 0;
                result = context.SaveChanges();
            }
            return result;
        }

        public Student GetStudentById(int id)
        {
            int result = 0;
            var student = context.students.Where(x => x.Id == id).FirstOrDefault();
            return student;
        }

        public IEnumerable<Student> GetStudents()
        {
            return context.students.Where(x => x.IsActive == 1).ToList();
        }

        public int UpdateStudent(Student student)
        {
            int result = 0;
            var b = context.students.Where(x => x.Id == student.Id).FirstOrDefault();
            if (b != null)
            {
                b.Name = student.Name;
                b.Marks = student.Marks;
                b.IsActive = 1;
                result = context.SaveChanges();
            }
            return result;
        }
    }
}
