﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class TurnBasedController
    {

        public TurnBasedController()
        {
        }

        public void StartTurn(List<Animal> animals)
        {
            var group = animals.OrderByDescending(x => x.Initiative).ThenByDescending(x => x.Age).ToList();
            group.ForEach(x => x.Move());
        }
        




    }
}
