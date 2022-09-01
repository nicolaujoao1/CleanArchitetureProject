using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        //public DateTime CreateDate { get; protected set; }
        //public DateTime ModifiedDate { get; protected set; }
        //public string? CreatedBy { get; protected set; }
        //public string? ModifiedBy { get; protected set; }
    }
}
