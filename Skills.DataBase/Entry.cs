﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skills.DataBase.DataAccess;

namespace Skills.DataBase
{
    public static class Entry
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("Skills.DataBase"));
            });

            //Inmemory  Microsoft.EntityFrameworkCore.InMemory
            //services.AddDbContext<AppDbContext>(opt =>
            //   opt.UseInMemoryDatabase("InMem"));


            //services.AddScoped<ICommentContract, CommentService>();

            //services.AddScoped<IFileEntityContract, FileEntityService>();
            //services.AddScoped<INoteContract, NoteService>();
            //services.AddScoped<IParagraphContract, ParagraphService>();
            //services.AddScoped<ITopicContract, TopicService>();

            //services.AddScoped<IGlobalRightContract, GlobalRightService>();
            //services.AddScoped<ILocalRightContract, LocalRightService>();

            return services;
        }
    }
}
