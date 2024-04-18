using System;
using System.Collections.Generic;

namespace PhoenixDataAccess.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomInventories = new HashSet<RoomInventory>();
        }

        public string Number { get; set; } = null!;
        public int Floor { get; set; }
        public string RoomType { get; set; } = null!;
        public int GuestLimit { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<RoomInventory> RoomInventories { get; set; }
    }
}
