using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Application.Interface
{
    public interface IMarsRoversCommunicationService
    {
        public String SendCommand(string command);
    }
}
