﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTitle.Domain.Abstractions;

namespace WorkTitle.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public required string Name { get; set; }

        public string? Url { get; set; }

        public decimal? LastPrice { get; set; }

        public short? LastScore { get; set; }

        public short? Priority { get; set; }

        public string? PhotoUrl { get; set; }

        public string? Description { get; set; }        

        public short? Vote { get; set; }

        public bool IsMined { get; set; }

        public decimal? Fullness { get; set; }

        public required Guid ListId { get; set; }

        public byte[]? Image { get; set; }

        public required WishList List { get; set; }
    }

}