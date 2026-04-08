using System.ComponentModel.DataAnnotations;

namespace TestingApplication.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Phone_Number { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}

