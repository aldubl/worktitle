using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{
    public class List : BaseEntity
    {
        public Guid? UserId { get; set; }

        public bool IsPublic { get; set; }

        public Guid? TypeId { get; set; }

        public Guid Id { get; set; }

        public bool IsGroup { get; set; }

        public short? NeedVotes { get; set; }

        public bool? IsShowMined { get; set; }

        public bool IsShowFullness { get; set; }

        public string? Name { get; set; }

        public byte[]? Image { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual ListType? Type { get; set; }

        public virtual User? User { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}