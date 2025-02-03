using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ZooAPI.models
{
    public enum UserRole
    {
        Adminstrator,
        ZooKeeper,
        Veterinarian,
        None
    }

    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public UserRole Role { get; set; }
        public string mainArea { get; set; }
        public string Password { get; set; }
        public bool changedDefault { get; set; }

    }
}
