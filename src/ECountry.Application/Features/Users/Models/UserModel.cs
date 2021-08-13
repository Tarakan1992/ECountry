using ECountry.Application.Common.Mappings;
using ECountry.Domain;
using ECountry.Domain.Entities;
using System;

namespace ECountry.Application.Features.Users.Models
{
    public class UserModel : IMapFrom<User>
    {
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string? MiddleName { get; init; }
        public DateTime DateOfBirth { get; init; }
        public Gender Gender { get; init; }
        public string PhoneNumber { get; init; }
        public UserStatus Status { get; init; }
    }
}
