using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class WorkOrder: IStatusValidator
    {
        public Statuses CurrentStatus { get; private set; }

        public WorkOrder(Statuses cuurent_status)
        {
            CurrentStatus = cuurent_status;
        }

        public bool CanChangeStatus(Statuses wantedStatus)
        {
            switch(CurrentStatus)
            {
                case Statuses.Draft:
                    return (wantedStatus == Statuses.Active);
                case Statuses.Active:
                    return (wantedStatus == Statuses.InProgress || wantedStatus == Statuses.OnHold);
                case Statuses.OnHold:
                    return (wantedStatus == Statuses.Active);
                default:
                    return false;
            }
        }
    }
}
