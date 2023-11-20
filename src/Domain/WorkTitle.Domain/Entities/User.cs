﻿using System;
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
        public required string Name { get; set; }

        public required string Login { get; set; }

        public string? PhotoUrl { get; set; }

        public required string ChatId { get; set; }
        public required string Email { get; set; }

        public required Guid DefaultListId { get; set; }

        public required WishList? DefaultList { get; set; }

        public ICollection<WishList>? Lists { get; set; }
    }
}
