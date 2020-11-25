using Microsoft.AspNetCore.Identity;

namespace BlazingCheckers.Server.Data.Entities
{
    public class User : IdentityUser, IEntity
    {
        public object PK => Id;
    }
}