using Microsoft.AspNetCore.Identity;

namespace LAB5.Models
{
    public class User : IdentityUser
    {
        // Możesz dodać dodatkowe pola do użytkownika, np.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
