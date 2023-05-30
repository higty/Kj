using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServiceApplication
{
    public class CommandResult
    {
        public string ResultText { get; set; } = "";

        public CommandResult(string resultText)
        {
            ResultText = resultText;
        }
    }
}
