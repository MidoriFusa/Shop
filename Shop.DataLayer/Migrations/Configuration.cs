namespace Shop.Datalayer.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Shop.DataLayer;
    using Shop.Models;
    using Shop.Models.Database;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.DataLayer.dbcont>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


      
        public void SeedData(dbcont context)
        {
            if (IsSeedExists(context))
            {
                return;
            }

            CreateRoles(context);

            CreateUsers(context);

            context.SaveChanges();
        }

      




        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(Shop.DataLayer.dbcont context)
        {

            this.SeedData(context);
            base.Seed(context);
        }

        /// <summary>
        /// The create roles.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        private static void CreateRoles(dbcont context)
        {
            using (var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context)))
            {

                if (!roleManager.RoleExists(IdentityRoles.SuperUser))
                {
                    roleManager.Create(new IdentityRole(IdentityRoles.SuperUser));
                }


                if (!roleManager.RoleExists(IdentityRoles.Driver))
                {
                    roleManager.Create(new IdentityRole(IdentityRoles.Driver));
                }


                if (!roleManager.RoleExists(IdentityRoles.StoreKeeper))
                {
                    roleManager.Create(new IdentityRole(IdentityRoles.StoreKeeper));
                }


            }
        }

        /// <summary>
        /// The create roles.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        private static void CreateUsers(dbcont context)
        {
            using (var userManager = new UserManager<User>(new UserStore<User>(context)))
            {
                var user = userManager.FindByName(IdentityRoles.SuperUser);
                if (user == null)
                {
                    // Create SuperUser user with password=123456
                    user = new User
                    {
                        UserName = IdentityRoles.SuperUser,
                        //FirstName = IdentityRoles.SuperUser,
                        //LastName = string.Empty,
                        Email = IdentityRoles.SuperUser + "@Shop.firm",
                        //Created = DateTime.UtcNow
                    };
                    IdentityResult result = userManager.Create(user, "123456");

                    // Add User SuperUser to Role SuperUser
                    if (result.Succeeded)
                    {
                        userManager.AddToRole(user.Id, IdentityRoles.SuperUser);
                    }
                }


                user = userManager.FindByName(IdentityRoles.Driver);
                if (user == null)
                {

                    user = new User
                    {
                      
                        UserName = IdentityRoles.Driver,
                        //FirstName = IdentityRoles.CompanyEmployee,
                        //LastName = string.Empty,
                        Email = IdentityRoles.Driver + "@Shop.firm",
                        //Created = DateTime.UtcNow
                    };
                    IdentityResult result = userManager.Create(user, "123456");


                    if (result.Succeeded)
                    {
                        userManager.AddToRole(user.Id, IdentityRoles.Driver);
                    }
                }

                user = userManager.FindByName(IdentityRoles.StoreKeeper);
                if (user == null)
                {
                    // Create Customer user with password=123456
                    user = new User
                    {
                        UserName = IdentityRoles.StoreKeeper,
                        //FirstName = IdentityRoles.StoreKeeper,
                        //LastName = string.Empty,
                        Email = IdentityRoles.StoreKeeper + "@Shop.firm",
                        //Created = DateTime.UtcNow
                    };
                    IdentityResult result = userManager.Create(user, "123456");


                    if (result.Succeeded)
                    {
                        userManager.AddToRole(user.Id, IdentityRoles.StoreKeeper);
                    }
                }


            }
        }

        private static bool IsSeedExists(dbcont context) => context.Users.Any();

    }

      





}


