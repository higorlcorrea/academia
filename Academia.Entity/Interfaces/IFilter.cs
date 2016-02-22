using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Academia.Entity.Interfaces
{
    public class IFilter<T> where T : class
    {
        public List<Expression<Func<T, object>>> Includes { get; set; }
    }
}
