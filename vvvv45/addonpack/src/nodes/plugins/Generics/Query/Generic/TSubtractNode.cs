using System;
using System.Collections.Generic;
using System.Linq;
using VVVV.PluginInterfaces.V2;

namespace VVVV.Nodes.Generic
{

    public class TSubtractNode<T> : TLinqNode<T> where T : IComparable
    {

        public override IEnumerable<ResultElement<T>> op(ISpread<T> input, ISpread<T> other)
        {
            var counter = 0;
            return
                from T t in input
                let inputID = counter++
                where !other.Contains(t)
                let otherID = -1 // it is not contained, after all.  
                select new ResultElement<T>(t, inputID, otherID);
        }
    }
}
