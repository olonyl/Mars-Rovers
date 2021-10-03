using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRovers.Channel.Generic.GenericStructure;

namespace MarsRovers.Channel.Entities.Input
{
    public class Coordinate
    {
        private Point _point;
        private CardinalPoint _cardinalPoint;

        public Coordinate(Point point, CardinalPoint cardinalPoint)
        {
            _point= point;
            _cardinalPoint= cardinalPoint;
        }

        public Coordinate(string strCoordinate)
        {
            Coordinate coordinate = TryToConvertStringIntoCoordinate(strCoordinate);

            _point.X = coordinate.Point.X;
            _point.Y = coordinate.Point.Y;
            _cardinalPoint = coordinate.CardinalPoint;
        }
        private static Coordinate TryToConvertStringIntoCoordinate(string coordinate) {
            var lstCoordinate = coordinate.Split(" ");
            int x, y;
            CardinalPoint cardinal;

            if (lstCoordinate.Count() != 3 || coordinate.Trim() == string.Empty) throw new ArgumentException($"This is not a valid coordinate {coordinate}, {Environment.NewLine}example: {Environment.NewLine}1 1 N");
            if (!int.TryParse(lstCoordinate[0], out x)) throw new ArgumentException($"First value in the string must be int, instead value is {lstCoordinate[0]}");
            if (!int.TryParse(lstCoordinate[1], out y)) throw new ArgumentException($"Second value in the string must be int, instead value is {lstCoordinate[1]}");
            if (!Enum.TryParse<CardinalPoint>(lstCoordinate[2], out cardinal)) throw new ArgumentException($"Third value in the string must be a Cardinal Point [N,E,S,W], instead value is {lstCoordinate[2]}");

            return new Coordinate(new Point(x, y), cardinal);
        }
        public override string ToString()
        {
            return $"{_point.X} {_point.Y} {_cardinalPoint.ToString()}";
        }
        public void SetX(int x) {
            _point.X = x;
        }
        public void SetY(int y)
        {
            _point.Y = y;
        }
        public void SetCardinalPoint(CardinalPoint cardinalPoint)
        {
            _cardinalPoint = cardinalPoint;
        }
        public Point Point { get { return _point; } }
        public CardinalPoint CardinalPoint { get { return _cardinalPoint; } }
    }
}
