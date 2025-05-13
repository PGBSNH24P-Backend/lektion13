using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// Om vi vill använda vår egna user model, vilket man nästan alltid vill
// kan vi ange den som generisk typ: <UserEntity>
// Man kan även lägga till en egen model för roller: <UserEntity, RoleEntity>
public class AppDbContext : IdentityDbContext<UserEntity>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}