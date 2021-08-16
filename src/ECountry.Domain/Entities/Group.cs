using System.Collections.Generic;

namespace ECountry.Domain.Entities
{
    public class Group : Entity
    {
        public string Name { get; private set; }

        private HashSet<User> _users;

        private Group()
        {
            _users = new HashSet<User>()
        }
    }
}
