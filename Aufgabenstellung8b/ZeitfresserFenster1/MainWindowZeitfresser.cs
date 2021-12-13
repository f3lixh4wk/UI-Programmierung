using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZeitfresserFenster1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowZeitfresser : Window
    {
        public MainWindowZeitfresser()
        {
            InitializeComponent();
            new Zeitfresser(3);
        }
    }


    public class Zeitfresser
    {
        public Zeitfresser() : this(5) { }
        private int waitingTimeInSeconds;
        private int waitingTimeLeftInSeconds;
        private int waitingTimeDoneInSeconds;

        public Zeitfresser(int minutesToWait)
        {
            waitingTimeInSeconds = minutesToWait * 60;
            waitingTimeLeftInSeconds = minutesToWait * 60;

            for (int minute = 0; minute < minutesToWait; minute++)
            {

                for (int second = 0; second < 60; second++)
                {
                    System.Threading.Thread.Sleep(1000);        //1sec
                    ReportProgress();
                    waitingTimeDoneInSeconds = minute * 60 + second;
                    waitingTimeLeftInSeconds = waitingTimeInSeconds - waitingTimeDoneInSeconds;
                }
            }
        }

        public void ReportProgress()
        {
            double prozent = (double)waitingTimeDoneInSeconds / (double)waitingTimeInSeconds;

            //Teilt dem Output Fenster mit, wie weit der Fortschritt ist.
            //Diese Aufgabe soll später der Backgroundworker mit der Progressbar übernehmen. 
            System.Diagnostics.Debug.WriteLine("Von {0} Minuten sind bereits {1} Sekunden vergangen. Damit gibt es einen Fortschritt von {2:P} Prozent.", waitingTimeInSeconds / 60, waitingTimeDoneInSeconds, prozent);
        }
    }

}


