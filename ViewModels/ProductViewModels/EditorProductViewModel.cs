using Flunt.Notifications;
using Flunt.Validations;

namespace ProductCatalog.ViewModels.ProductViewModels
{
    public class EditorProductViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(this.Title, 120, "Title", "O titulo deve conter até 120 caracteres")
                    .HasMinLen(this.Title, 3, "Title", "O título deve conter pelo menos 3 caracteres")
                    .IsGreaterThan(this.Price, 0, "Price", "O repço deve ser mais que zero")
            );
        }
    }
}