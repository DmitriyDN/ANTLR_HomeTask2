
using Ninject.Modules;

namespace ANTLR_Hometask2
{
    public class CalculatorInjection: NinjectModule
    {
        public override void Load()
        {
            Bind<IConsoleReadWrite>().To<ConsoleReadWrite>();
            Bind<IDataExchange>().To<DataExchange>();
        }
    }
}
