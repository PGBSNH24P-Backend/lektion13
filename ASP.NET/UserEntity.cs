using Microsoft.AspNetCore.Identity;

public class UserEntity : IdentityUser
{
    public string FavoriteFood { get; set; }

    public UserEntity(string username, string email, string favoriteFood)
    {
        this.FavoriteFood = favoriteFood;
        this.UserName = username;
        this.Email = email;
    }


    public UserEntity()
    {
        this.FavoriteFood = string.Empty;
    }
}