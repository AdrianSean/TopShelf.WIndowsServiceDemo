using HelloWorldLibrary;
using Ninject.Modules;

namespace TopShelf.WindowsService.UsingNinject
{
    public class NinjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IDoSomeStuff>().To<DoSomeStuffInstanceClass>();
        }
    }
}
