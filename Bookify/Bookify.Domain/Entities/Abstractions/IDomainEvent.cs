using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Bookify.Domain.Entities.Abstractions;
public interface IDomainEvent : INotification
{
}
