using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.ValueOfObjects
{
    public  record  OrderItemId
    {
        public Guid Value { get; }

        internal static OrderItemId Of(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
