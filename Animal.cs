using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    abstract class Animal
    {
        private int age;
        private int power;
        private int initiative;
        private string model;

        public bool isAlive;

        public enum Direction { Up, Down, Right, Left }

        public int Age { get => age; set => age = value; }
        public int Power { get => power; set => power = value; }
        public int Initiative { get => initiative; set => initiative = value; }
        public string Model { get => model; set => model = value; }

        public Direction Direct { get; set; }
        public Coordinate AnimPos { get; set; }
        public Coordinate OldPos { get; set; }

        public Animal(int age, int power, int initiative, int posX, int posY)
        {
            Age = age;
            Power = power;
            Initiative = initiative;
            AnimPos = new Coordinate(posX, posY);
            OldPos = new Coordinate(posX, posY);
            isAlive = true;
        }

        public Animal Fight(Animal animal)
        {
            if (this.model == "T" || animal.model == "T")
            {
                if(power > animal.power + 3)
                {
                    AnimalsManager.Instance.RemoveAnimal(animal);
                    return this;
                }else if(power + 3 < animal.power)
                {
                    AnimalsManager.Instance.RemoveAnimal(this);
                    return animal;
                }
                else
                {
                    return null;
                }
            }
            else if (power < animal.power || power == animal.power)
            {
                AnimalsManager.Instance.RemoveAnimal(this);
                return animal;
            }
            else
            {
                AnimalsManager.Instance.RemoveAnimal(animal);
                return this;
            }
        }
        public void Move(int speed)
        {
            if(model == "H")
            {
                return;
            }

            SetOldPos(AnimPos.X, AnimPos.Y);

            bool canMove = false;
            while (canMove == false)
            {
                int rand = RandomNumber.GenerateNumber(0, 4);
                switch (rand)
                {
                    case 0:
                        if (TryMove(AnimPos.X, AnimPos.Y - speed))
                        {
                            canMove = true;
                            AnimPos.Y -= speed;
                        }
                        break;
                    case 1:
                        if (TryMove(AnimPos.X, AnimPos.Y + speed))
                        {
                            canMove = true;
                            AnimPos.Y += speed;
                        }
                        break;
                    case 2:
                        if (TryMove(AnimPos.X + speed, AnimPos.Y))
                        {
                            canMove = true;
                            AnimPos.X += speed;
                        }
                        break;
                    case 3:
                        if (TryMove(AnimPos.X - speed, AnimPos.Y))
                        {
                            canMove = true;
                            AnimPos.X -= speed;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (SlotController.Instance.ReturnAnimal(AnimPos.X, AnimPos.Y) != null)
            {
                Animal anim = SlotController.Instance.ReturnAnimal(AnimPos.X, AnimPos.Y);
                Animal winAnimal = Fight(anim);

                if(this.model == "T" || anim.model == "T")
                {
                    if(winAnimal == null)
                    {
                        AnimPos.X = OldPos.X;
                        AnimPos.Y = OldPos.Y;
                    }
                    else
                    {
                        SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
                        SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, winAnimal);
                        Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
                        Console.WriteLine(Model);
                    }
                }
                else
                {
                    SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
                    SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, Fight(anim));
                    Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
                    Console.WriteLine(Model);
                }

            }
            else if (SlotController.Instance.CheckSlotModel(AnimPos.X, AnimPos.Y, this))
            {
                //Second animal position
                int animalPosX = AnimPos.X;
                int animalPosY = AnimPos.Y;

                AnimPos.X = OldPos.X;
                AnimPos.Y = OldPos.Y;

                Reproduction(animalPosX, animalPosY);
            }
            else if (SlotController.Instance.CheckSlotFlower(AnimPos.X, AnimPos.Y))
            {
                SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
                SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, this);
                Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
                Console.WriteLine(Model);
            }
            else
            { 
                    SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
                    SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, this);
                    Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
                    Console.WriteLine(Model);
            }

            
        }
        private void SetOldPos(int posX, int posY)
        {
            OldPos.X = posX;
            OldPos.Y = posY;
        }


        public abstract Animal CreateNew(int AnimPosX, int AnimPosY);
        public bool TryMove(int X, int Y)
        {
            return SlotController.Instance.IsSlot(X, Y);
        }

        public void Reproduction(int animalPosX, int animalPosY)
        {
            bool itsDone = false;
            List<Coordinate> coordinateList = new List<Coordinate>();

            while (itsDone == false)
            {
                int randX = RandomNumber.GenerateNumber(0, 2);
                int randY = RandomNumber.GenerateNumber(0, 2);
                int randAnimal = RandomNumber.GenerateNumber(1, 3);

                if(RandomNumber.GenerateNumber(0,2) == 0)
                {
                    randX *= -1;
                }

                if (RandomNumber.GenerateNumber(0, 2) == 0)
                {
                    randY *= -1;
                }

                switch (randAnimal)
                {
                    case 1:
                        Coordinate coordinateToBlock = new Coordinate(AnimPos.X + randX, AnimPos.Y + randY);

                        if (!coordinateList.Contains(coordinateToBlock))
                        {
                            coordinateList.Add(coordinateToBlock);
                        }

                        if (SlotController.Instance.IsSlotEmpty(AnimPos.X + randX, AnimPos.Y + randY))
                        {
                            var animal = CreateNew(AnimPos.X + randX, AnimPos.Y + randY);
                            AnimalsManager.Instance.AddAnimal(animal);
                            itsDone = true;
                        }
                        break;
                    case 2:
                        Coordinate coordinateToBlock2 = new Coordinate(animalPosX + randX, animalPosY + randY);

                        if (!coordinateList.Contains(coordinateToBlock2))
                        {
                            coordinateList.Add(coordinateToBlock2);

                        }

                        if (SlotController.Instance.IsSlotEmpty(animalPosX + randX, animalPosY + randY))
                        {
                            var animal = CreateNew(animalPosX + randX, animalPosY + randY);
                            AnimalsManager.Instance.AddAnimal(animal);
                            itsDone = true;
                        }
                        break;
                    default:
                        break;
                }

                if (coordinateList.Count == 10)
                {
                    coordinateList.Clear();
                    itsDone = true;
                }

            }



        }

    }
}
