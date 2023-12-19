using System.ComponentModel.DataAnnotations;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Api.Models
{
    public class WishListModel
    {
        public bool IsPublic { get; set; }
        public bool IsGroup { get; set; }
        public short? NeedVotes { get; set; }
        public bool? IsShowMined { get; set; }
        public bool IsShowFullness { get; set; }
        public string? Name { get; set; }
        public byte[]? Image { get; set; }
        public ListType? Type { get; set; }
        public User? User { get; set; }

    }
}
