using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Domain.EntitiesDto
{
    public sealed class WishListDto : BaseEntityDto
    {
        public Guid? UserId { get; set; }

        public bool IsPublic { get; set; }

        public Guid? TypeId { get; set; }

        public bool IsGroup { get; set; }

        public short? NeedVotes { get; set; }

        public bool? IsShowMined { get; set; }

        public bool IsShowFullness { get; set; }

        public string? Name { get; set; }

        public byte[]? Image { get; set; }

        public ICollection<Product>? Products { get; set; }

        public ListType? Type { get; set; }

        public User? User { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
