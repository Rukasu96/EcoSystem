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

        public Animal(int age, int power, int initiative)
        {
            Age = age;
            Power = power;
            Initiative = initiative;
            AnimPos = new Coordinate();
            OldPos = new Coordinate();
            SetAnimalPosition();
            isAlive = true;
        }
        public Animal(int age, int power, int initiative, int flowerPosX, int flowerPosY)
        {
            Age = age;
            Power = power;
            Initiative = initiative;
            AnimPos = new Coordinate();
            OldPos = new Coordinate();

            AnimPos.X = flowerPosX;
            AnimPos.Y = flowerPosY;
            isAlive = true;
        }

        public Animal Fight(Animal animal) // Zrobić osobne metody, zastanowić się czy nie da rady oddzielić umiejętności do każej subklasy
        {
            if ((this.model == "F" && this.power < animal.power) || (animal.model == "F" && this.power > animal.power))
            {
                if (RandomNumber.GenerateNumber(0, 2) == 1 && this.model == "F")
                {
                    for (int i = 0; i <= 1; i++)
                    {
                        for (int j = 0; j <= 1; j++)
                        {
                            if (SlotController.Instance.IsSlotEmpty(this.AnimPos.X + i, this.AnimPos.Y + j))
                            {
                                SlotController.Instance.ChangeSlotEmpty(this.AnimPos.X, this.AnimPos.Y);
                                SlotController.Instance.ChangeSlotOccupied(this.AnimPos.X + i, this.AnimPos.Y + j, this);
                                Console.SetCursorPosition(this.AnimPos.X + i, this.AnimPos.Y + j);
                                Console.WriteLine(this.model);
                                break;
                            }
                            else if (SlotController.Instance.IsSlotEmpty(this.AnimPos.X - i, this.AnimPos.Y + j))
                            {
                                SlotController.Instance.ChangeSlotEmpty(this.AnimPos.X, this.AnimPos.Y);
                                SlotController.Instance.ChangeSlotOccupied(this.AnimPos.X - i, this.AnimPos.Y + j, this);
                                Console.SetCursorPosition(this.AnimPos.X - i, this.AnimPos.Y + j);
                                Console.WriteLine(this.model);
                                break;
                            }
                            else if (SlotController.Instance.IsSlotEmpty(this.AnimPos.X + i, this.AnimPos.Y - j))
                            {
                                SlotController.Instance.ChangeSlotEmpty(this.AnimPos.X, this.AnimPos.Y);
                                SlotController.Instance.ChangeSlotOccupied(this.AnimPos.X - i, this.AnimPos.Y + j, this);
                                Console.SetCursorPosition(this.AnimPos.X - i, this.AnimPos.Y + j);
                                Console.WriteLine(this.model);
                                break;
                            }
                            else if (SlotController.Instance.IsSlotEmpty(this.AnimPos.X - i, this.AnimPos.Y - j))
                            {
                                SlotController.Instance.ChangeSlotEmpty(this.AnimPos.X, this.AnimPos.Y);
                                SlotController.Instance.ChangeSlotOccupied(this.AnimPos.X - i, this.AnimPos.Y + j, this);
                                Console.SetCursorPosition(this.AnimPos.X - i, this.AnimPos.Y + j);
                                Console.WriteLine(this.model);
                                break;
                            }
                        }
                    }
                    return animal;
                }
                else if (RandomNumber.GenerateNumber(0, 2) == 1 && animal.model == "F")
                {
                    for (int i = 0; i <= 1; i++)
                    {
                        for (int j = 0; j <= 1; j++)
                        {
                            if (SlotController.Instance.IsSlotEmpty(animal.AnimPos.X + i, animal.AnimPos.Y + j))
                            {
                                SlotController.Instance.ChangeSlotEmpty(animal.AnimPos.X, animal.AnimPos.Y);
                                SlotController.Instance.ChangeSlotOccupied(animal.AnimPos.X + i, animal.AnimPos.Y + j, animal);
                                Console.SetCursorPosition(animal.AnimPos.X + i, animal.AnimPos.Y + j);
                                Console.WriteLine(animal.model);
                                break;
                            }
                            else if (SlotController.Instance.IsSlotEmpty(animal.AnimPos.X - i, animal.AnimPos.Y + j))
                            {
                                SlotController.Instance.ChangeSlotEmpty(animal.AnimPos.X, animal.AnimPos.Y);
                                SlotController.Instance.ChangeSlotOccupied(animal.AnimPos.X - i, animal.AnimPos.Y + j, animal);
                                Console.SetCursorPosition(this.AnimPos.X - i, this.AnimPos.Y + j);
                                Console.WriteLine(this.model);
                                break;
                            }
                            else if (SlotController.Instance.IsSlotEmpty(animal.AnimPos.X + i, animal.AnimPos.Y - j))
                            {
                                SlotController.Instance.ChangeSlotEmpty(animal.AnimPos.X, animal.AnimPos.Y);
                                SlotController.Instance.ChangeSlotOccupied(animal.AnimPos.X - i, animal.AnimPos.Y + j, this);
                                Console.SetCursorPosition(animal.AnimPos.X - i, animal.AnimPos.Y + j);
                                Console.WriteLine(animal.model);
                                break;
                            }
                            else if (SlotController.Instance.IsSlotEmpty(animal.AnimPos.X - i, animal.AnimPos.Y - j))
                            {
                                SlotController.Instance.ChangeSlotEmpty(animal.AnimPos.X, animal.AnimPos.Y);
                                SlotController.Instance.ChangeSlotOccupied(animal.AnimPos.X - i, animal.AnimPos.Y + j, animal);
                                Console.SetCursorPosition(animal.AnimPos.X - i, animal.AnimPos.Y + j);
                                Console.WriteLine(animal.model);
                                break;
                            }
                        }
                    }
                    return this;
                }

                if (power < animal.power || power == animal.power)
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
            else if (this.model == "T" || animal.model == "T")
            {
                if (power > animal.power + 3)
                {
                    AnimalsManager.Instance.RemoveAnimal(animal);
                    return this;
                }
                else if (power + 3 < animal.power)
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
            if (model == "H" || model == "C")
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

                if (this.model == "T" || anim.model == "T")
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
                }else if(model == anim.model)
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
        protected void SetOldPos(int posX, int posY)
        {
            OldPos.X = posX;
            OldPos.Y = posY;
        }

        protected void MakeMove()
        {
            SlotController.Instance.ChangeSlotEmpty(OldPos.X, OldPos.Y);
            SlotController.Instance.ChangeSlotOccupied(AnimPos.X, AnimPos.Y, this);
            Console.SetCursorPosition(AnimPos.X, AnimPos.Y);
            Console.WriteLine(Model);
        }

        protected Flower FindPlant()
        {
            var hogweed = FlowersManager.Instance.flowers.FirstOrDefault(x => x.Model == "D");

            return hogweed;
        }


        public abstract Animal CreateNew(int AnimPosX, int AnimPosY);
        public bool TryMove(int X, int Y)
        {
            return SlotController.Instance.IsSlot(X, Y);
        }

        public void Reproduction(int animalPosX, int animalPosY)
        {

            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    if (SlotController.Instance.IsSlotEmpty(AnimPos.X + i, AnimPos.Y + j))
                    {
                        MakeReproduction(AnimPos.X + i, AnimPos.Y + j);
                        break;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(AnimPos.X - i, AnimPos.Y + j))
                    {
                        MakeReproduction(AnimPos.X - i, AnimPos.Y + j);
                        break;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(AnimPos.X - i, AnimPos.Y - j))
                    {
                        MakeReproduction(AnimPos.X - i, AnimPos.Y - j);
                        break;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(AnimPos.X + i, AnimPos.Y - j))
                    {
                        MakeReproduction(AnimPos.X + i, AnimPos.Y - j);
                        break;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(animalPosX + i, animalPosY + j))
                    {
                        MakeReproduction(animalPosX + i, animalPosY + j);
                        break;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(animalPosX - i, animalPosY + j))
                    {
                        MakeReproduction(animalPosX - i, animalPosY + j);
                        break;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(animalPosX - i, animalPosY - j))
                    {
                        MakeReproduction(animalPosX - i, animalPosY - j);
                        break;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(animalPosX + i, animalPosY - j))
                    {
                        MakeReproduction(animalPosX + i, animalPosY - j);
                        break;
                    }
                }
            }
            /*
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
            */


        }
        private void MakeReproduction(int posX, int posY)
        {
            var animal = CreateNew(posX, posY);
            AnimalsManager.Instance.AddAnimal(animal);

        }
        private Slot FindEmptySlot()
        {
            bool done = false;
            Slot slot;
            do
            {
                int index = RandomNumber.GenerateNumber(0, SlotController.Instance.slots.Count);
                slot = SlotController.Instance.slots[index];

                if (slot.IsEmpty)
                {
                    done = true;
                }

            } while (!done);

            return slot;
        }

        private void SetAnimalPosition()
        {
            Slot slot = FindEmptySlot();

            AnimPos.X = slot.Coordinate.X;
            AnimPos.Y = slot.Coordinate.Y;

            slot.SetAnimalSlot(AnimPos.X, AnimPos.Y, this);
        }
    }
}
