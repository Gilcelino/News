using System.Collections.Generic;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        
        internal List<string> _errors;
       
        public IReadOnlyCollection<string> Errors => _errors;

        public abstract bool Validate();
    }
}