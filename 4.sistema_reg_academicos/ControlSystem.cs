using System;

public static class ControlSystem
{
    public static List<Student> Students { get; set; } = new List<Student>();
    public static List<Course> Courses { get; set; } = new List<Course>();

    public static void AddStudent(Student student)
    {
        ControlSystem.Students.Add(student);
    }
    public static void AddCourse(Course course)
    {
        ControlSystem.Courses.Add(course);
    }
}