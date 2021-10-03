using MarsRovers.Channel.Entities.Input;
using MarsRovers.Channel.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRovers.Channel.Generic.GenericStructure;

namespace MarsRovers.Channel.Entities
{
    internal class Rover: IVehicle
    {

        #region Properties
        public string Id { get; private set; }
        public Plateu Plateu { get { return _plateu; } }
        public Coordinate CurrentCoordinate { get { return _currentCoordinate;  } }
        #endregion
        private Coordinate _currentCoordinate;
        private Plateu _plateu;
        private Boolean _isStartingPointDefined = false;
        public Rover( Plateu plateu)
        {
            _plateu = plateu ?? throw new ArgumentNullException(nameof(plateu));
            Id = Guid.NewGuid().ToString();
        }
        
        public void SetStartingPoint(Coordinate coordinate) {
            _currentCoordinate = coordinate;
            _isStartingPointDefined = true;
        }

        public void Move()
        {
            ValidateRequiredValues();            
            var plateuCardinalPoint = _plateu.GetPlateuCardinalPoint(_currentCoordinate.CardinalPoint);
            if (plateuCardinalPoint.Axis == Axis.X)
                _currentCoordinate.SetY(_currentCoordinate.Point.Y + plateuCardinalPoint.Value);
            else _currentCoordinate.SetX(_currentCoordinate.Point.X + plateuCardinalPoint.Value);
        }

        public void TurnLeft()
        {
            ValidateRequiredValues();
            _currentCoordinate.SetCardinalPoint(_plateu.GetPlateuCardinalPoint(_currentCoordinate.CardinalPoint).Previous);
        }

        public void TurnRight()
        {
            ValidateRequiredValues();
            _currentCoordinate.SetCardinalPoint(_plateu.GetPlateuCardinalPoint(_currentCoordinate.CardinalPoint).Next);
        }        
        private void ValidateRequiredValues()
        {
            if (!_isStartingPointDefined) throw new NullReferenceException($"The function {nameof(SetStartingPoint)} needs to be called before executing any movement");
        }
    }
}
