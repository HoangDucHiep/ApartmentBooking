using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookify.Domain.Entities.Abstractions;
using Bookify.Domain.Entities.Users.Events;

namespace Bookify.Domain.Entities.Users;

public sealed class User(Guid id, FirstName firstName, LastName lastName, Email email) : Entity(id)
{
    public FirstName FirstName { get; private set; } = firstName;
    public LastName LastName { get; private set; } = lastName;
    public Email Email { get; private set; } = email;

    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}