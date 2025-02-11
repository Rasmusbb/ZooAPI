using ZooAPI.models;

namespace ZooAPI.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string mainArea { get; set; }

        public string Role { get; set; }

        
    }

    public class UserDTOID : UserDTO
    {
        public Guid UserID { get; set; }
    }

    public class CreateUserDTO : UserDTO
    {
        public string Password { get; set; }
    }
}
