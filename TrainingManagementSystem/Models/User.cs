using Microsoft.AspNetCore.Identity;

namespace TrainingManagementSystem.Models
{
    public enum Role { 
        Manager=1,
        Employee=2
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }    
        public bool IsActive { get; set; }
        public Role Role { get; set; }
        public int? ManagerId { get; set; }
        public virtual User? Manager { get; set; }
    }
}
