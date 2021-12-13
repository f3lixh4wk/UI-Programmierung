using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Aufgabe8_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			rb_Sin.IsChecked = true;
			DrawPlot(Math.Sin);
		}

		private void DrawPlot(Func<double, double> function)
		{
			plot.Function = function;
		}

		private void TextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			TextBox tb = (TextBox)sender;
			if(tb == tb_XMin && tb_XMin.Text.Length != 0)
				plot.XMin = Convert.ToDouble(tb.Text);
			else if (tb == tb_XMax && tb_XMax.Text.Length != 0)
				plot.XMax = Convert.ToDouble(tb.Text);
			else if (tb == tb_YMin && tb_YMin.Text.Length != 0)
				plot.YMin = Convert.ToDouble(tb.Text);
			else if (tb == tb_YMax && tb_YMax.Text.Length != 0)
				plot.YMax = Convert.ToDouble(tb.Text);
			else if(tb_DT.Text.Length != 0)
				plot.DeltaX = Convert.ToDouble(tb.Text);
		}

		private void rb_Checked(object sender, RoutedEventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			if (rb == rb_Sin)
				DrawPlot(Math.Sin);
			else if (rb == rb_Cos)
				DrawPlot(Math.Cos);
			else if (rb == rb_Tan)
				DrawPlot(Math.Tan);
		}
	}

	public class Plot : Canvas
	{
		private double xMin = 0, xMax = 0, yMin = 0, yMax = 0, dt = 0;
		private Func<double, double> function;
		private Pen axesPen, gridPen, graphPen;
		Rect plotArea;
		Rect graphArea;

		//Properties
		public double XMin
		{
			get { return xMin; }
			set
			{
				xMin = value;
				InvalidateAll();
			}
		}

		public double XMax
		{
			get { return xMax; }
			set
			{
				xMax = value;
				InvalidateAll();
			}
		}

		public double YMin
		{
			get { return yMin; }
			set
			{
				yMin = value;
				InvalidateAll();
			}
		}

		public double YMax
		{
			get { return yMax; }
			set
			{
				yMax = value;
				InvalidateAll();
			}
		}

		public double DeltaX
		{
			get { return dt; }
			set
			{
				dt = value;
				InvalidateAll();
			}
		}

		public Func<double, double> Function { get { return function; } set 
			{ 
				function = value;
				InvalidateAll();
			} }

		public Plot()
		{
			axesPen = new Pen(Brushes.Black, 1.5);
			gridPen = new Pen(Brushes.Black, 0.8);
			graphPen = new Pen(Brushes.Black, 1.0);
			gridPen.DashStyle = DashStyles.Dash;
			Width = 770;
			Height = 400;
		}

		private void InvalidateAll()
		{
			InvalidateVisual();
		}

		private TranslateTransform TransformPlotArea(DrawingContext dc)
		{
			plotArea.Width = Width;
			plotArea.Height = Height - 40;

			TranslateTransform transformPlot = new TranslateTransform();
			transformPlot.X = plotArea.Left;
			transformPlot.Y = plotArea.Bottom;
			return transformPlot;
		}

		private void TransformGraphArea()
		{
			graphArea = plotArea;
			graphArea.Width = plotArea.Width - 46;
			graphArea.X = plotArea.Left + 30;
			graphArea.Height = plotArea.Height - 30;
			graphArea.Y = plotArea.Top;
		}

		protected override void OnRender(DrawingContext dc)
		{
			plotArea.Width = Width;
			plotArea.Height = Height - 20;
			TransformGraphArea();

			DrawAxes(dc);
			DrawGrid(dc);

			if(function != null)
			{
				List<Point> points = GetPoints();
				DrawPolyline(dc, graphPen, points);
			}
		}

		private void DrawAxes(DrawingContext dc)
		{
			DrawXAxis(dc);
			DrawYAxis(dc);
		}

		private void DrawXAxis(DrawingContext dc)
		{
			Line xAxisLine = new Line();
			xAxisLine.X1 = graphArea.Left;
			xAxisLine.Y1 = graphArea.Bottom;
			xAxisLine.X2 = graphArea.Right;
			xAxisLine.Y2 = graphArea.Bottom;

			Line xAxisArrow1 = new Line();
			xAxisArrow1.X1 = xAxisLine.X2;
			xAxisArrow1.Y1 = xAxisLine.Y2;
			xAxisArrow1.X2 = xAxisLine.X2 - 20;
			xAxisArrow1.Y2 = xAxisLine.Y2 + 10;

			Line xAxisArrow2 = new Line();
			xAxisArrow2.X1 = xAxisLine.X2;
			xAxisArrow2.Y1 = xAxisLine.Y2;
			xAxisArrow2.X2 = xAxisLine.X2 - 20;
			xAxisArrow2.Y2 = xAxisLine.Y2 - 9;

			dc.DrawLine(axesPen, new Point(xAxisLine.X1, xAxisLine.Y1), new Point(xAxisLine.X2, xAxisLine.Y2));
			dc.DrawLine(axesPen, new Point(xAxisArrow1.X1, xAxisArrow1.Y1), new Point(xAxisArrow1.X2, xAxisArrow1.Y2));
			dc.DrawLine(axesPen, new Point(xAxisArrow2.X1, xAxisArrow2.Y1), new Point(xAxisArrow2.X2, xAxisArrow2.Y2));
		}

		private void DrawYAxis(DrawingContext dc)
		{
			Line yAxisLine = new Line();
			yAxisLine.X1 = graphArea.Left;
			yAxisLine.Y1 = graphArea.Bottom;
			yAxisLine.X2 = graphArea.Left;
			yAxisLine.Y2 = graphArea.Top;

			Line yAxisArrow1 = new Line();
			yAxisArrow1.X1 = yAxisLine.X2;
			yAxisArrow1.Y1 = yAxisLine.Y2;
			yAxisArrow1.X2 = yAxisLine.X2 + 10;
			yAxisArrow1.Y2 = yAxisLine.Y2 + 20;

			Line yAxisArrow2 = new Line();
			yAxisArrow2.X1 = yAxisLine.X2;
			yAxisArrow2.Y1 = yAxisLine.Y2;
			yAxisArrow2.X2 = yAxisLine.X2 - 9;
			yAxisArrow2.Y2 = yAxisLine.Y2 + 20;

			dc.DrawLine(axesPen, new Point(yAxisLine.X1, yAxisLine.Y1), new Point(yAxisLine.X2, yAxisLine.Y2));
			dc.DrawLine(axesPen, new Point(yAxisArrow1.X1, yAxisArrow1.Y1), new Point(yAxisArrow1.X2, yAxisArrow1.Y2));
			dc.DrawLine(axesPen, new Point(yAxisArrow2.X1, yAxisArrow2.Y1), new Point(yAxisArrow2.X2, yAxisArrow2.Y2));
		}

		private void DrawGrid(DrawingContext dc)
		{
			double abstandY = graphArea.Height / 11;
			double abstandX = graphArea.Width / 11;
			for (int i = 1; i <= 11; ++i)
			{
				dc.DrawLine(gridPen, new Point(graphArea.Left + (i * abstandX), graphArea.Bottom), new Point(graphArea.Left + (i * abstandX), graphArea.Top));
				dc.DrawLine(gridPen, new Point(graphArea.Left, graphArea.Bottom - (i * abstandY)), new Point(graphArea.Right, graphArea.Bottom - (i * abstandY)));
			}

			double differenzX = (XMax - XMin) / 11;
			double differenzY = (YMax - YMin) / 11;
			if(differenzX != 0 || differenzY != 0)
			{
				for (int i = 0; i <= 11; ++i)
				{
					double xValue = XMin + (i * differenzX);
					dc.DrawText(new FormattedText(xValue.ToString("0.0"), CultureInfo.GetCultureInfo("de-DE"), FlowDirection.LeftToRight, new Typeface("Verdana"), 13, Brushes.Black, 1.25),
					new Point((graphArea.Left - 15) + (i * abstandX), graphArea.Bottom + 5));

					double yValue = YMin + (i * differenzY);
					dc.DrawText(new FormattedText(yValue.ToString("0.0"), CultureInfo.GetCultureInfo("de-DE"), FlowDirection.LeftToRight, new Typeface("Verdana"), 13, Brushes.Black, 1.25),
					new Point((graphArea.Left - 30), (graphArea.Bottom - 10) - (i * abstandY)));
				}
			}
		}

		private void DrawPolyline(DrawingContext dc, Pen pen, List<Point> points)
		{
			PathGeometry geometry = new PathGeometry();
			PathFigure figure = null;
			PolyLineSegment segment = null;
			foreach(Point point in points)
			{
				if(!double.IsNaN(point.Y))
				{
					if(figure == null)
					{
						figure = new PathFigure();
						figure.StartPoint = point;
						geometry.Figures.Add(figure);
						segment = new PolyLineSegment();
						figure.Segments.Add(segment);
					}

					Point point1 = new Point();
					point1.X = point.X;

					if (point.Y < graphArea.Top)
						point1.Y = graphArea.Top;
					else if (point.Y > graphArea.Bottom)
						point1.Y = graphArea.Bottom;
					else
						point1.Y = point.Y;

					segment.Points.Add(point1);
				}
				else
				{
					figure = null;
					segment = null;
				}
			}
			dc.DrawGeometry(null, pen, geometry);
		}

		private List<Point> GetPoints()
		{
			List<Point> points = new List<Point>();
			int anzahlStuetzstellen = (int)Math.Ceiling((XMax - XMin) / dt);
			for(int i = 0; i < anzahlStuetzstellen; ++i)
			{
				double x = (i * dt) * (graphArea.Width / (XMax - XMin)) + graphArea.Left;
				double y = 1 - (Function(XMin + (i * dt)) * (graphArea.Height / (YMax - YMin))) + graphArea.Height / 2;
				points.Add(new Point(x, y));
			}
			return points;
		}
	}
}
