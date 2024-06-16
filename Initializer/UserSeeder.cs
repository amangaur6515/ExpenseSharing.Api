using Microsoft.AspNetCore.Identity;

namespace ExpenseSharing.Api.Initializer
{
    public class UserSeeder
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserSeeder(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task SeedAsync()
        {
            var users = new List<IdentityUser>
            {

                new IdentityUser
                {
                    UserName = "nedstark@gmail.com",
                    Email = "nedstark@gmail.com",


                },
                new IdentityUser
                {
                    UserName = "robert@gmail.com",
                    Email = "robert@gmail.com",


                },
                new IdentityUser
                {
                    UserName = "joffery@gmail.com",
                    Email = "joffery@gmail.com",


                },
                
                new IdentityUser
                {
                    UserName = "stannis@gmail.com",
                    Email = "stannis@gmail.com",


                },
                
                new IdentityUser
                {
                    UserName = "walder@gmail.com",
                    Email = "walder@gmail.com",


                },
                new IdentityUser
                {
                    UserName = "robb@gmail.com",
                    Email = "robb@gmail.com",


                },
                new IdentityUser
                {
                    UserName = "tyrion@gmail.com",
                    Email = "tyrion@gmail.com",


                },
                new IdentityUser
                {
                    UserName = "sansa@gmail.com",
                    Email = "sansa@gmail.com",


                },
                new IdentityUser
                {
                    UserName = "arya@gmail.com",
                    Email = "arya@gmail.com",


                },
                new IdentityUser
                {
                    UserName = "cersei@gmail.com",
                    Email = "cersie@gmail.com",


                },
                new IdentityUser
                {
                    UserName = "jamie@gmail.com",
                    Email = "jamie@gmail.com",


                },
                new IdentityUser
                {
                    UserName = "johndoe@gmail.com",
                    Email = "johndoe@gmail.com",


                },
                new IdentityUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",


                },

             };

            foreach (var user in users)
            {
                var result = await _userManager.CreateAsync(user, "Amangaur@12345");
            }

        }
    }
}
