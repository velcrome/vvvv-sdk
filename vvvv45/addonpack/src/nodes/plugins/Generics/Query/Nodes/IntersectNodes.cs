#region usings

using VVVV.Nodes.Generic;
using VVVV.PluginInterfaces.V2;
#endregion usings

namespace VVVV.Nodes
{
    #region PluginInfo
    [PluginInfo(Name = "Intersect", Category = "String", Help = "Filter out particular strings", Tags = "LINQ", Author = "velcrome")]
    #endregion PluginInfo
    public class StringIntersectNode : TIntersectNode<string>
    { }

    #region PluginInfo
    [PluginInfo(Name = "Intersect", Category = "Value", Help = "Filter out particular values", Tags = "LINQ", Author = "velcrome")]
    #endregion PluginInfo
    public class ValueIntersectNode : TIntersectNode<double>
    { }



}
