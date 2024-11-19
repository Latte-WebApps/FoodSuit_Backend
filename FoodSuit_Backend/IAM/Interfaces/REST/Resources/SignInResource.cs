namespace FoodSuit_Backend.IAM.Interfaces.REST.Resources;

/// <summary>
/// SignInResource 
/// </summary>
/// <param name="Username">
/// The username of the user.
/// </param>
/// <param name="Password">
/// The password of the user.
/// </param>
public record SignInResource(string Username, string Password);