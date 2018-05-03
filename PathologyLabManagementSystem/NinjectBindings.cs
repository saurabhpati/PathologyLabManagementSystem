using Ninject.Modules;
using Repositories;
using Services;

namespace PathologyLabManagementSystem
{
    public class NinjectBindings: NinjectModule
    {
        public override void Load()
        {
            Bind<ITestService>().To<TestService>();
            Bind<ITestRepository>().To<TestRepository>();
            Bind<ITestCommentService>().To<TestCommentService>();
            Bind<ITestCommentRepository>().To<TestCommentRepository>();
            Bind<ITestAttributeService>().To<TestAttributeService>();
            Bind<ITestAttributeRepository>().To<TestAttributeRepository>();
            Bind<IPatientService>().To<PatientService>();
            Bind<IPatientRepository>().To<PatientRepository>();
        }
    }
}