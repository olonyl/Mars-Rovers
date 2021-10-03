using System.Collections.Generic;
using static MarsRovers.Channel.Generic.GenericStructure;

namespace MarsRovers.Channel.Interfaces
{
    public interface ICompass
    {
        public CardinalPoint GetNext(CardinalPoint baseCardinalPoint);
        public CardinalPoint GetPrevious(CardinalPoint baseCardinalPoint);
        public List<CardinalPoint> ToList();
    }
}