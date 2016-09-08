using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF7.Domain
{
    public abstract class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRow { get; set; }
    }

    public class Parent : Entity
    {
        public string Name { get; set; }

        public ICollection<Child> Childs { get; set; }
    }

    public class Child : Entity
    {
        public string Name { get; set; }
        public ICollection<Toy> Toys { get; set; }
    }

    public class Toy : Entity
    {
        public string Name { get; set; }
    }
}
