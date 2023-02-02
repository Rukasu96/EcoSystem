using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class Enviro
    {
        private int width;
        private int height;

        public void Draw()
        {
            bool isOk = false;
            do
            {
                width = SetValue("Podaj szerokość (min 5): ");
                height = SetValue("Podaj wysokość (min 5): ");

                if(width * height >= 25)
                {
                    isOk = true;
                }
                else
                {
                    Console.WriteLine("Pole jest za małe!");
                }

            } while (!isOk);

            Console.Clear();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Write(i, j, "X");
                    SlotController.Instance.AddSlot(i, j);
                }
            }

        }

        private int SetValue(string sentence)
        {
            int value = 0;
            bool isCorrect = false;

            while (!isCorrect)
            {
                Console.Write(sentence);

                string input;
                input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if( result >= 5)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Za mała wartość");
                    }
                }
                else
                {
                    Console.WriteLine("Niewłaściwa wartość");
                }
            } 

            return value;

        }

        private void Write(int x, int y, string model)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(model);
        }

    }
}
