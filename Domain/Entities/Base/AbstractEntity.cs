using System.ComponentModel.DataAnnotations.Schema;

namespace Flag_Explorer_App.Domain.Entities.Base
{
    public abstract class AbstractEntity
    {
        protected AbstractEntity()
        : this(true, Guid.Empty)
        { }

        protected AbstractEntity(bool isActive, Guid id)
        {
            Id = (id == Guid.Empty ? Guid.NewGuid() : id);

            IsActive = isActive;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public bool IsActive { get; set; }
    }
}
