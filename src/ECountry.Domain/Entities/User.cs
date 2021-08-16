using System;
using System.Collections.Generic;

namespace ECountry.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? MiddleName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        public string PhoneNumber { get; private set; }
        public UserStatus Status { get; private set; }

        private HashSet<Group> _groups;

        public IReadOnlyCollection<Group> Groups => _groups;

        public User(string email, string firstName, string? middleName, string lastName, DateTime dateOfBirth, Gender gender, string phoneNumber, UserStatus status)
        {
            Email = email;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Status = status;
            _groups = new HashSet<Group>();
        }

        public User(string email, string firstName, string lastName, DateTime dateOfBirth, Gender gender, string phoneNumber, UserStatus status) 
            : this(email, firstName, null, lastName, dateOfBirth, gender, phoneNumber, status)
        {           
        }

        private User()
        {
            _groups = new HashSet<Group>();
        }
    }
}
