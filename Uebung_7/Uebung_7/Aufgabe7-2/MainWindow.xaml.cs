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

namespace Aufgabe7_2
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private double btn_width { get; set; }
      private double btn_height { get; set; }


      public MainWindow()
      {
         InitializeComponent();
      }

      private void OnFrame_MouseEnter(object sender, MouseEventArgs e)
      {
         double maxLeft = cnv.ActualWidth - btn.ActualWidth;
         double maxTop = cnv.ActualHeight - btn.ActualHeight;
         double minLeft = rect.Width;
         double minTop = rect.Height;
         Point mousePos = Mouse.GetPosition(cnv);

         Random rand_Pos = new Random();

         int posx = rand_Pos.Next((int)maxLeft);
         int posy = rand_Pos.Next((int)maxTop);

         btn_width = btn.ActualWidth;
         btn_height = btn.ActualHeight;

         var pos_max_x = posx + btn_width;
         var pos_max_y = posy + btn_height;

         while (posx < minLeft && posy < minTop || posx < mousePos.X && pos_max_x > mousePos.X && posy < mousePos.Y && pos_max_y > mousePos.Y)
         {
            posx = rand_Pos.Next((int)maxLeft);
            posy = rand_Pos.Next((int)maxTop);

            pos_max_x = posx + btn_width;
            pos_max_y = posy + btn_height;

         }
         Canvas.SetLeft(btn, posx);
         Canvas.SetTop(btn, posy);
      }

      private void OnSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         if (btn_height == 0 || btn_width == 0)
         {
            btn_width = btn.ActualWidth;
            btn_height = btn.ActualHeight;
         }

         if (btn.ActualWidth == 0) return;
         btn.Width = e.NewValue * btn_width;
         btn.Height = e.NewValue * btn_height;
      }
   }
}
