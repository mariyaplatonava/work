using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public enum Statuses
    {
        Draft,
        Active,
        InProgress,
        OnHold,
        Completed
    }

    public interface IStatusValidator
    {
        public virtual bool CanChangeStatus(Statuses currentStatus, Statuses wantedStatus) 
        {
            return true;
        }
    }
}
