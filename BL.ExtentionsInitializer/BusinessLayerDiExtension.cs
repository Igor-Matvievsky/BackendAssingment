using AutoMapper;
using AutoMapperConfiguration;
using DL.Entities;
using DL.ExtentionInitializer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BL.ApiInterfaces;
using BL.ApiServices;

namespace BL.ExtentionsInitializer
{
    public static class BusinessLayerDiExtension
    {
        public static void RegisterBusinessLayerDependency(this IServiceCollection services)
        {
            services.RegisterDataLayerDependency();

            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuestionService, QuestionService>();

            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);
        }
    }
}
