using CoreShape.Extensions.SkiaSharp;
using CoreShape.Graphics;
using CoreShape.Shapes;
using SkiaSharp.Views.Desktop;
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

namespace WpfPaintApp.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void skElement_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        var shape = new RectangleShape(100, 100, 200, 150)
        {
            Stroke = new Stroke(CoreShape.Color.Red, 2),
            Fill = new Fill(CoreShape.Color.LightSkyBlue)
        };

        var g = new SkiaGraphics(e.Surface.Canvas);
        shape.Draw(g);
    }
}
