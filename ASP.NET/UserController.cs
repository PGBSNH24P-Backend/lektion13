using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly UserManager<UserEntity> userManager;

    public UserController(UserManager<UserEntity> userManager)
    {
        this.userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
    {
        var userEntity = new UserEntity(request.UserName, request.Email, request.FavoriteFood);
        // Alternativt:
        //userEntity.UserName = request.UserName;
        //userEntity.Email = request.Email;

        var result = await userManager.CreateAsync(userEntity, request.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        await userManager.AddToRoleAsync(userEntity, "owner");

        return Ok();
    }
}

public class RegisterUserRequest
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public required string FavoriteFood { get; set; }
}