using DGD203_2;
using System.Numerics;

public class Map
{
    private Game _theGame;

    private Vector2 _coordinates;

    private int[] _widthBoundaries;
    private int[] _heightBoundaries;

    private Location[] _locations;
    public npc _npc;
    public Game Game;

    public Map(Game game, int width, int height)
    {
        _theGame = game;

        int widthBoundary = (width - 1) / 2;

        _widthBoundaries = new int[2];
        _widthBoundaries[0] = -widthBoundary;
        _widthBoundaries[1] = widthBoundary;

        int heightBoundary = (height - 1) / 2;

        _heightBoundaries = new int[2];
        _heightBoundaries[0] = -heightBoundary;
        _heightBoundaries[1] = heightBoundary;

        _coordinates = new Vector2(0, 0);

        GenerateLocations();

        Console.WriteLine($"Created map with size {width}x{height}");
    }

    #region Coordinates

    public Vector2 GetCoordinates()
    {
        return _coordinates;
    }

    public void SetCoordinates(Vector2 newCoordinates)
    {
        _coordinates = newCoordinates;
    }

    #endregion

    #region Movement

    public void MovePlayer(int x, int y)
    {
        int newXCoordinate = (int)_coordinates[0] + x;
        int newYCoordinate = (int)_coordinates[1] + y;

        if (!CanMoveTo(newXCoordinate, newYCoordinate))
        {
            Console.WriteLine("Go Back You reach the end , Wanna fall in hell!?");
            return;
        }

        _coordinates[0] = newXCoordinate;
        _coordinates[1] = newYCoordinate;

        CheckForLocation(_coordinates);
    }

    private bool CanMoveTo(int x, int y)
    {
        return !(x < _widthBoundaries[0] || x > _widthBoundaries[1] || y < _heightBoundaries[0] || y > _heightBoundaries[1]);
    }

    #endregion

    #region Locations

    private void GenerateLocations()
    {
        _locations = new Location[5];

        Vector2 SatanThroneLocation = new Vector2(-2,-2);
        Location SatanThrone = new Location("SatanThrone", "Demon Throne That Have The Most Powerful Demons", LocationType.Combat, SatanThroneLocation);
        _locations[0] = SatanThrone;

        Vector2 ChaosLocation = new Vector2();
        Location Chaos = new Location("Chaos", "There were some theif demons steal some souls from one other", LocationType.City, ChaosLocation);
        _locations[1] = Chaos;

        Vector2 DemonLocation = new Vector2();
        List<Item> DemonItem = new List<Item>();
        DemonItem.Add(Item.ring);
        Location Demon = new Location("Demon", "Demon cave here where some lonly demons", LocationType.npc,DemonLocation, DemonItem);
        _locations[2] = Demon;

        Vector2 purgatoryLocation = new Vector2();
        List<Item> purgatoryItem = new List<Item>();
        purgatoryItem.Add(Item.Coin);
        Location purgatory = new Location("purgatory", "A place for torturing some demons", LocationType.City, purgatoryLocation, purgatoryItem);
        _locations[3] = purgatory;

        Vector2 infernoLocation = new Vector2();
        List<Item> infernoItem = new List<Item>();
        infernoItem.Add(Item.Rune);
        Location inferno = new Location("inferno", "Here where Demons play with fire", LocationType.City, infernoLocation, infernoItem);
        _locations[4] = inferno;
    }

    public void CheckForLocation(Vector2 coordinates)
    {
        Console.WriteLine($"You are now standing on {_coordinates[0]},{_coordinates[1]}");

        if (IsOnLocation(_coordinates, out Location location))
        {
            if (location.Type == LocationType.Combat)
            {
                Console.WriteLine("Prepare to fight!,item");
                Combat combat = new Combat(_theGame);
            }
            else if (location.Type == LocationType.City)
            {
                Console.WriteLine($"You are in {location.Name} {location.Type}");
                Console.WriteLine(location.Discription);

                if (HasItem(location))
                {
                    Console.WriteLine($"There is a {location.ItemsOnLocation[0]} here TAKE it");
                }
            }
            else if (location.Type == LocationType.npc)
            {
                Console.WriteLine(" presence .");
            }
        }
    }

    private bool IsOnLocation(Vector2 coords, out Location foundLocation)
    {
        for (int i = 0; i < _locations.Length; i++)
        {
            if (_locations[i].Coordinates == coords)
            {
                foundLocation = _locations[i];
                return true;
            }
        }
        foundLocation = null;
        return false;
    }

    private bool HasItem(Location location)
    {
        return location.ItemsOnLocation.Count != 0;
    }

    public void TakeItem(Player player, Vector2 coordinates)
    {
        if (IsOnLocation(coordinates, out Location location))
        {
            if (HasItem(location))
            {
                Item itemOnLocation = location.ItemsOnLocation[0];

                player.TakeItem(itemOnLocation);
                location.RemoveItem(itemOnLocation);

                Console.WriteLine($"You took the {itemOnLocation}");

                return;
            }
        }
        Console.WriteLine("There is nothing to take here!");
    }

    public void RemoveItemFromLocation(Item item)
    {
        for (int i = 0; i < _locations.Length; i++)
        {
            if (_locations[i].ItemsOnLocation.Contains(item))
            {
                _locations[i].RemoveItem(item);
            }
        }
    }

    #endregion
}