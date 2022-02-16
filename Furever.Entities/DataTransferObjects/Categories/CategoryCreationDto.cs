using System.ComponentModel.DataAnnotations;

namespace Furever.Entities.DataTransferObjects.Categories
{
    public class CategoryCreationDto
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(50)]
        public string Species { get; set; }
    }
}
