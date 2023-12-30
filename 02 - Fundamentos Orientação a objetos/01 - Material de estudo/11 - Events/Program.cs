namespace Eventos;


public class Program
{
    static void Main(string[] args)
    {
        var room = new Room(3);

        room.RoomSoldOutEvent += OnRoomSoldOut;

        room.ReseveSeat();
        room.ReseveSeat();
        room.ReseveSeat();
        room.ReseveSeat();
        room.ReseveSeat();
        room.ReseveSeat();
    }

    static void OnRoomSoldOut(object seat, EventArgs e)
    {
        Console.WriteLine("Sala lotada!");
    }
}

public class Room 
{
    public Room(int seats)
    {
        Seats = seats;
        seatsInUse = 0;       
    }

    private int seatsInUse = 0;
    public int Seats { get; set; }


    public void ReseveSeat(){
        seatsInUse++;
        if(seatsInUse >= Seats)
        {
            OnRoomSoldOut(EventArgs.Empty);
        }
        else
        {
            Console.WriteLine("Assento reservado.");
        }
    }

    public event EventHandler RoomSoldOutEvent;

    protected virtual void OnRoomSoldOut(EventArgs e)
    {
        EventHandler handler = RoomSoldOutEvent;
        handler?.Invoke(this, e);
    }
}