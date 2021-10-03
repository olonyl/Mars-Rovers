using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRovers.Channel.Generic.GenericStructure;

namespace MarsRovers.Channel.Entities.Input
{
    public class Command
    {
        private Coordinate _coordinate { get; set; }
        private List<Movement> _movements { get; set; } = new List<Movement>();

        public Command(Coordinate coordinate, List<Movement> movements)
        {
            Coordinate = coordinate;
            Movements = movements;
        }
        public Command(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }

        public override string ToString()
        {
            return $"{_coordinate.ToString()}{Environment.NewLine}{string.Join(string.Empty,_movements)}";
        }
        public Coordinate Coordinate { get; set; }
        public List<Movement> Movements { get; set; } = new List<Movement>();
    }
}
