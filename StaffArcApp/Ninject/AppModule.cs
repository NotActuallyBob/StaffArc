using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using StaffArcCore.Loggers;
using StaffArcCore.Services;
using StaffArcApp.ViewModels;

namespace StaffArcApp.Ninject
{
    internal class AppModule : NinjectModule
    {
        public override void Load()
        {
            Bind<MyLogger>().ToSelf().InSingletonScope().WithConstructorArgument("StaffArcLog.txt");
            Bind<IEmployeeService>().To<FileEmployeeService>().WithConstructorArgument("D:\\StaffArc");
            Bind<EmployeeViewModel>().ToSelf();
        }
    }
}
