﻿using MarsRovers.Channel.Entities.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRovers.Channel.Generic.GenericStructure;

namespace MarsRovers.Channel.Interfaces
{
    public interface IExpedition
    {
        public void ExecuteExpedition(Coordinate coordinate,List<Movement> movements);
        public string RetrieveLocation();

    }
}
