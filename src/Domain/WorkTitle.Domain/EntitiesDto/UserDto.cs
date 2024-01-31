using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;
using WorkTitle.Domain.Entities;

namespace WorkTitle.Domain.EntitiesDto
{
    public sealed class UserDto : BaseEntityDto
    {
        public string? Name { get; set; }

        //public string? Login { get; set; }

        public string? PhotoUrl { get; set; }

        public long? ChatId { get; set; }

        public required string Email { get; set; }

        public Guid? DefaultListId { get; set; }

        public WishList? DefaultList { get; set; }

        public ICollection<WishList>? Lists { get; set; }
    }
}
