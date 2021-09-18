using System;

namespace BlazorServerApp.Models
{
    public class Student
    {
        public int IdStudent { get; set; }
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Studies { get; set; }
    }
}
