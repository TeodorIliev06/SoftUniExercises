namespace MiniORM
{
    using System.Collections;

    public class DbSet<T> : ICollection<T>
        where T : class, new()
    {
        public DbSet(IEnumerable<T> entities)
        {
            if (entities is null)
            {
                throw new ArgumentException(nameof(entities));
            }

            this.Entities = entities.ToList();
            this.ChangeTracker = new ChangeTracker<T>(this.Entities);
        }

        internal ChangeTracker<T> ChangeTracker { get; }
        internal IList<T> Entities { get; }
        public int Count => this.Entities.Count;
        public bool IsReadOnly => this.Entities.IsReadOnly;

        public IEnumerator<T> GetEnumerator() => this.Entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Add(T item)
        {
            ValidationUtils<T>.CheckIfNull(item);

            this.Entities.Add(item);
            this.ChangeTracker.Add(item);
        }

        public void Clear()
        {
            while (this.Count > 0)
            {
                this.RemoveLast();
            }
        }

        public bool Contains(T item) => this.Entities.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => this.Entities.CopyTo(array, arrayIndex);

        public bool Remove(T item)
        {
            ValidationUtils<T>.CheckIfNull(item);

            var isRemoved = this.Entities.Remove(item);
            if (isRemoved)
            {
                this.ChangeTracker.Remove(item);
            }

            return isRemoved;
        }
        private void RemoveLast()
        {
            var entityToRemove = this.Entities[this.Count - 1];
            this.Entities.RemoveAt(this.Count - 1);
            this.ChangeTracker.Remove(entityToRemove);
        }
    }
}
