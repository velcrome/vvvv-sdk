using System;
using System.Collections.Generic;
using System.Linq;
using VVVV.PluginInterfaces.V2;

namespace VVVV.Nodes.Generic
{

    public class TIntersectNode<T> : TLinqNode<T> where T : IComparable
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
    }
}
