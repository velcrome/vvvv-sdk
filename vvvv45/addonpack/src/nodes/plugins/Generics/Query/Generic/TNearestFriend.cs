using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic
{
    public abstract class TNearestFriend<T> : TLinqNode<T> where T : IComparable
    {

        public override IEnumerable<ResultElement<T>> op(ISpread<T> input, ISpread<T> other)
        {
            var counter = 0;
            var union = input.Union(other);

            return
                from T t in input
                let inputID = counter++
                where other.Contains(t)
                let otherID = other.IndexOf(t)
                select new ResultElement<T>(t, inputID, otherID);


        }

        protected abstract double Distance(T t1, T t2);
    }
}
