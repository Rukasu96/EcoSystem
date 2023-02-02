using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    abstract class Animal
    {
        public enum Direction { Up, Down, Right, Left }

        public int Power { get; set; }
        public string Model { get; set; }
        public int Initiative { get; set; }
        public int Age { get; set; }

        public bool IsAlive { get; set; }
        public Direction Direct { get; set; }
        public Coordinate AnimPos { get; set; }

        protected bool haveSkill;
        protected Coordinate oldPos;

        public Animal(int age, int power, int initiative)
        {
            Age = age;
            Power = power;
            Initiative = initiative;
            AnimPos = new Coordinate();
            oldPos = new Coordinate();
            SetAnimalPosition();
            IsAlive = true;
            haveSkill = false;
        }
        public Animal(int age, int power, int initiative, int flowerPosX, int flowerPosY)
        {
            Age = age;
            Power = power;
            Initiative = initiative;
            AnimPos = new Coordinate();
            oldPos = new Coordinate();

            AnimPos.X = flowerPosX;
            AnimPos.Y = flowerPosY;
            IsAlive = true;
            haveSkill = false;
        }


        public Animal Fight(Animal animal)
        {
            if(animal.haveSkill == true)
            {
                return animal.UseSkill(this);
            }

            if (Power > animal.Power)
            {
                Death(animal);
                return this;
            }
            else
            {
                Death(this);
                return animal;
            }

        }
        public void Move(int speed)
        {
            if (Model == "H")
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
  
                if(Model == anim.Model)
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

                    if (winAnimal != this)
                    {
                        AnimPos.X = oldPos.X;
                        AnimPos.Y = oldPos.Y;
                        MakeMove(AnimPos.X, AnimPos.Y, this, true);
                    }
                    else
                    {
                        MakeMove(AnimPos.X, AnimPos.Y, this, true);
                    }
                }

            }
            else
            {
                MakeMove(AnimPos.X, AnimPos.Y, this, true);
            }

        }

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
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(AnimPos.X - i, AnimPos.Y + j))
                    {
                        MakeReproduction(AnimPos.X - i, AnimPos.Y + j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(AnimPos.X - i, AnimPos.Y - j))
                    {
                        MakeReproduction(AnimPos.X - i, AnimPos.Y - j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(AnimPos.X + i, AnimPos.Y - j))
                    {
                        MakeReproduction(AnimPos.X + i, AnimPos.Y - j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(animalPosX + i, animalPosY + j))
                    {
                        MakeReproduction(animalPosX + i, animalPosY + j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(animalPosX - i, animalPosY + j))
                    {
                        MakeReproduction(animalPosX - i, animalPosY + j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(animalPosX - i, animalPosY - j))
                    {
                        MakeReproduction(animalPosX - i, animalPosY - j);
                        return;
                    }
                    else if (SlotController.Instance.IsSlotEmpty(animalPosX + i, animalPosY - j))
                    {
                        MakeReproduction(animalPosX + i, animalPosY - j);
                        return;
                    }
                }
            }

        }
        public void Death(Animal animal)
        {
            if(animal.Model == "H")
            {
                Console.Clear();
                Console.WriteLine("GAME OVER");
                System.Environment.Exit(1);
            }
            AnimalsManager.Instance.RemoveAnimal(animal);
            SlotController.Instance.ChangeSlotEmpty(animal.AnimPos.X, animal.AnimPos.Y);
        }

        protected void SetOldPos(int posX, int posY)
        {
            oldPos.X = posX;
            oldPos.Y = posY;
        }

        protected void MakeMove(int posX, int posY,Animal animal, bool freeSlot)
        {
            if (freeSlot == true)
            {
                SlotController.Instance.ChangeSlotEmpty(oldPos.X, oldPos.Y);
            }

            SlotController.Instance.ChangeSlotOccupied(posX, posY, this);
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine(Model);
        }

        protected Flower FindPlant()
        {
            var hogweed = FlowersManager.Instance.Flowers.FirstOrDefault(x => x.Model == "D");

            return hogweed;
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
                int index = RandomNumber.GenerateNumber(0, SlotController.Instance.Slots.Count);
                slot = SlotController.Instance.Slots[index];

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

        public abstract Animal UseSkill(Animal animal);
        public abstract Animal CreateNew(int AnimPosX, int AnimPosY);

    }
}
