using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{
    public sealed class WishList : BaseEntity
    {
        public Guid? UserId { get; set; }

        public bool IsPublic { get; set; }

        public Guid? TypeId { get; set; }        

        public bool IsGroup { get; set; }

        public short? NeedVotes { get; set; }

        public bool? IsShowMined { get; set; }

        public bool? IsShowFullness { get; set; }

        public required string Name { get; set; }

        public byte[]? Image { get; set; }

        public ICollection<Product>? Products { get; set; }

        public ListType? Type { get; set; }

        public User? User { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}