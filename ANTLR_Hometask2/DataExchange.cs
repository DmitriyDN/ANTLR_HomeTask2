
using Antlr4.Runtime;

namespace ANTLR_Hometask2
{
    public class DataExchange: IDataExchange
    {
        private IConsoleReadWrite _consoleDataExchange;

        public DataExchange(IConsoleReadWrite consoleReadWrite)
        {
            _consoleDataExchange = consoleReadWrite;
        }

        public AntlrInputStream ReadData()
        {
            var input = _consoleDataExchange.ReadLine();
            return new AntlrInputStream(input);
        }
    }
}
