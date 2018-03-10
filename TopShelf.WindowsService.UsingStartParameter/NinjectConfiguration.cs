using HelloWorldLibrary;
using Ninject.Modules;

namespace TopShelf.WindowsService.UsingNinject
{
    public class NinjectConfiguration : NinjectModule
    {
        readonly string _startParam;

        public NinjectConfiguration(string startParam)
        {
            _startParam = startParam;
        }

        public override void Load()
        {
            Bind<IDoSomeStuff>().To<DoSomeStuffInstanceClass>().WithConstructorArgument(_startParam);
        }
    }
}
