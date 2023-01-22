﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Turtle : Animal
    {
        public Turtle(int age, int power, int initiative, int posX, int posY) : base(age, power, initiative, posX, posY)
        {
            Model = "T";
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
        }

        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            Turtle turtle = new Turtle(30, 7, 2, AnimPosX, AnimPosY);
            return turtle;
        }
    }
}