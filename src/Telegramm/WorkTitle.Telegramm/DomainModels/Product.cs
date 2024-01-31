using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTitle.Telegramm.DomainModels
{
    internal class Product
    {
        internal Guid Id { get; set; }
        internal Guid ListId { get; set; }
        internal string? Name { get; set; }
        internal decimal? LastPrice { get; set; }
        internal short? LastScore { get; set; }
        internal short? Priority { get; set; }
        internal string? PhotoUrl { get; set; }
        internal string? Description { get; set; }
        internal short? Vote { get; set; }
        internal bool IsMined { get; set; }
        internal decimal? Fullness { get; set; }
        internal byte[]? Image { get; set; }
    }
}
