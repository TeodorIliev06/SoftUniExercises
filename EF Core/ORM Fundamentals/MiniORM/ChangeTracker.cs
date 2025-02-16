namespace MiniORM
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;

    public class ChangeTracker<T>
        where T : class, new()
    {
        private readonly HashSet<T> allEntities;
        private readonly HashSet<T> added;
        private readonly HashSet<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            this.allEntities = CloneEntities(entities);
            this.added = new HashSet<T>();
            this.removed = new HashSet<T>();
        }

        public IReadOnlySet<T> AllEntities => this.allEntities;

        public IReadOnlySet<T> Added => this.added;

        public IReadOnlySet<T> Removed => this.removed;

        public void Add(T entity)
        {
            ValidationUtils<T>.CheckIfNull(entity);
            this.added.Add(entity);
        }

        public void Remove(T entity)
        {
            ValidationUtils<T>.CheckIfNull(entity);
            this.removed.Add(entity);
        }

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var result = new List<T>();

            var entityType = typeof(T);
            var primaryKeyProperties = entityType
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var clonedEntity in this.AllEntities)
            {
                var primaryKey = GetPrimaryKeyValues(primaryKeyProperties, clonedEntity);
                var correspondingEntity = dbSet.SingleOrDefault(e =>
                    GetPrimaryKeyValues(primaryKeyProperties, e).SequenceEqual(primaryKey));

                bool isEntityModified = this.IsModified(clonedEntity, correspondingEntity);
                if (correspondingEntity != null &&
                    isEntityModified)
                {
                    result.Add(correspondingEntity);
                }
            }

            return result;
        }

        private static HashSet<T> CloneEntities(IEnumerable<T> entities)
        {
            var properties = typeof(T).GetAllowedSqlProperties();

            var clonedEntities = new HashSet<T>();
            foreach (var entity in entities)
            {
                var entityClone = new T();
                foreach (PropertyInfo property in properties)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(entityClone, value);
                }
                clonedEntities.Add(entityClone);
            }

            return clonedEntities;
        }

        private bool IsModified(T originalEntity, T currentEntity)
        {
            var properties = typeof(T).GetAllowedSqlProperties();

            foreach (var property in properties)
            {
                if (!Equals(property.GetValue(originalEntity), property.GetValue(currentEntity)))
                {
                    return true;
                }
            }

            return false;
        }

        private static IEnumerable<object?> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            return primaryKeys.Select(pk =>
            {
                object? value = pk.GetValue(entity);
                if (value == null)
                {
                    throw new ArgumentNullException(pk.Name, "Primary key cannot be null.");
                }

                return value;
            });
        }
    }
}