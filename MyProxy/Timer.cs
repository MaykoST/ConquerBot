using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace MyProxy
{
    class Timer
    {
        private Thread T;
        public Boolean Running { get; set; }

        public GameProxy Proxy { get; set; }

        public DateTime LastCursorMove { get; set; }
        public int NextMove { get; set; }

        public Timer()
        {
            T = new Thread(new ThreadStart(run));
            LastCursorMove = DateTime.Now;
            NextMove = 1;
        }

        public void Start()
        {
            Running = true;
            T.Start();
        }

        public void Stop()
        {
            Running = false;
            T.Join();
        }

        public void run()
        {
            while (Running)
            {
                try
                {
                    foreach (Client cli in Proxy.ClientList)
                    {
                        if (cli.MyChar != null)
                        {
                            cli.MyChar.Step();

                            if (cli.MyChar.MoveMouse)
                            {
                                if (cli.MyChar.Booting || cli.MyChar.Mining || cli.MyChar.BlueMouse)
                                {
                                    if (LastCursorMove.AddMinutes(1) < DateTime.Now)
                                    {
                                        if (NextMove == 1)
                                        {
                                            Cursor.Position = new Point(620, 350);
                                            NextMove++;
                                        }
                                        else if (NextMove == 2)
                                        {
                                            Cursor.Position = new Point(820, 350);
                                            NextMove++;
                                        }
                                        else if (NextMove == 3)
                                        {
                                            Cursor.Position = new Point(620, 550);
                                            NextMove++;
                                        }
                                        else if (NextMove == 4)
                                        {
                                            Cursor.Position = new Point(820, 550);
                                            NextMove = 1;
                                        }

                                        LastCursorMove = DateTime.Now;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Exception(ex);
                }

                Thread.Sleep(100);
            }
        }
    }
}
