using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using OnlineShop.Domain.Abstract;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Concrete;
using System.Configuration;

namespace OnlineShop.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel kernel;
        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBinding();
        }
        private void AddBinding()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            EmailSettings set = new EmailSettings { writeAsFie = Boolean.Parse(ConfigurationManager.AppSettings["Email.writeAsFie"] ?? "false") };
            kernel.Bind<IOrderProcesore>().To<EmailOrderProcessor>().WithConstructorArgument("sett");
            
        }

        private void NewMethod()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns(new List<Product>
            {
                new Product{Name="Book", Price=6550},
                new Product{Name="Book", Price=6550},
                new Product{Name="Book", Price=6550},
                new Product{Name="Book", Price=6550},
                new Product{Name="Book", Price=6550}
            }.AsQueryable()
                );
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
    }
}