using CoreShape;
using CoreShape.Extensions.SkiaSharp;
using CoreShape.Graphics;
using CoreShape.Shapes;
using CoreShape.Shapes.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using SkiaSharp.Views.Desktop;
using SkiaSharp.Views.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfPaintApp.ViewModels;

public class MainWindowViewModel : BindableBase
{
    //描画する図形をListに定義
    private IList<IShape> _shapes = new[]{
        new OvalShape(new Rectangle(100, 100, 200, 150))
        {
            Stroke = new Stroke(Color.Red, 2),
            //Fill = new Fill(CoreShape.Color.LightSkyBlue)
        },
        new RectangleShape(new Rectangle(350, 100, 100, 150))
        {
            Stroke = new Stroke(Color.Black, 2),
            Fill = new Fill(Color.LightPink)
        },
    };

    private IShape? _activeShape;
    private Point _oldPoint;

    public DelegateCommand<object> MouseMoveCommand { get; private set; }

    public MainWindowViewModel()
    {
        MouseMoveCommand = new DelegateCommand<object>(MouseMove);
    }

    public void Draw(IGraphics graphics)
    {
        graphics.ClearCanvas(Color.Ivory);
        foreach (var shape in _shapes)
        {
            shape.Draw(graphics);
        }
    }

    private void MouseMove(object param)
    {
        var element = param as SKElement;
        if (element is null)
        {
            return;
        }

        // マウスの座標を取得
        var position = Mouse.GetPosition(element);
        var currentPoint = new Point((float)position.X, (float)position.Y);
        
        if (Mouse.LeftButton == MouseButtonState.Pressed)
        {
            // 左ボタン描画中、_activeShapeがあればドラッグ処理を実行して描画更新
            if (_activeShape is null)
            {
                return;
            }
            _activeShape.Drag(_oldPoint, currentPoint);
            element.InvalidateVisual();
        }
        else
        {
            // カーソルと_activeShapeを一旦初期化
            element.Cursor = Cursors.Arrow;
            _activeShape = null;

            // 当たり判定
            foreach (var shape in _shapes)
            {
                if (shape.HitTest(currentPoint))
                {
                    // ヒットしたら十字矢印のカーソルに変更
                    // ヒットした図形を_activeShapeに入れる
                    element.Cursor= Cursors.SizeAll;
                    _activeShape= shape;
                    break;
                }
            }
        }
        // 1フレーム前のポインタを更新
        _oldPoint = currentPoint;
    }
}
