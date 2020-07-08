using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace PhotoAlbum.Core.DoubleBufferEquque
{
    public class DoubleBufferEqueueChche
    {
        public readonly Queue<string> Queue1 = new Queue<string>();
        public readonly Queue<string> Queue2 = new Queue<string>();
        ManualResetEvent lockOne = new ManualResetEvent(true);
        ManualResetEvent lockTwo = new ManualResetEvent(false);
        AutoResetEvent _AutoReset = new AutoResetEvent(true);

        private volatile Queue<string> _currentQueue = new Queue<string>();
        public DoubleBufferEqueueChche()
        {
            this._currentQueue = Queue1;
            var backgroundworker = new BackgroundWorker();
            backgroundworker.DoWork += DoWork;
            backgroundworker.RunWorkerAsync();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                this._AutoReset.WaitOne();
                this.lockTwo.Reset();
                this.lockOne.WaitOne();

                var readqueue = _currentQueue;
                _currentQueue = (_currentQueue == Queue1) ? Queue2 : Queue1;
                this.lockTwo.Set();

                WriteToConsole(readqueue);
            }
        }

        private void WriteToConsole(Queue<string> readqueue)
        {
            while (readqueue.Count > 0)
            {
                var item = readqueue.Dequeue();
                Console.WriteLine($"{readqueue.GetHashCode()}\t{item}");
                Thread.Sleep(110);
            }
        }
        public void Equeue(string item)
        {
            this.lockTwo.WaitOne();
            this.lockOne.Reset();
            _currentQueue.Enqueue(item);
            lockOne.Set();
            _AutoReset.Set();
        }
    }
}
