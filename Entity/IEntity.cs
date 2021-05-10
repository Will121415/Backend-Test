using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public interface IEntity<T>
    {
        [Key]
        T Id { get; init; }
    }
}