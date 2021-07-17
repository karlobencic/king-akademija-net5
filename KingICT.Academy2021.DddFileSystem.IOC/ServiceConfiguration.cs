﻿using AutoMapper;
using KingICT.Academy2021.DddFileSystem.Contract;
using KingICT.Academy2021.DddFileSystem.Model.Repositories;
using KingICT.Academy2021.DddFileSystem.Repository;
using KingICT.Academy2021.DddFileSystem.Service;
using KingICT.Academy2021.DddFileSystem.Service.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KingICT.Academy2021.DddFileSystem.IOC
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureApplicationServices(services, configuration);
            ConfigureRepositories(services, configuration);
        }

        private static void ConfigureApplicationServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IFolderService, FolderService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FileMappingProfile());
                mc.AddProfile(new FolderMappingProfile());
            });

            services.AddSingleton(mappingConfig.CreateMapper());
        }

        private static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
        {
            var dbConfig = configuration.GetSection(nameof(DbConfig)).Get<DbConfig>();
            services.AddDbContext<KingAcademyDbContext>(options =>
            {
                options.UseSqlServer(dbConfig.ConnectionString);
            });

            services.AddTransient<IFolderRepository, FolderRepository>();
        }
    }
}
