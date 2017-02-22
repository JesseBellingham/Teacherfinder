using Autofac;
using Autofac.Integration.Mvc;
using Teacherfinder.App_Start;
using Teacherfinder.DataLayer;
using Teacherfinder.DataLayer.Interfaces.Repositories;
using Teacherfinder.DataLayer.Repositories;
using Teacherfinder.DataLayer.Services;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Teacherfinder.DataLayer.Interfaces.Services;

namespace Teacherfinder
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterDependencies();

        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<TeacherfinderDataContext>().InstancePerRequest();
            //builder.RegisterType<ApplicationUserManager>().As<ApplicationUserManager>();
            //builder.RegisterType<ApplicationSignInManager>().As<ApplicationSignInManager>();
            builder.RegisterType<LessonRepository>().As<ILessonRepository>();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
            builder.RegisterType<EnrolmentRepository>().As<IEnrolmentRepository>();
            builder.RegisterType<LessonService>().As<ILessonService>();
            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<TeacherService>().As<ITeacherService>();
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>();
            builder.RegisterType<EnrolmentService>().As<IEnrolmentService>();
            builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
