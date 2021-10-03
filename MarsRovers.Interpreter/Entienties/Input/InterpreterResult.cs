using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRovers.Channel.Generic.GenericStructure;

namespace MarsRovers.Channel.Entities.Input
{
    public class InterpreterResult
    {
        public CardinalPoint HedingCardinalPoint{ get; set; }
        public Point Dimension { get; set; }
        public List<Command> Commands { get; set; } = new List<Command>();
    }
}
