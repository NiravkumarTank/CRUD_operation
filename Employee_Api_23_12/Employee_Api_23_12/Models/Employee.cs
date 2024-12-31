using System.ComponentModel.DataAnnotations;

namespace Employee_Api_23_12.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
  
        public required string Name { get; set; }
      
        public required string  Address { get; set; }
       
        public required string City { get; set; }

    }
}
