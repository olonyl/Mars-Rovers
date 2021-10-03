using MarsRovers.Channel.Implementations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRovers.Channel.Generic.GenericStructure;

namespace MarsRovers.Channel.Entities
{
    internal class Plateu
    {
        private Point _dimension;
        private List<PlateuCardinalPoint> _plateuCardinalPoints = new List<PlateuCardinalPoint>();
        private CardinalPoint _headingPoint;

        public Point Dimension { get { return _dimension; } }
        public List<PlateuCardinalPoint> CardinalPoints { get { return _plateuCardinalPoints; } }
        public CardinalPoint HeadingPoint { get { return _headingPoint;  } }

        public Plateu(CardinalPoint headingPoint, Point dimension)
        {
            _dimension = dimension;
            _headingPoint = headingPoint;
            BuildMovementDirection(headingPoint);
        }

        public  PlateuCardinalPoint GetPlateuCardinalPoint(CardinalPoint cardinalPoint)
        {
            return _plateuCardinalPoints.First(f => f.CardinalPoint == cardinalPoint);
        }
        private void BuildMovementDirection(CardinalPoint headingCardinalPoint)
        {
            var compass = new Compass();
            var coordinates = compass.ToList();

            var startingCoordinateIndex = coordinates.IndexOf(headingCardinalPoint);
            var currentIndex = 0;

            foreach (var coord in coordinates.Where(e => coordinates.IndexOf(e) >= startingCoordinateIndex).Select(x => x))
            {
                _plateuCardinalPoints.Add(
                    new PlateuCardinalPoint(coord,
                                    compass.GetPrevious(coord),
                                    compass.GetNext(coord), 
                                    currentIndex == 0 || currentIndex == 1 ? 1 : -1,
                                    currentIndex == 0 || currentIndex == 2? Axis.X: Axis.Y
                                    ));
                currentIndex++;
            }
            foreach (var coord in coordinates.Where(e => coordinates.IndexOf(e) < startingCoordinateIndex).Select(x => x))
            {
                _plateuCardinalPoints.Add(new PlateuCardinalPoint(coord, 
                    compass.GetPrevious(coord), 
                    compass.GetNext(coord), 
                    currentIndex == 0 || currentIndex == 3 ? 1 : -1,
                    currentIndex == 0 || currentIndex == 2 ? Axis.X : Axis.Y
                    ));
                currentIndex++;
            }

        }

    }
}
