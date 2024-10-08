using HairSalon.Contract.Repositories.Entity;
using HairSalon.Contract.Repositories.Interface;
using HairSalon.Repositories.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Repositories.SeedData
{
    public class RoleSeeder
    {
        public static async Task SeedRoles(IUnitOfWork unitOfWork)
        {
            var roleRepository = unitOfWork.GetRepository<ApplicationRoles>();

            if (await roleRepository.Entities.AnyAsync())
            {
                return; // Roles already seeded
            }

            var roles = new List<ApplicationRoles>
            {
                new ApplicationRoles
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    CreatedBy = "System",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationRoles
                {
                    Id = Guid.NewGuid(),
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                    CreatedBy = "System",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationRoles
                {
                    Id = Guid.NewGuid(),
                    Name = "Stylist",
                    NormalizedName = "STYLIST",
                    CreatedBy = "System",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                },
                new ApplicationRoles
                {
                    Id = Guid.NewGuid(),
                    Name = "User",
                    NormalizedName = "USER",
                    CreatedBy = "System",
                    CreatedTime = DateTimeOffset.UtcNow,
                    LastUpdatedTime = DateTimeOffset.UtcNow
                }
            };

            foreach (var role in roles)
            {
                await roleRepository.InsertAsync(role);
            }

            await unitOfWork.SaveAsync();
        }

        public static async Task SeedAdminUser(IUnitOfWork unitOfWork)
        {
            var accountRepository = unitOfWork.GetRepository<ApplicationUsers>();
            var roleRepository = unitOfWork.GetRepository<ApplicationRoles>();
            var userRoleRepository = unitOfWork.GetRepository<ApplicationUserRoles>();

            // Check if the admin user already exists
            var existingAdminUser = await accountRepository.Entities.FirstOrDefaultAsync(x => x.UserName == "admin");
            if (existingAdminUser != null)
            {
                Console.WriteLine("Admin user already exists.");
                return;
            }

            // Find the Admin role
            var adminRole = await roleRepository.Entities.FirstOrDefaultAsync(r => r.Name == "Admin");
            if (adminRole == null)
            {
                throw new Exception("Admin role does not exist. Please seed roles first.");
            }

            // Create user information
            var userInfo = new UserInfo
            {
                Firstname = "Admin",
                Lastname = "User"
            };

            // Create the new admin account
            var adminUser = new ApplicationUsers
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Email = "admin@example.com",
                PhoneNumber = "123456789",
                PasswordHash = "123", // Ideally, hash the password here
                SecurityStamp = Guid.NewGuid().ToString(),
                UserInfo = userInfo,
                CreatedBy = "System",
                CreatedTime = DateTimeOffset.UtcNow,
                LastUpdatedTime = DateTimeOffset.UtcNow
            };

            // Insert the admin user into the database
            await accountRepository.InsertAsync(adminUser);
            await unitOfWork.SaveAsync();

            // Assign the admin role to the admin user
            var adminUserRole = new ApplicationUserRoles
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id,
                CreatedBy = "System",
                CreatedTime = DateTime.UtcNow,
                LastUpdatedBy = "System",
                LastUpdatedTime = DateTime.UtcNow
            };

            await userRoleRepository.InsertAsync(adminUserRole);
            await unitOfWork.SaveAsync();
        }
    }
}
