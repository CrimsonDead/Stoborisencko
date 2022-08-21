using Microsoft.AspNetCore.Identity;

namespace datalayer.Models
{
    public class User : IdentityUser
    {
        public List<Car> Cars { get; set; }
        public List<Comment> Comments { get; set; }
    }
}