namespace DataStructures
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Value;
        public byte Height;
        public TreeNode<T>? Left;
        public TreeNode<T>? Right;

        public TreeNode(T x)
        {
            Value = x;
            Height = 1;
        }
    }
}