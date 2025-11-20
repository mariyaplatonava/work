using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource(3000);
            CancellationToken token = source.Token;

            try
            {
                var result = Task.WhenAny(AsyncOperation(token));
                if (result.Result.Status == TaskStatus.Canceled)
                {
                    Console.WriteLine("ПЛАГИН: Таймаут истек. Внешняя операция отменена.");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        async static Task AsyncOperation(CancellationToken token)
        {
            await Task.Delay(10000, token);
        }
    }
}
