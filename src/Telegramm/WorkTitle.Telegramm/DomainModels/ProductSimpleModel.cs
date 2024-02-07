using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTitle.Telegramm.DomainModels
{
    internal class ProductSimpleModel
    {
        public required string Name { get; set; }

        public required Guid ListId { get; set; }
    }
}
