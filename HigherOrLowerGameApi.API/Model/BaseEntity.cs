using System;

namespace HigherOrLowerGameApi.API.Model
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Deleted { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            Deleted = false;
        }
    }
}