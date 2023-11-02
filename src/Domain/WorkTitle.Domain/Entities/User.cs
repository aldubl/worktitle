using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public string? Name { get; set; }

        public string? Login { get; set; }

        public string? PhotoUrl { get; set; }

        public string? ChatId { get; set; }
        public string Email { get; set; }

        public Guid? DefaultListId { get; set; }

        public WishList? DefaultList { get; set; }

        public ICollection<WishList>? Lists { get; set; }
    }
}
