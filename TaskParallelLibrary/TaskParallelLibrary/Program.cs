using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TPL_playground
{
    class Program
    {
        static BufferBlock<string>? bufferBlock;

        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                bufferBlock = new BufferBlock<string>();
                var batchBlock = new BatchBlock<string>(7);
                var action = new ActionBlock<IEnumerable<string>>(async t =>
                {
                    await SendUsers(t);
                });

                batchBlock.LinkTo(action, new DataflowLinkOptions() { PropagateCompletion = true });
                bufferBlock.LinkTo(batchBlock, new DataflowLinkOptions() { PropagateCompletion = true });

                await InsertUsers();

                Console.WriteLine("Now the buffer will complete. It's complition will be followed by completing the batch. Press any key to continue...");
                Console.ReadKey();

                bufferBlock.Complete();
                await bufferBlock.Completion.ContinueWith(delegate
                {
                    batchBlock.Complete();
                });

                Console.ReadKey();
            }).GetAwaiter().GetResult();
        }

        static async Task SendUsers(IEnumerable<string> users)
        {
            foreach (var user in users)
            {
                await Task.Delay(200);
                Console.WriteLine("Sending from Batch: {0}", user);
            }
        }

        static async Task InsertUsers()
        {
            for (int i = 0; i < 25; i++)
            {
                await Task.Delay(200);
                Console.WriteLine("Inserting into Buffer: Item{0}", i);
                await bufferBlock.SendAsync(string.Format("Item{0}", i));
            }

        }
    }
}