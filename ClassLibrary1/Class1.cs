using System.Collections.Generic;

namespace AbstractFactory
{
    public class MazeFactory
    {
        public virtual Maze MakeMaze()
        {
            return new Maze();
        }

        public virtual Wall MakeWall()
        {
            return new Wall();
        }

        public virtual Room MakeRoom(int roomNo)
        {
            return new Room(roomNo);
        }

        public virtual Door MakeDoor(Room r1, Room r2)
        {
            return new Door(r1, r2);
        }
    }

    public class EnchantedMazeFactory : MazeFactory
    {
        public EnchantedMazeFactory()
        {

        }

        public override Room MakeRoom(int roomNo)
        {
            return new EnchantedRoom(roomNo, CastSpell());
        }

        private Spell CastSpell()
        {
            return new Spell();
        }
    }

    public class BombedMazeFactory : MazeFactory
    {
        public override Wall MakeWall()
        {
            return new BombedWall();
        }

        public override Room MakeRoom(int roomNo)
        {
            return new RoomWithABomb(roomNo);
        }
    }

    public class Maze
    {
        public List<Room> Rooms { get; private set; }
        public Maze()
        {
            Rooms = new List<Room>();
        }
        public void AddRoom(Room r1)
        {
            Rooms.Add(r1);
        }
    }

    public class MazeGame
    {
        public Maze CreateMaze(MazeFactory factory)
        {
            Maze aMaze = factory.MakeMaze();

            Room r1 = factory.MakeRoom(1);
            Room r2 = factory.MakeRoom(2);

            Door theDoor = factory.MakeDoor(r1, r2);

            aMaze.AddRoom(r1);
            aMaze.AddRoom(r2);

            r1.SetSide(Direction.North, factory.MakeWall());
            r1.SetSide(Direction.East, theDoor);
            r1.SetSide(Direction.South, factory.MakeWall());
            r1.SetSide(Direction.West, factory.MakeWall());

            r2.SetSide(Direction.North, factory.MakeWall());
            r2.SetSide(Direction.East, factory.MakeWall());
            r2.SetSide(Direction.South, factory.MakeWall());
            r2.SetSide(Direction.West, theDoor);

            return aMaze;
        }
    }

    public abstract class MapSite
    {
        public virtual void Enter()
        {

        }
    }

    public class Room : MapSite
    {
        public Dictionary<Direction, MapSite> Sides
        {
            get; private set;
        }

        public Room(int roomNo)
        {
            _roomNumber = roomNo;
            Sides = new Dictionary<Direction, MapSite>();
        }

        public void SetSide(Direction direction, MapSite m)
        {
            Sides.Add(direction, m);
        }

        private int _roomNumber;

    }

    public class EnchantedRoom : Room
    {
        public EnchantedRoom(int roomNo, Spell spell) : base(roomNo)
        {
            _spell = spell;
        }

        private Spell _spell;
    }

    public class RoomWithABomb : Room
    {
        public RoomWithABomb(int roomNo) : base(roomNo)
        {
        }
    }

    public class Spell
    {

    }

    public class Wall : MapSite
    {
    }

    public class BombedWall : Wall
    {

    }

    public class Door : MapSite
    {
        public Door(Room r1, Room r2)
        {
            _room1 = r1;
            _room2 = r2;
        }

        private Room _room1;
        private Room _room2;
        private bool _isOpen;
    }

    public enum Direction { North, South, East, West };

}


