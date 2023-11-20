using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WorkTitle.Domain.Abstractions
{
    /// <summary>
    /// Represents a base entity with a unique identifier.
    /// </summary>
    public abstract class BaseEntityDto
    {
        private Guid _id;

        /// <summary>
        /// Gets or sets the unique identifier of the entity.
        /// </summary>
        public Guid Id
        {
            get
            {
                if (_id == Guid.Empty)
                {
                    _id = Guid.NewGuid();
                }
                return _id;
            }

            set => _id = value;
        }
    }
}