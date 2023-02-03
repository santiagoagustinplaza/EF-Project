using System.ComponentModel.DataAnnotations;

namespace EFProject.Models;
public class Category
{
    //[Key]
    public Guid CategoryId { get; set; }
    //[Required]
    //[MaxLength(150)]
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    public DateTime CreationDate { get; set; }

    public virtual ICollection<Task> Tasks{ get; set; }
}