using System;
using System.ComponentModel;
using System.Diagnostics;

namespace BruPark.Apps.WPF
{
    public static class BackgroundWorkerUtils
    {
        public static void Start<T>(Func<T> producer, Action<T> consumer)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.WorkerReportsProgress = false;
            worker.WorkerSupportsCancellation = false;

            T result = default(T);

            worker.DoWork += (object sender, DoWorkEventArgs args) =>
            {
                result = producer();
            };

            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs args) =>
            {
                if (args.Error != null)
                {
                    Debug.WriteLine("ERROR:  " + args.Error.Message);
                }

                consumer(result);
            };

            worker.RunWorkerAsync();
        }
    }
}
