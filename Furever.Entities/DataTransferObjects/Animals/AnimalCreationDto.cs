using System;
using System.ComponentModel.DataAnnotations;

namespace Furever.Entities.DataTransferObjects.Animals
{
    public class AnimalCreationDto
    {
        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        public int RefugeId { get; set; }
        public bool IsAvailable { get; set; }

        public int Age { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
