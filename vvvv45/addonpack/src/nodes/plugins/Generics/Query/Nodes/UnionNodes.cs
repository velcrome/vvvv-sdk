#region usings

using VVVV.Nodes.Generic;
using VVVV.PluginInterfaces.V2;
#endregion usings

namespace VVVV.Nodes
{
    #region PluginInfo
    [PluginInfo(Name = "Union", Category = "String", Help = "Filter out particular strings", Tags = "LINQ", Author = "velcrome")]
    #endregion PluginInfo
    public class StringUnionNode : TUnionNode<string> 
    { } 

    #region PluginInfo
    [PluginInfo(Name = "Union", Category = "Value", Help = "Filter out particular values", Tags = "LINQ", Author = "velcrome")]
    #endregion PluginInfo
    public class ValueUnionNode : TUnionNode<double>
    { }



}
