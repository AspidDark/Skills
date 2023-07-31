using Skills.DataBase;
using Microsoft.OpenApi.Models;
using Skills.Identity;
using Skills.Services;
using Swashbuckle.AspNetCore.Filters;
using Skills.Options;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;

        builder.Services.AddControllers();

        builder.Services.AddIdentity(configuration);

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Skills", Version = "v1" });
        });
        builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

        builder.Services.AddAutoMapper(cfg => cfg.AddMaps(new[]
        {
                "Skills",
        }));

        builder.Services.AddDataAccess(configuration);

        builder.Services.AddControllers()
            .AddJsonOptions(o => o.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.Preserve);


        builder.Services.AddOptions<FilePathOptions>()
            .Bind(builder.Configuration.GetSection(FilePathOptions.Path))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        builder.Services.AddScoped<ICharacterService, CharacterService>();
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<IFileHelper, FileHelper>();
        builder.Services.AddScoped<ISkillImageService, SkillImageService>();

        //+Front
        builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }));


        var app = builder.Build();

        //+Front
        app.UseCors("MyPolicy");
        app.UseCors();
        //-Front

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skills v1");
            });
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseIdentityServer();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.MapFallbackToFile("index.html");

        app.Run();
    }
}

//Привести в порядок Фронт:
// Загрузку фото
// Верстку
//Рефакторить фронт

//Бэк/Фронт
//Подятягивать стартовые настройки страницы c бэка
//Авторизация Гугл почта то се
//Подгружать данные на страницу