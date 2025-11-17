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

        public bool canChangeStatus(Statuses wantedStatus)
        {
            switch(CurrentStatus)
            {
                case Statuses.Draft:
                    if (wantedStatus == Statuses.Active) return true;
                    else return false;
                case Statuses.Active:
                    if (wantedStatus == Statuses.InProgress || wantedStatus == Statuses.OnHold) return true;
                    else return false;
                case Statuses.OnHold:
                    if (wantedStatus == Statuses.Active) return true;
                    else return false;
                default:
                    return false;
            }
        }
    }
}
