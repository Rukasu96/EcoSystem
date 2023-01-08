using EcoSystem;

Enviro enviro = new Enviro();
TurnBasedController turnBased = new TurnBasedController();
Human human = new Human(20, 20, 20, 10,3);
Wolf wolf = new Wolf(10, 10, 10, 5, 2);
Wolf wolf2 = new Wolf(10, 10, 10, 6, 2);
AnimalsManager.Instance.AddAnimal(wolf);
AnimalsManager.Instance.AddAnimal(wolf2);
enviro.Draw();
Grass grass = new Grass();
FlowersManager.Instance.AddFlower(grass);

while (true)
{
    if (Console.KeyAvailable)
    {
        bool canMove = false;

        while (canMove == false)
        {
            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (human.TryMove(human.AnimPos.X - 1, human.AnimPos.Y))
                    {
                        canMove = true;
                        human.Direct = Animal.Direction.Left;
                        human.Move();
                    }
                    else
                    {
                        canMove = false;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (human.TryMove(human.AnimPos.X, human.AnimPos.Y - 1))
                    {
                        canMove = true;
                        human.Direct = Animal.Direction.Up;
                        human.Move();
                    }
                    else
                    {
                        canMove = false;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (human.TryMove(human.AnimPos.X + 1, human.AnimPos.Y))
                    {
                        canMove = true;
                        human.Direct = Animal.Direction.Right;
                        human.Move();
                    }
                    else
                    {
                        canMove = false;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (human.TryMove(human.AnimPos.X, human.AnimPos.Y + 1))
                    {
                        canMove = true;
                        human.Direct = Animal.Direction.Down;
                        human.Move();
                    }
                    else
                    {
                        canMove = false;
                    }
                    break;
                default:
                    break;
            }
        }
        turnBased.StartTurn(AnimalsManager.Instance.animals, FlowersManager.Instance.flowers);
    }
}
