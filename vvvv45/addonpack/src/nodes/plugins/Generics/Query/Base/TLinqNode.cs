using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using VVVV.Core.Logging;
using VVVV.PluginInterfaces.V2;

namespace VVVV.Nodes.Generic
{
    public abstract class TLinqNode<T> : IPluginEvaluate, IPartImportsSatisfiedNotification where T : IComparable
    {
        #region fields & pins
        [Input("Input")]
        public IDiffSpread<T> FInput;

        [Input("Other")]
        public IDiffSpread<T> FOther;

        [Output("Output")]
        public ISpread<T> FOutput;

        [Output("Former Slice")]
        public Pin<int> FFormer;

        [Output("Former Other Slice")]
        public Pin<int> FOtherFormer;

        [Import()]
        public ILogger FLogger;

        private bool refresh = false;
        #endregion fields & pins

        public virtual void OnImportsSatisfied()
        {
            FFormer.Connected += doRefresh;
            FOtherFormer.Connected += doRefresh;
        }

        private void doRefresh(object sender, EventArgs e)
        {
            refresh = true;
        }

        public abstract IEnumerable<ResultElement<T>> op(ISpread<T> input, ISpread<T> other);

        //called when data for any output pin is requested
        public void Evaluate(int SpreadMax)
        {
            //			Other.Clear();
            //			for (int i = 0; i < FOther.SliceCount; i++) Other.Add(FOther[i]);	

            if (!FInput.IsChanged && !FOther.IsChanged && !refresh) return;
            refresh = false;

            var intersect = op(FInput, FOther);


            FOutput.SliceCount = 0;
            FFormer.SliceCount = FOtherFormer.SliceCount = 0;
            foreach (ResultElement<T> element in intersect)
            {
                FOutput.Add(element.result);

                if (FFormer.PluginIO.IsConnected)
                    FFormer.Add(element.inputID);

                if (FOtherFormer.PluginIO.IsConnected)
                    FOtherFormer.Add(element.otherID);
            }
            //FLogger.Log(LogType.Debug, "hi tty!");
        }
    }




}
