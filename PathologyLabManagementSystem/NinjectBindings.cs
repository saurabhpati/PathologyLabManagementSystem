using Ninject;
using Ninject.Modules;
using Services;
using Repositories;

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
        }
    }
}