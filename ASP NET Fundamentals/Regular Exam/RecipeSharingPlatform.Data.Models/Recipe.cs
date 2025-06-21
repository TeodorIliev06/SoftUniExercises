namespace RecipeSharingPlatform.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class Recipe
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Instructions { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string AuthorId { get; set; } = null!;

        public IdentityUser Author { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public HashSet<UserRecipe> UsersRecipes { get; set; } =
            new HashSet<UserRecipe>();
    }
}
/*
 *Recipe
   •	Has Id – a unique integer, Primary Key
   •	Has Title – a string with min length 3 and max length 80 (required)
   •	Has Instructions – string with min length 10 and max length 250 (required)
   •	Has ImageUrl – nullable string (not required)
   •	Has AuthorId – string (required)
   •	Has Author – IdentityUser (required)
   •	Has CreatedOn – DateTime with format "dd-MM-yyyy" (required)
   o	The DateTime format is only recommended
   •	Has CategoryId – integer, foreign key (required)
   •	Has Category – Category (required)
   •	Has IsDeleted – bool (default value == false)
   •	Has UsersRecipes – a collection of type UserRecipe
   
 */
