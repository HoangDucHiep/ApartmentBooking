using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookify.Domain.Entities.Abstractions;

namespace Bookify.Domain.Entities.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;