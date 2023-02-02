using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoSystem
{
    internal class TurnBasedController
    {
        public void StartTurn(List<Animal> animals, List<Flower> flowers)
        {
            var animalGroup = animals.OrderByDescending(x => x.Initiative).ThenByDescending(x => x.Age).ToList();
            foreach(Animal animal in animalGroup)
            {
                switch (animal.Model)
                {
                    case "A":
                        animal.Move(2);
                        break;
                    case "T":
                        if(RandomNumber.GenerateNumber(0, 4) == 2)
                        {
                            animal.Move(1);
                        }
                        break;
                    case "C":
                        CyberSheep cs = (CyberSheep)animal;
                        cs.MoveCyberSheep(1);
                        break;
                    default:
                        animal.Move(1);
                        break;
                }

            }

            var flowerGroup = flowers.ToList();
            foreach(Flower flower in flowerGroup)
            {
                switch (flower.Model)
                {
                    case "M":
                        flower.TryToReproduce();
                        flower.TryToReproduce();
                        break;
                    case "D":
                        flower.TryToReproduce();
                        Hogweed hogweed = (Hogweed)flower;
                        hogweed.HogweedSkill();
                        break;
                    default:
                        flower.TryToReproduce();
                        break;
                }
            }
        }
        




    }
}
