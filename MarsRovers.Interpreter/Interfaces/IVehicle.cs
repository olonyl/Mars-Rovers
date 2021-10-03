using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Channel.Interfaces
{
    public interface IVehicle
    {
        public void TurnLeft();
        public void TurnRight();
        public void Move();
    }
}
