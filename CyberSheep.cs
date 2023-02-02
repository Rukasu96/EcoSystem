using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class CyberSheep : Animal
    {
        public CyberSheep(int age, int power, int initiative) : base(age, power, initiative)
        {
            Model = "C";
            Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
        }
        public CyberSheep(int age, int power, int initiative, int posX, int posY) : base(age, power, initiative, posX, posY)
        {
            Model = "C";
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
            AnimalsManager.Instance.AddAnimal(this);
        }

        public void MoveCyberSheep(int speed)
        {
            SetOldPos(AnimPos.X, AnimPos.Y);

            bool canMove = false;
            Flower hogweed = FindPlant();

            if (hogweed != null)
            {
                while (canMove == false)
                {
                    int rand = RandomNumber.GenerateNumber(0, 2);
                    switch (rand)
                    {
                        case 0:
                            if (hogweed.FlowerPos.X > this.AnimPos.X)
                            {
                                if (TryMove(AnimPos.X + speed, AnimPos.Y))
                                {
                                    canMove = true;
                                    AnimPos.X += speed;
                                }
                            }
                            else if (hogweed.FlowerPos.X < this.AnimPos.X)
                            {
                                if (TryMove(AnimPos.X - speed, AnimPos.Y))
                                {
                                    canMove = true;
                                    AnimPos.X -= speed;
                                }
                            }
                            break;
                        case 1:
                            if (hogweed.FlowerPos.Y > this.AnimPos.Y)
                            {
                                if (TryMove(AnimPos.X, AnimPos.Y + speed))
                                {
                                    canMove = true;
                                    AnimPos.Y += speed;
                                }
                            }
                            else if (hogweed.FlowerPos.Y < this.AnimPos.Y)
                            {
                                if (TryMove(AnimPos.X, AnimPos.Y - speed))
                                {
                                    canMove = true;
                                    AnimPos.Y -= speed;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

                if (SlotController.Instance.ReturnAnimal(AnimPos.X, AnimPos.Y) != null)
                {
                    Animal anim = SlotController.Instance.ReturnAnimal(AnimPos.X, AnimPos.Y);

                    if (Model == anim.Model)
                    {
                        //Second animal position
                        int animalPosX = AnimPos.X;
                        int animalPosY = AnimPos.Y;

                        AnimPos.X = oldPos.X;
                        AnimPos.Y = oldPos.Y;

                        Reproduction(animalPosX, animalPosY);
                    }
                    else
                    {
                        Animal winAnimal = Fight(anim);
                        MakeMove(AnimPos.X, AnimPos.Y, winAnimal, true);
                    }

                }
                else
                {
                    MakeMove(AnimPos.X, AnimPos.Y, this, true);
                }
            }
            else
            {
                Move(1);
            }

        }

        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            CyberSheep cyberSheep = new CyberSheep(99, 8, 5, AnimPosX, AnimPosY);
            return cyberSheep;
        }

        public override Animal UseSkill(Animal animal)
        {
            return null;
        }
    }
}
