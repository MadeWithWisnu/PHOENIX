namespace PhoenixWeb.ViewModels.Guest;

public class GuestVM
{
    public string Number { get; set; } = null!;
    public int Floor { get; set; }
    public string RoomType { get; set; } = null!;
    public int GuestLimit { get; set; }
    public string? Description { get; set; }
    public decimal Cost { get; set; }
}
