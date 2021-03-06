﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;
using Moq;
using Ninject;
using WebUI.Infrastructure.Concrete;
using WebUI.Infrastructure.Abstract;

namespace WebUI.Infrastructure
{ 
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //put bindings here
            
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            

            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}