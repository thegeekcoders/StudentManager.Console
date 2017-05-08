using StudentManager.Entity;
using System.Collections.Generic;
using System.Linq;

namespace StudentManager.Services
{
    public interface IStudentData
    {
        IEnumerable<Student> GetAll();
        Student AddStudent(Student newStudent);
        Student Get(int id);
        int Remove(int id);
    }

    public class InMemoryStudentData : IStudentData
    {
        public InMemoryStudentData()
        {
            _students = new List<Student>()
            {
                new Student() {Id = 1, Name = "Chetan", RollNo = "22"},
                new Student() {Id=2, Name = "Samir", RollNo = "12"},
                new Student() {Id=3, Name = "Pasang", RollNo = "14"}
            };
        }

        public Student AddStudent(Student newStudent)
        {
            _students.Add(newStudent);
            return newStudent;
        }

        public Student Get(int id)
        {
            var student = _students.Single(s => s.Id == id);
            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public int Remove(int id)
        {
            var student = Get(id);
            _students.Remove(student);
            return id;
        }

        private List<Student> _students;
    }
}
