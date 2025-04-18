using System.Collections.Concurrent;

namespace SkyMapper.Extensions
{
    public static class Parallelism
    {
        /// <summary>
        /// Tasks parallelism using a throttling mechanism to achieve a granular parallelism control
        /// </summary>
        /// <param name="source">Collection of items</param>
        /// <param name="asyncAction">Async function to be executed upon the collection</param>
        /// <param name="maxDegreeOfParallelism">Maximum number of tasks allowed at the same time</param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T">Collection item class</typeparam>
        /// <typeparam name="TResult">Return type of async function</typeparam>
        /// References:
        /// https://stackoverflow.com/questions/15136542/parallel-foreach-with-asynchronous-lambda
        /// https://www.nuget.org/packages/AsyncEnumerator
        /// https://markheath.net/post/constraining-concurrent-threads-csharp
        public static async Task<IEnumerable<TResult>> ParallelForEachAsync<T, TResult>(
            this IEnumerable<T> source,
            Func<T, CancellationToken, Task<TResult>> asyncAction,
            int maxDegreeOfParallelism,
            CancellationToken cancellationToken = default)
        {
            var throttler = new SemaphoreSlim(initialCount: maxDegreeOfParallelism);
            var bag = new ConcurrentBag<TResult>();
            var tasks = new List<Task>();

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            try
            {
                foreach (var item in source)
                {
                    await throttler.WaitAsync(cts.Token);
                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            if (!cts.Token.IsCancellationRequested)
                            {
                                bag.Add(await asyncAction(item, cts.Token).ConfigureAwait(false));
                            }
                        }
                        finally
                        {
                            throttler.Release();
                        }
                    }, cts.Token));
                }

                await Task.WhenAll(tasks.ToArray());
            }
            catch (OperationCanceledException)
            {
                cts.Cancel();
                throw;
            }
            finally
            {
                // Ensure all tasks are completed or canceled
                await Task.WhenAll(tasks.Select(t => t.ContinueWith(
                    _ => { },
                    TaskContinuationOptions.ExecuteSynchronously)));
            }
            
            return bag.ToList();
        }

        /// <summary>
        /// Tasks parallelism using a throttling mechanism to achieve a granular parallelism control
        /// </summary>
        /// <param name="source">Collection of items</param>
        /// <param name="asyncAction">Async function to be executed upon the collection</param>
        /// <param name="maxDegreeOfParallelism">Maximum number of tasks allowed at the same time</param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T">Collection item class</typeparam>
        /// References:
        /// https://stackoverflow.com/questions/15136542/parallel-foreach-with-asynchronous-lambda
        /// https://www.nuget.org/packages/AsyncEnumerator
        /// https://markheath.net/post/constraining-concurrent-threads-csharp
        public static async Task ParallelForEachAsync<T>(
            this IEnumerable<T> source,
            Func<T, CancellationToken, Task> asyncAction,
            int maxDegreeOfParallelism,
            CancellationToken cancellationToken = default)
        {
            var throttler = new SemaphoreSlim(initialCount: maxDegreeOfParallelism);
            var tasks = new List<Task>();

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            try
            {
                foreach (var item in source)
                {
                    await throttler.WaitAsync(cts.Token);
                    tasks.Add(Task.Run(async () =>
                    {
                        try
                        {
                            if (!cts.Token.IsCancellationRequested)
                            {
                                await asyncAction(item, cts.Token).ConfigureAwait(false);
                            }
                        }
                        finally
                        {
                            throttler.Release();
                        }
                    }, cts.Token));
                }

                await Task.WhenAll(tasks.ToArray());
            }
            catch (OperationCanceledException)
            {
                cts.Cancel();
                throw;
            }
            finally
            {
                // Ensure all tasks are completed or canceled
                await Task.WhenAll(tasks.Select(t => t.ContinueWith(
                    _ => { },
                    TaskContinuationOptions.ExecuteSynchronously)));
            }
        }
    }
}