using MarsRovers.Channel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRovers.Channel.Generic.GenericStructure;

namespace MarsRovers.Channel.Implementations
{
    public class Compass : ICompass
    {
        private List<CardinalPoint> _cardinalPoints = new List<CardinalPoint> { CardinalPoint.N, CardinalPoint.E, CardinalPoint.S, CardinalPoint.W };
        
        public CardinalPoint GetNext(CardinalPoint baseCardinalPoint)
        {
            var index = _cardinalPoints.IndexOf(baseCardinalPoint);
            if (index == _cardinalPoints.Count - 1)
                return _cardinalPoints[0];
            else return _cardinalPoints[index + 1];
        }
        public CardinalPoint GetPrevious(CardinalPoint baseCardinalPoint)
        {
            var index = _cardinalPoints.IndexOf(baseCardinalPoint);
            if (index == 0)
                return _cardinalPoints[_cardinalPoints.Count -1 ];
            else return _cardinalPoints[index - 1];
        }
        public List<CardinalPoint> ToList()
        {
            return _cardinalPoints;
        }

      
    }
}
