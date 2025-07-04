using System.Data;

namespace Bookify.Application.Abstractions.Data;

public interface ISqlConnectFactory
{
    IDbConnection CreateConnection();
}