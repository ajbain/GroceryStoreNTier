using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Data
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IngredientId { get; set; }
        [ForeignKey(nameof(IngredientId))]
        public virtual Ingredients Ingredients { get; set; }
    }
}
