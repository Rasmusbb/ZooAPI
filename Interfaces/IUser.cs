using ZooAPI.models;

namespace ZooAPI.Interfaces
{
    public interface IUser
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public UserRole Role { get; set; }
        public string mainArea { get; set; }
        public string Password { get; set; }
        public bool changedDefault { get; set; }
        public bool Deleted { get; set; }
    }


    public interface IZooKeeper : IUser
    {
        ICollection<Enclosure> enclosures { get; set; }
    }

    public interface IVeterinarian : IUser
    {
        ICollection<Animal> animals { get; set; }

    }

    public interface IAdmin : IUser
    {

    }

}
