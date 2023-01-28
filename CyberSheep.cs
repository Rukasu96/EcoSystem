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
            }

            if (SlotController.Instance.ReturnAnimal(AnimPos.X, AnimPos.Y) != null)
            {
                Animal anim = SlotController.Instance.ReturnAnimal(AnimPos.X, AnimPos.Y);
                Animal winAnimal = Fight(anim);

                if (anim.Model == "T")
                {
                    if (winAnimal == null)
                    {
                        AnimPos.X = OldPos.X;
                        AnimPos.Y = OldPos.Y;
                    }
                    else
                    {
                        /*
                        SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
                        SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, winAnimal);
                        Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
                        Console.WriteLine(Model);
                        */
                        MakeMove();
                    }
                }
                else if (Model == anim.Model)
                {
                    //Second animal position
                    int animalPosX = AnimPos.X;
                    int animalPosY = AnimPos.Y;

                    AnimPos.X = OldPos.X;
                    AnimPos.Y = OldPos.Y;

                    Reproduction(animalPosX, animalPosY);
                }
                else
                {/*
                    SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
                    SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, Fight(anim));
                    Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
                    Console.WriteLine(Model);
                    */
                    MakeMove();
                }

            }
            else if (SlotController.Instance.CheckSlotFlower(AnimPos.X, AnimPos.Y))
            {
                MakeMove();
            }
            else
            {
                MakeMove();
            }

        }

        public override Animal CreateNew(int AnimPosX, int AnimPosY)
        {
            CyberSheep cyberSheep = new CyberSheep(10, 1, 3, AnimPosX, AnimPosY);
            return cyberSheep;
        }
    }
}
