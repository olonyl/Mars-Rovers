using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRovers.Channel.Generic.GenericStructure;

namespace MarsRovers.Channel.Entities
{
    public class PlateuCardinalPoint
    {
        public CardinalPoint CardinalPoint { get { return _cardinalPoint; } }
        public CardinalPoint Previous { get { return _previous; } }
        public CardinalPoint Next { get { return _next;  } }
        public int Value { get { return _value; } }
        public Axis Axis { get { return _axis;  } }

        private CardinalPoint _cardinalPoint;
        private CardinalPoint _previous;
        private CardinalPoint _next;
        private int _value;
        private Axis _axis;

        public PlateuCardinalPoint(CardinalPoint cardinalPoint, CardinalPoint previous,CardinalPoint next,int value,Axis axis)
        {
            _cardinalPoint = cardinalPoint;
            _previous = previous;
            _next = next;
            _value = value;
            _axis = axis;
        }
    }
}
