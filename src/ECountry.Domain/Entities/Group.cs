using System.Collections.Generic;

namespace ECountry.Domain.Entities
{
    public class Group : Entity
    {
        public string Name { get; private set; }

        private ICollection<User> _users;
        
        public Group(string name)
        {
            Name = name;
        }

        private Group()
        {
        }
    }
}
