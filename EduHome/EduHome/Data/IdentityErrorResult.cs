using Microsoft.AspNetCore.Identity;

namespace EduHome.Data
{
    public class IdentityErrorResult : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = "Email",
                Description = "Bu email-de user istifade olunub."
            };
        }
    }
}
