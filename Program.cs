using EcoSystem;

Enviro enviro = new Enviro();
enviro.Draw();
TurnBasedController turnBased = new TurnBasedController();
Human human = new Human(20, 8, 20);
Wolf wolf = new Wolf(10, 12, 7);
Wolf wolf2 = new Wolf(10, 12, 7);
Sheep sheep = new Sheep(5, 5, 6);
Sheep sheep2 = new Sheep(5, 5, 6);
Sheep sheep3 = new Sheep(5, 5, 6);
Fox fox = new Fox(4, 6, 8);
Fox fox2 = new Fox(4, 6, 8);
Antelope antelope = new Antelope(10, 7, 10);
Antelope antelope2 = new Antelope(10, 7, 10);
Turtle turtle = new Turtle(23, 4, 5);
Turtle turtle2 = new Turtle(23, 4, 5);
CyberSheep cyberSheep = new CyberSheep(99, 8, 5);
Grass grass = new Grass();
Milt milt = new Milt();
Belladonna belladonna = new Belladonna();
Guarana guarana = new Guarana();
Hogweed hogweed = new Hogweed();

while (true)
{
    Console.SetCursorPosition(human.AnimPos.X, human.AnimPos.Y);
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
                        human.MoveHuman();
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (human.TryMove(human.AnimPos.X, human.AnimPos.Y - 1))
                    {
                        canMove = true;
                        human.Direct = Animal.Direction.Up;
                        human.MoveHuman();
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (human.TryMove(human.AnimPos.X + 1, human.AnimPos.Y))
                    {
                        canMove = true;
                        human.Direct = Animal.Direction.Right;
                        human.MoveHuman();
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (human.TryMove(human.AnimPos.X, human.AnimPos.Y + 1))
                    {
                        canMove = true;
                        human.Direct = Animal.Direction.Down;
                        human.MoveHuman();
                    }
                    break;
                case ConsoleKey.Insert:
                    human.StartUsingSkill();
                    break;
                default:
                    break;
            }
        }
        turnBased.StartTurn(AnimalsManager.Instance.animals, FlowersManager.Instance.Flowers);
    }
}
