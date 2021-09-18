using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp.Models
{
    public class StudentConstructor
    {
        public static List<Student> Students { get; set; }

        static StudentConstructor()
        {
            Students = new List<Student>();
            Students.Add(new Student
            {
                IdStudent = 1,
                Avatar = "https://img-premium.flaticon.com/png/512/147/147144.png?token=exp=1623258587~hmac=2978bf65c0a0946e980e60c326362aa3",
                FirstName = "John",
                LastName = "Snow",
                Birthdate = new DateTime(2005, 6, 9),
                Studies = "Information Technologies"
            });
            Students.Add(new Student
            {
                IdStudent = 2,
                Avatar = "https://img-premium.flaticon.com/png/512/147/147144.png?token=exp=1623258587~hmac=2978bf65c0a0946e980e60c326362aa3",
                FirstName = "Wewe",
                LastName = "Brown",
                Birthdate = new DateTime(2003, 5, 4),
                Studies = "Design"
            });
            Students.Add(new Student
            {
                IdStudent = 3,
                Avatar = "https://img-premium.flaticon.com/png/512/147/147144.png?token=exp=1623258587~hmac=2978bf65c0a0946e980e60c326362aa3",
                FirstName = "Mike",
                LastName = "Rain",
                Birthdate = new DateTime(2003, 7, 8),
                Studies = "Information Technologies"
            });
            Students.Add(new Student
            {
                IdStudent = 4,
                Avatar = "https://img-premium.flaticon.com/png/512/147/147144.png?token=exp=1623258587~hmac=2978bf65c0a0946e980e60c326362aa3",
                FirstName = "Jan",
                LastName = "Kowalski",
                Birthdate = new DateTime(2021, 5, 24),
                Studies = "Informatyka"
            });
            Students.Add(new Student
            {
                IdStudent = 5,
                Avatar = "https://img-premium.flaticon.com/png/512/147/147144.png?token=exp=1623258587~hmac=2978bf65c0a0946e980e60c326362aa3",
                FirstName = "Anna",
                LastName = "Malewska",
                Birthdate = new DateTime(2021, 4, 24),
                Studies = "Informatyka"
            });
            Students.Add(new Student
            {
                IdStudent = 6,
                Avatar = "https://img-premium.flaticon.com/png/512/147/147144.png?token=exp=1623258587~hmac=2978bf65c0a0946e980e60c326362aa3",
                FirstName = "Illia",
                LastName = "Zviezdin",
                Birthdate = new DateTime(2002, 12, 20),
                Studies = "Information Technologies"
            });
        }
    }
}
