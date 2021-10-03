using MarsRovers.Channel.Entities;
using MarsRovers.Channel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.Channel.Implementations
{
    public class Processor : IProcessor
    {
        private StringBuilder _strResult = new StringBuilder();

        public void Process(IInterpreter interpreter)
        {
            var result = interpreter.Convert();
            foreach(var item in result.Commands)
            {
                var plateu = new Plateu(result.HedingCardinalPoint, result.Dimension);
                var rover = new Rover(plateu);
                var expedition = new Expedition(rover);
                expedition.ExecuteExpedition(item.Coordinate,item.Movements);
                _strResult.AppendLine(expedition.RetrieveLocation());
            }
        }

        public string GetResults()
        {
            return _strResult.ToString();
        }
    }
}
