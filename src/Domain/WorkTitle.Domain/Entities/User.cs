﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }

        public string? Login { get; set; }

        public string? PhotoUrl { get; set; }

        public string? ChatId { get; set; }

        public Guid Id { get; set; }

        public Guid? DefaultListId { get; set; }

        public virtual List? DefaultList { get; set; }

        public virtual ICollection<List> Lists { get; set; } = new List<List>();
    }
}
