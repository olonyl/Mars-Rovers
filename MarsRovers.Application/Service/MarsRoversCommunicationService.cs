using MarsRovers.Application.Interface;
using MarsRovers.Channel.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Application.Service
{
    public class MarsRoversCommunicationService : IMarsRoversCommunicationService
    {
        public string SendCommand(string command)
        {
            var interpreter = new Interpreter(command);
            var processor = new Processor();
            processor.Process(interpreter);
            return processor.GetResults();
        }
    }
}
