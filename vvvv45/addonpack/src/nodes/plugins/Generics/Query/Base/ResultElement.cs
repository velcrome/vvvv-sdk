namespace VVVV.Nodes
{
    public class ResultElement<T>
    {
        public T result;
        public int inputID;
        public int otherID;

        public ResultElement(T result, int inputID, int otherID)
        {
            this.result = result;
            this.inputID = inputID;
            this.otherID = otherID;
        }
    }
}
