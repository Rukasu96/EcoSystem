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
        

        public Enviro()
        {
        }

        private int SetValue()
        {
            int value = 0;
            bool isCorrect = false;
            do
            {
                string input;
                input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    return result;
                    isCorrect = true;
                }
                else
                {
                    Console.WriteLine("Niewłaściwa wartość");
                };

            } while (isCorrect);

            return value;
            
        }


        public void Draw()
        {
            Console.Write("Podaj szerokość: ");
            this.width = SetValue();
            Console.Write("Podaj wysokość: ");
            this.height = SetValue();

            int row = 0;

            for (int i = 0; i < width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
                Console.SetCursorPosition(i, height - 1);
                Console.Write("-");
            }

            for (int j = 0; j < height; j++)
            {
                Console.SetCursorPosition(0, j);
                Console.Write("|");
                Console.SetCursorPosition(width, j);
                Console.Write("|");

                row++;
                for (int k = 1; k < width; k++)
                {
                    if (row >= height - 1)
                    {
                        break;
                    }

                    Console.SetCursorPosition(k, row);
                    SlotController.Instance.AddSlot(k, row);
                    Console.Write("X");
                }
            }

        }

        


    }
}
