namespace Tuple
{
    public class CustomTuple<T1, T2>
    {
		private T1 item1;
		private T2 item2;

        public CustomTuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public T2 Item2
		{
			get { return item2; }
			set { item2 = value; }
		}


		public T1 Item1
		{
			get { return item1; }
			set { item1 = value; }
		}

        public override string ToString()
        {
            return $"{item1} -> {item2}";	
        }
    }
}
