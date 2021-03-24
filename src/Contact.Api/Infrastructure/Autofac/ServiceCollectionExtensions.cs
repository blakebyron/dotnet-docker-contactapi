using System;
using System.Collections.Generic;
using Autofac;
using Contact.Api.Infrastructure.MediatR;
using Contact.Api.Infrastructure.AutoMapper;
using Contact.Api.Infrastructure.EntityFramework;
using Microsoft.Extensions.Configuration;

namespace Contact.Api.Infrastructure.Autofac
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// A centralised place for registering all interfaces and modules which help bring the app together
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterApplicationModules(this ContainerBuilder builder, IConfiguration configuration)
        {
            var asm = typeof(Startup).Assembly;
            builder.RegisterModule(new MediatRModule(asm));
            builder.RegisterModule(new AutoMapperModule(asm));
            builder.RegisterModule(new EntityFrameworkModule(configuration));

        }
    }
}

