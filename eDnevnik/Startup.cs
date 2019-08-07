using eDnevnik.Infrastructure;
using eDnevnik.Models;
using eDnevnik.Services;
using eDnevnik.Providers;
using eDnevnik.Repositories;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

[assembly: OwinStartup(typeof(eDnevnik.Startup))]
namespace eDnevnik
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = SetupUnity();
            HttpConfiguration config = new HttpConfiguration
            {
                DependencyResolver = new UnityDependencyResolver(container)
            };
            ConfigureOAuth(app, container);
           
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            GlobalConfiguration.Configuration.EnsureInitialized();
        }

        public void ConfigureOAuth(IAppBuilder app, UnityContainer container)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(container)
            };
            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
        private UnityContainer SetupUnity()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<DbContext, AuthContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IAuthRepository, AuthRepository>();

            container.RegisterType<IGenericRepository<User>, GenericRepository<User>>();
            container.RegisterType<IGenericRepository<Admin>, GenericRepository<Admin>>();
            container.RegisterType<IGenericRepository<Mark>, GenericRepository<Mark>>();
            container.RegisterType<IGenericRepository<Parent>, GenericRepository<Parent>>();
            container.RegisterType<IGenericRepository<Pupil>, GenericRepository<Pupil>>();
            container.RegisterType<IGenericRepository<Subject>, GenericRepository<Subject>>();
            container.RegisterType<IGenericRepository<Teacher>, GenericRepository<Teacher>>();
            container.RegisterType<IGenericRepository<Class>, GenericRepository<Class>>();
            container.RegisterType<IGenericRepository<TeacherClass>, GenericRepository<TeacherClass>>();

            container.RegisterType<ITeachersService, TeachersService>();
            container.RegisterType<IClassesService, ClassesService>();
            
            return container;
        }
    }
}