using RootDb.DataItems;

namespace RootDb.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public string Email { get; set; }
    }
}
