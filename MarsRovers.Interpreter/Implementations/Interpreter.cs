using MarsRovers.Channel.Entities.Input;
using MarsRovers.Channel.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRovers.Channel.Generic.GenericStructure;

namespace MarsRovers.Channel.Implementations
{
    public class Interpreter : IInterpreter
    {
        private InterpreterResult _result= new InterpreterResult();
        private string _testInput;

        public Interpreter(string testInput)
        {
            _testInput = testInput;
        }
        public InterpreterResult Convert()
        {
            var lineNumber = 0;
            var isCommandComplete = false;
            using (StringReader reader = new StringReader(_testInput))
            {
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        lineNumber++;
                        isCommandComplete = false;
                        TryToConvertInputToInterpreterResult(lineNumber, line.Trim());
                    }
                    if (lineNumber == 3) { lineNumber = 1; isCommandComplete = true; }

                } while (line != null);
            }
            if(!isCommandComplete) throw new InvalidOperationException($"This string is not complete{Environment.NewLine}Expected Input:{Environment.NewLine}2 2{Environment.NewLine}1 2 N{Environment.NewLine}LLRRMM{Environment.NewLine}Received Input{Environment.NewLine}{_testInput}");
            return _result;
        }

        private void TryToConvertInputToInterpreterResult(int lineNumber , string content)
        {
            if (lineNumber == 1)
                _result.Dimension = TryToConvertStringToDimension(content);
            else if (lineNumber == 2)
                _result.Commands.Add(new Command(new Coordinate(content)));
            else if (lineNumber == 3)
                _result.Commands.Last().Movements.AddRange(TryToConvertStringToMovements(content));
        }

        private Point TryToConvertStringToDimension(string input)
        {

            var lstCoordinate = input.Split(" ");
            int x, y;

            if (lstCoordinate.Count() != 2 || input.Trim() == string.Empty) throw new ArgumentException($"This is not a valid coordinate {input}, {Environment.NewLine}example: {Environment.NewLine}1 1");
            if (!int.TryParse(lstCoordinate[0], out x)) throw new ArgumentException($"First value in the string must be int, instead value is {lstCoordinate[0]}");
            if (!int.TryParse(lstCoordinate[1], out y)) throw new ArgumentException($"Second value in the string must be int, instead value is {lstCoordinate[1]}");

            return new Point(x, y);
        }
        private List<Movement> TryToConvertStringToMovements(string movements)
        {
            var arrayMovements = movements.ToCharArray();
            var validMovements =arrayMovements.Select(s => Enum.TryParse<Movement>(s.ToString(),out _)).ToList();

            if(arrayMovements.Length == 0) throw new ArgumentException("Empty movement array cannot be processed");
            if (arrayMovements.Count() != validMovements.Count()) throw new ArgumentException($"This is not a valid array {movements}, {Environment.NewLine}correct format example: {Environment.NewLine}LLMMR");

           return  arrayMovements.Select(s => Enum.Parse<Movement>(s.ToString())).ToList();

        }

    }
}
