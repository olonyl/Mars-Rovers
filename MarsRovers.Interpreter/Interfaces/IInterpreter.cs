using MarsRovers.Channel.Entities.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Channel.Interfaces
{
    public interface IInterpreter
    {
        public InterpreterResult Convert();
    }
}
