namespace Ryujinx.Common.Memory
{
    public class Box<T> where T : unmanaged
    {
        public T data;

        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public Box()
        {
            Data = new T();
        }
    }
}
