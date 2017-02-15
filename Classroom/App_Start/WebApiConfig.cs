namespace Classroom.App_Start
{
    using Autofac;
    using Autofac.Integration.WebApi;
    using API;
    using DataLayer.Interfaces;
    using DataLayer.Services;
    using Newtonsoft.Json.Serialization;
    using System.Reflection;
    using System.Web.Http;
    using DataLayer.Repositories;
    using DataLayer.Interfaces.Repositories;
    using DataLayer;
    using Autofac.Integration.Mvc;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.MapHttpAttributeRoutes();
            
            #region Lessones
            config.Routes.MapHttpRoute
            (
                name: "GetLessones",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "Lesson", action = "Get" }
            );

            config.Routes.MapHttpRoute
            (
                name: "CreateLesson",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "Lesson", action = "Create" }
            );

            config.Routes.MapHttpRoute
            (
                name: "UpdateLesson",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "Lesson", action = "Update" }
            );
            #endregion

            #region Enrolments
            config.Routes.MapHttpRoute
            (
                name: "GetStudentEnrolments",
                routeTemplate: "api/{controller}/{action}/{classId}",
                defaults: new { controller = "StudentEnrolment", action = "Get" },
                constraints: new { classId = @"\d+"}
            );

            config.Routes.MapHttpRoute
            (
                name: "CreateEnrolment",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "Enrolment", action = "Create" }
            );
            #endregion

            #region Students
            config.Routes.MapHttpRoute
            (
                name: "CreateStudent",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "Student", action = "Create" }
            );
            #endregion

            #region Dependency Injection
            var builder = new ContainerBuilder();
            
            builder.RegisterType<ClassroomDataContext>().InstancePerRequest();
            builder.RegisterType<LessonRepository>().As<ILessonRepository>();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<EnrolmentRepository>().As<IEnrolmentRepository>();
            builder.RegisterType<LessonService>().As<ILessonService>();
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<EnrolmentService>().As<IEnrolmentService>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new AutofacWebTypesModule());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            #endregion
        }
    }
}