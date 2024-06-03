using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Dane;
using Logika;
using Logger;

namespace TPW.ViewModel
{
    public class BallViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Ball> Balls { get; set; } = new ObservableCollection<Ball>();

        private BallLogic ballLogic = new BallLogic();

        private DispatcherTimer timer = new DispatcherTimer();

        private Random random = new Random();

        private;

        private DispatcherTimer loggingTimer = new DispatcherTimer();

        public BallViewModel()
        {
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += async (s, e) => await MoveBallsAsync2();
            loggingTimer.Interval = TimeSpan.FromSeconds(1);
            loggingTimer.Tick += async (s, e) => await LogBallsAsync();
            logger = new Logger("C:\\Users\\Gusia\\Desktop\\Współbiegi\\TPW\\Log_Balls.json");
        }

        public void InitializeBalls(int numberOfBalls)
        {
            Balls.Clear();
            for (int i = 0; i < numberOfBalls; i++)
            {
                Balls.Add(ballLogic.CreateBall());
            }
            if (!timer.IsEnabled)
            {
                timer.Start();
            }
            StartLogging();
            if (!loggingTimer.IsEnabled)
            {
                loggingTimer.Start();
            }
        }

        private static readonly object collisionLock = new object();

        private async Task MoveBallsAsync2()
        {
            var moveTasks = new List<Task>();
            foreach (var ball in Balls)
            {
                moveTasks.Add(Task.Run(() =>
                {
                    ballLogic.Move(ball);
                    lock (collisionLock)
                    {
                        ballLogic.CheckAndHandleCollision(ball, Balls);
                    }
                }));
            }
            await Task.WhenAll(moveTasks);
        }
        private async void StartLogging()
        {
            while (true)
            {
                await logger.LogAsync(Balls);
                await Task.Delay(1000); 
            }
        }

        private async Task LogBallsAsync()
        {
            await logger.LogAsync(Balls);
        }

        //  protected virtual void OnPropertyChanged(string propertyName)
        //  {
        //      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //  }
    }
}
