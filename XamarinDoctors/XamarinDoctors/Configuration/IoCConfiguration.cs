using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinDoctors.ViewModels;

namespace XamarinDoctors.Configuration
{
    public class IoCConfiguration
    {
        private IContainer container;
        public DoctorsViewModel DoctorsViewModel
        {
            get
            {
                return container.Resolve<DoctorsViewModel>();
            }
        }
        public IoCConfiguration()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<DoctorsViewModel>();
            container = builder.Build();
        }
    }
}
