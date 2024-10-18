using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen_U1_Lenguajes.Constants;
using Examen_U1_Lenguajes.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Examen_U1_Lenguajes.Database
{
    public class ExamenSeeder
    {
        public static async Task LoadDataAsync(
        ExamenContext context,
        ILoggerFactory loggerFactory,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager
        )
        {
            try
            {
                await LoadRolesAndUsersAsync(userManager, roleManager, loggerFactory);
                await LoadDepartmentsAsync(loggerFactory, context);
                await LoadJobTitlesAsync(loggerFactory, context);
                await LoadPermissionTypesAsync(loggerFactory, context);
                await LoadRequestsAsync(loggerFactory, context);
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ExamenSeeder>();
                logger.LogError(e, "Error inicializando la data del API");
            }
        }

        public static async Task LoadRolesAndUsersAsync(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        ILoggerFactory loggerFactory
        )
        {
            try
            {
                if (!await roleManager.Roles.AnyAsync())
                {
                    await roleManager.CreateAsync(new IdentityRole(RolesConstant.ADMIN));
                    await roleManager.CreateAsync(new IdentityRole(RolesConstant.RH));
                    await roleManager.CreateAsync(new IdentityRole(RolesConstant.EMPLEADO));
                }

                if (!await userManager.Users.AnyAsync())
                {
                    var userAdmin = new IdentityUser
                    {
                        Email = "admin@empresa.com",
                        UserName = "admin@empresa.com",
                    };

                    var userRecursos = new IdentityUser
                    {
                        Email = "rh@empresa.com",
                        UserName = "rh@empresa.com",
                    };

                    var normalUser = new IdentityUser
                    {
                        Email = "user@empresa.com",
                        UserName = "user@empresa.com",
                    };

                    await userManager.CreateAsync(userAdmin, "Temporal01*");
                    await userManager.CreateAsync(userRecursos, "Temporal01*");
                    await userManager.CreateAsync(normalUser, "Temporal01*");

                    await userManager.AddToRoleAsync(userAdmin, RolesConstant.ADMIN);
                    await userManager.AddToRoleAsync(userRecursos, RolesConstant.RH);
                    await userManager.AddToRoleAsync(normalUser, RolesConstant.EMPLEADO);
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ExamenSeeder>();
                logger.LogError(e.Message);
            }
        }

        public static async Task LoadDepartmentsAsync(ILoggerFactory loggerFactory, ExamenContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/departments.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var departments = JsonConvert.DeserializeObject<List<DepartmentEntity>>(jsonContent);

                // if (!await context.Departments.AnyAsync())
                // {
                //     var user = await context.Users.FirstOrDefaultAsync();

                //     for (int i = 0; i < departments.Count; i++)
                //     {
                //         departments[i].CreatedBy = user.Id;
                //         departments[i].CreatedDate = DateTime.Now;
                //         departments[i].UpdatedBy = user.Id;
                //         departments[i].UpdatedDate = DateTime.Now;
                //     }

                //     context.AddRange(departments);
                //     await context.SaveChangesAsync();
                // }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ExamenSeeder>();
                logger.LogError(e, "Error al ejecutar el Seed de departamentos");
            }
        }

        public static async Task LoadJobTitlesAsync(ILoggerFactory loggerFactory, ExamenContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/job_titles.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var job_titles = JsonConvert.DeserializeObject<List<JobTitleEntity>>(jsonContent);

                // if (!await context.JobTitles.AnyAsync())
                // {
                //     var user = await context.Users.FirstOrDefaultAsync();
                //     for (int i = 0; i < job_titles.Count; i++)
                //     {
                //         job_titles[i].CreatedBy = user.Id;
                //         job_titles[i].CreatedDate = DateTime.Now;
                //         job_titles[i].UpdatedBy = user.Id;
                //         job_titles[i].UpdatedDate = DateTime.Now;
                //     }

                //     context.AddRange(job_titles);
                //     await context.SaveChangesAsync();
                // }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ExamenSeeder>();
                logger.LogError(e, "Error al ejecutar el Seed de JobTitles");
            }
        }

        public static async Task LoadPermissionTypesAsync(ILoggerFactory loggerFactory, ExamenContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/permission_types.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var permissionTypes = JsonConvert.DeserializeObject<List<PermissionTypeEntity>>(jsonContent);

                // if (!await context.Permissions.AnyAsync())
                // {
                //     var user = await context.Users.FirstOrDefaultAsync();
                //     for (int i = 0; i < permissionTypes.Count; i++)
                //     {
                //         permissionTypes[i].CreatedBy = user.Id;
                //         permissionTypes[i].CreatedDate = DateTime.Now;
                //         permissionTypes[i].UpdatedBy = user.Id;
                //         permissionTypes[i].UpdatedDate = DateTime.Now;
                //     }

                //     context.AddRange(permissionTypes);
                //     await context.SaveChangesAsync();
                // }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ExamenSeeder>();
                logger.LogError(e, "Error al ejecutar el Seed de permission_types");
            }
        }

        public static async Task LoadRequestsAsync(ILoggerFactory loggerFactory, ExamenContext context)
        {
            try
            {
                var jsonFilePath = "SeedData/requests.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var requests = JsonConvert.DeserializeObject<List<RequestEntity>>(jsonContent);

                // if (!await context.Requests.AnyAsync())
                // {
                //     var user = await context.Users.FirstOrDefaultAsync();
                //     for (int i = 0; i < requests.Count; i++)
                //     {
                //         requests[i].UserId = user.Id;
                //         requests[i].CreatedBy = user.Id;
                //         requests[i].CreatedDate = DateTime.Now;
                //         requests[i].UpdatedBy = user.Id;
                //         requests[i].UpdatedDate = DateTime.Now;
                //     }

                //     context.AddRange(requests);
                //     await context.SaveChangesAsync();
                // }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ExamenSeeder>();
                logger.LogError(e, "Error al ejecutar el Seed de PostsTags");
            }
        }
    }
}