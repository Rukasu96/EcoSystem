using EcoSystem;

Enviro enviro = new Enviro();
enviro.Draw();
TurnBasedController turnBased = new TurnBasedController();
Human human = new Human(20, 8, 20);
Wolf wolf = new Wolf(10, 10, 10);
CyberSheep cyberSheep = new CyberSheep(10, 10, 10);
Hogweed hogweed = new Hogweed();

while (true)
{
    if (Console.KeyAvailable)
    {
        bool canMove = false;

        while (canMove == false)
        {
            ConsoleKeyInfo input = Console.ReadKey();

            if(input.Key == ConsoleKey.Insert)
            {
                human.UsingSprint();
            }
            input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (human.TryMove(human.AnimPos.X - human.speed, human.AnimPos.Y))
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
                    if (human.TryMove(human.AnimPos.X, human.AnimPos.Y - human.speed))
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
                    if (human.TryMove(human.AnimPos.X + human.speed, human.AnimPos.Y))
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
                    if (human.TryMove(human.AnimPos.X, human.AnimPos.Y + human.speed))
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
