using CoreShape.Extensions.SkiaSharp;
using CoreShape.Graphics;
using CoreShape.Shapes;
using CoreShape.Shapes.Interfaces;
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
using WpfPaintApp.ViewModels;

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
        (DataContext as MainWindowViewModel)?.Draw(new SkiaGraphics(e.Surface.Canvas));
    }
}
