using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Moq;
using F1App.Domain.Abstract;
using F1App.Domain.Concrete;
using System.Linq;
using System.Web;

namespace F1App.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        private void AddBindings()//Add bindings
        {
            /*Mock Object

            Mock<IPilotRepository> mock = new Mock<IPilotRepository>();
            mock.Setup(m=>m.Pilots).Returns(new List<Pilot>{
                new Pilot { PilotFName = "Lewis", PilotLName = "Hamilton"},
                new Pilot { PilotFName = "Jenson", PilotLName = "Button" },
                new Pilot { PilotFName = "Daniel", PilotLName = "Ricciardo"}
            });*/


            kernel.Bind(typeof(IRepository<>)).To(typeof(BaseRepository<>));
            /*kernel.Bind<IPilotRepository>().To<PilotRepository>();
            kernel.Bind<ITeamRepository>().To<TeamRepository>();
            kernel.Bind<ITeamStandingRpository>().To<TeamStandingRepository>();
            kernel.Bind<IPilotStandingRepository>().To<PilotStandingRepository>();
            kernel.Bind<IResultRepository>().To<ResultRepository>();*/
        }
    }
}