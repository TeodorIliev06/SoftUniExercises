using System.Text;

namespace GenericSwapMethodInteger
{
    public class Box<T>
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
        public void Swap(int firstIndex, int secondIndex)
        {
            if (AreValidElements(firstIndex, secondIndex))
            {
                return;
            }

            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        private bool AreValidElements(int firstIndex, int secondIndex)
        {
            return firstIndex < 0 || firstIndex >= list.Count
                         || secondIndex < 0 || firstIndex >= list.Count;
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
