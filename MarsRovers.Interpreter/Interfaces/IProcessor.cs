using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Channel.Interfaces
{
    public interface IProcessor
    {
        void Process(IInterpreter interpreter);
    }
}
