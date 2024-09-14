using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTokenNamespace
{
    public class CancellationTokenClass
    {
        static void Main(string[] args)
        {
            softCancellation();
            // exceptionCancellation();
        }

        private static void softCancellation()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            // задача вычисляет квадраты чисел
            Task task = new Task(() =>
            {
                for (int i = 1; i < 10; i++)
                {
                    if (token.IsCancellationRequested)  // проверяем наличие сигнала отмены задачи
                    {
                        Console.WriteLine("Операция прервана");
                        return;     //  выходим из метода и тем самым завершаем задачу
                    }
                    Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                    Thread.Sleep(200);
                }
            }, token);
            task.Start();

            Thread.Sleep(1000);
            // после задержки по времени отменяем выполнение задачи
            cancelTokenSource.Cancel();
            // ожидаем завершения задачи
            Thread.Sleep(1000);
            //  проверяем статус задачи
            Console.WriteLine($"Task Status: {task.Status}");
            cancelTokenSource.Dispose(); // освобождаем ресурсы
        }

        private static void exceptionCancellation()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task task = new Task(() =>
            {
                for (int i = 1; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                        token.ThrowIfCancellationRequested(); // генерируем исключение

                    Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                    Thread.Sleep(200);
                }
            }, token);
            try
            {
                task.Start();
                Thread.Sleep(1000);
                // после задержки по времени отменяем выполнение задачи
                cancelTokenSource.Cancel();

                task.Wait(); // ожидаем завершения задачи
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.InnerExceptions)
                {
                    if (e is TaskCanceledException)
                        Console.WriteLine("Операция прервана");
                    else
                        Console.WriteLine(e.Message);
                }
            }
            finally
            {
                cancelTokenSource.Dispose();
            }

            //  проверяем статус задачи
            Console.WriteLine($"Task Status: {task.Status}");
        }
    }
}