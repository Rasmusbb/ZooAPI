using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

using ZooAPI.Interfaces;

namespace ZooAPI.models
{
    public enum UserRole
    {
        Admin,
        ZooKeeper,
        Veterinarian,
        User
    }

    public class User : IUser
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
        public bool Deleted { get; set; }

        public ICollection<ZooKeeper> Enclosures { get; set; }

    }
}
