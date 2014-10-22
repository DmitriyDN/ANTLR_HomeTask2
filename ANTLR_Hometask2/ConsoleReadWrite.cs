
using System;

namespace ANTLR_Hometask2
{
    public class ConsoleReadWrite: IConsoleReadWrite
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
