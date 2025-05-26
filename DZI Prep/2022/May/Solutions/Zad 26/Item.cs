namespace Zad_26
{
    public class Item : IComparable<Item>
    {
        public Item(string description, double price)
        {
            this.Description = string.IsNullOrWhiteSpace(description)
                ? throw new ArgumentException("Description cannot be empty or whitespace.", nameof(description))
                : description;

            this.Price = price <= 0
                ? throw new ArgumentException("Price must be a positive value.", nameof(price))
                : price;
        }

        public string Description { get; init; }
        public double Price { get; init; }

        public int CompareTo(Item? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            var descriptionComparison = string.Compare(Description, other.Description, StringComparison.Ordinal);

            return descriptionComparison != 0
                ? descriptionComparison
                : Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"{this.Description} ({this.Price:F2})";
        }
    }
}
