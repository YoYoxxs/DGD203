using DGD203_2;
using System.Numerics;

public class npc
{
    public Player Player { get; set; }
    public Game Game { get; set; }
    public Map Map { get; set; }
    public Location Location { get; set; }
    public Inventory Inventory { get; set; }

    public string answer;
    public Vector2 npccoordinates;
    public string name;
    public bool cantake = true;
    public int heatlh;

    public npc(string answer, Vector2 npclocation, bool cantake)
    {
        this.answer = answer;
        npccoordinates = npclocation;
        this.cantake = cantake;
    }

    public void talk()
    {
        Player = new Player(name, null);
        Inventory = new Inventory();
        Game = new Game();
        Map = new Map(Game, 5, 5);
        heatlh = Player.Health;
        Console.WriteLine("Well well The new Little Demon LiKE The Other Sure You Want To THE CURSED RING You Will get it But... \n Solve My Riddle or I Will Use The Ring On You,You Have Two Chance first I Will Eat Some Of Your Soul,Secound Time I Will Eat Your Soul And Store It In The Ring");
        question();
        while (cantake)
        {
            getInput();
            handleInput();
        }
    }

    public void question()
    {
        Console.WriteLine("I speak without a mouth and hear without ears. I have no body, but I come alive with the wind. What am I ? 1.Echo\n 2.Whistle\n 3.Cloud\n 4.Candle\n 5.Shadow");
    }

    public void getInput()
    {
        answer = Console.ReadLine();
    }

    public void handleInput()
    {
        if (answer != null)
        {
            if (heatlh > 0)
            {
                if (cantake)
                {
                    switch (answer)
                    {
                        case "1":
                            Console.WriteLine("Ummm..What Thats Wierd No One Knows The Answer TAKE THE RING But Becarful It May Eat Your Soul ");
                            Player.playerHasRing(Item.ring);
                            cantake = false;
                            break;
                        case "2":
                            if (heatlh == 100)
                            {
                                Console.WriteLine("Wrong Idoit You Have ONE Chance Left");
                            }
                            else if (heatlh == 50)
                            {
                                Console.WriteLine("Wrong Idoit You Have ONE Chance Left");
                            }
                            break;
                        case "3":
                            if (heatlh == 100)
                            {
                                Console.WriteLine("Wrong Idoit You Have ONE Chance Left");
                            }
                            else if (heatlh == 50)
                            {
                                Console.WriteLine("Wrong Idoit You Have ONE Chance Left");
                            }
                            break;
                        case "4":
                            if (heatlh == 100)
                            {
                                Console.WriteLine("Wrong Idoit You Have ONE Chance Left");
                            }
                            else if(heatlh == 50)
                            {
                                Console.WriteLine("Wrong Idoit You Have ONE Chance Left");
                            }
                            break;
                        case "5":
                            if (heatlh == 100)
                            {
                                Console.WriteLine("Wrong Idoit You Have ONE Chance Left");
                            }
                            else if (heatlh == 50)
                            {
                                Console.WriteLine("Wrong Idoit You Have ONE Chance Left");
                            }
                            break;
                        default:
                            Console.WriteLine("CheckKK Your Input ,Press Something Usefull");
                            break;
                    }
                    heatlh = heatlh - 50;
                }
            }
            else
            {
                Game.PlayerDied();
                exit();
            }
        }
    }
    public void exit()
    {
        Environment.Exit(0);
    }


}
