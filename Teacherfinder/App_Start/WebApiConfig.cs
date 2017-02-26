namespace Teacherfinder.App_Start
{
    using Autofac;
    using Autofac.Integration.WebApi;
    using DataLayer.Services;
    using Newtonsoft.Json.Serialization;
    using System.Reflection;
    using System.Web.Http;
    using DataLayer.Repositories;
    using DataLayer.Interfaces.Repositories;
    using DataLayer;
    using Autofac.Integration.Mvc;
    using DataLayer.Interfaces.Services;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.MapHttpAttributeRoutes();
            
            #region Lessons
            config.Routes.MapHttpRoute
            (
                name: "GetLessons",
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
                constraints: new { classId = @"\d+" }
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

            #region Persons
            config.Routes.MapHttpRoute
            (
                name: "GetPerson",
                routeTemplate: "api/{controller}/{action}/{personId}",
                defaults: new { controller = "Person", action = "Get" },
                constraints: new { personId = @"\d+" }
            );

            config.Routes.MapHttpRoute
            (
                name: "UpdateLocation",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "Person", action = "UpdateLocation" }
            );
            #endregion

            #region Dependency Injection
            var builder = new ContainerBuilder();
            
            builder.RegisterType<TeacherfinderDataContext>().InstancePerRequest();
            builder.RegisterType<LessonRepository>().As<ILessonRepository>();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<EnrolmentRepository>().As<IEnrolmentRepository>();
            builder.RegisterType<LessonService>().As<ILessonService>();
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<EnrolmentService>().As<IEnrolmentService>();
            builder.RegisterType<TeacherService>().As<ITeacherService>();
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>();
            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new AutofacWebTypesModule());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            #endregion
        }
    }
}