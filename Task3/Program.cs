using System;

namespace Task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WorkOrder order = new WorkOrder(Statuses.Active);
            Statuses wantedStatus = Statuses.Draft;

            if (order.canChangeStatus(wantedStatus))
            {
                Console.WriteLine($"Переход возможен. Статус заказа: {wantedStatus}");
            }
            else
            {
                Console.WriteLine($"Переход невозможен. Статус заказа: {order.CurrentStatus}");
            }
        }
    }
}
