using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Aufgabe8_1
{
   /// <summary>
   /// Interaktionslogik für Zeitfresser.xaml
   /// </summary>
   public partial class Zeitfresser : UserControl
   {
      public Zeitfresser() : this(100) { }
      private int waitingTimeInSeconds;
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      public Zeitfresser(int secondsToWait)
      {
         InitializeComponent();

         backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
         backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
         backgroundWorker.DoWork += backgroundWorker_DoWork;
         backgroundWorker.WorkerReportsProgress = true;
         backgroundWorker.WorkerSupportsCancellation = false;
         waitingTimeInSeconds = secondsToWait;

         backgroundWorker.RunWorkerAsync();
      }

      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
      {
         BackgroundWorker worker = (BackgroundWorker)sender;

         for (int second = 0; second <= waitingTimeInSeconds; second++)
         {
            System.Threading.Thread.Sleep(1000); // 1 sec
            worker.ReportProgress(second);
         }
      }

      private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         pb_progress.Value = e.ProgressPercentage;
         tb_progress.Text = e.ProgressPercentage.ToString() + "%";
      }

      private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         tb_progress.Text = "Done!";
      }
   }
}
