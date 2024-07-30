using System.Text;

namespace GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        private List<T> list = new List<T>();

        public List<T> List
        {
            get { return list; }
            set { list = value; }
        }

        public void Add(T item)
        {
            list.Add(item);
        }
        
        public int CountLarger(T item)
        {
            int count = 0;

            foreach (var listItem in list)
            {
                if(listItem.CompareTo(item) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (var item in list)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
