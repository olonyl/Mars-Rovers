using MarsRovers.Channel.Entities;
using MarsRovers.Channel.Entities.Input;
using MarsRovers.Channel.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRovers.Channel.Generic.GenericStructure;

namespace MarsRovers.Channel.Implementations
{
    internal class Expedition : IExpedition
    {
        private Rover _rover;
        public Rover Rover { get { return _rover;  }  }

        public Expedition(Rover rover)
        {
            _rover = rover?? throw new ArgumentNullException(nameof(rover));
        }

        public void ExecuteExpedition(Coordinate coordinate, List<Movement> movements)
        {
            _rover.SetStartingPoint(coordinate);
            foreach(var movement in (movements))
            {
                if (movement == Movement.L)
                    _rover.TurnLeft();
                else if (movement == Movement.R)
                    _rover.TurnRight();
                else if (movement == Movement.M)
                    _rover.Move();
                else throw new InvalidOperationException($"This command for the rover {_rover.Id} is not programmed yet");
            }
        }

        public string RetrieveLocation()
        {
            return $"{_rover.CurrentCoordinate.Point.X} {_rover.CurrentCoordinate.Point.Y} {_rover.CurrentCoordinate.CardinalPoint.ToString()}";
        }
    }
}
