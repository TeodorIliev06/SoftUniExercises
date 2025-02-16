using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniORM
{
    internal static class ValidationUtils<T>
    {
        internal static void CheckIfNull(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
        }
    }
}
