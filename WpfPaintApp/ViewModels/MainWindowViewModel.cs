using CoreShape;
using CoreShape.Extensions.SkiaSharp;
using CoreShape.Graphics;
using CoreShape.Shapes;
using CoreShape.Shapes.Interfaces;
using CoreShape.Shapes.ResizeHandles;
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

public enum PenMode
{
    Default,
    Rect,
    Oval
}

public class MainWindowViewModel : BindableBase
{
    private IList<IShape> _shapes = new List<IShape>();

    private IShapePen? _shapePen;
    private IDraggable? _activeShape;
    private Point _oldPoint;

    public DelegateCommand<object> MouseMoveCommand { get; private set; }
    public DelegateCommand<object> MouseDownCommand { get; private set; }
    public DelegateCommand<object> MouseUpCommand { get; private set; }

    public DelegateCommand<object> ShapePenCheckedCommand { get; private set; }

    public MainWindowViewModel()
    {
        MouseMoveCommand = new DelegateCommand<object>(MouseMove);
        MouseDownCommand = new DelegateCommand<object> (MouseDown);
        MouseUpCommand = new DelegateCommand<object>(MouseUp);
        ShapePenCheckedCommand = new DelegateCommand<object>(ShapePenChecked);
    }

    public void Draw(IGraphics graphics)
    {
        graphics.ClearCanvas(Color.Ivory);
        foreach (var shape in _shapes)
        {
            shape.Draw(graphics);
        }
        if (_activeShape is IShapePen shapePen)
        {
            shapePen.Draw(graphics);
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
            // カーソル移動時（カーソルが図形の上にある場合はその図形を、図形の上にない場合はShapePenをアクティブにする）
            _activeShape = _shapePen;
            foreach (var shape in _shapes.Reverse())
            {
                var hitResult = shape.HitTest(currentPoint);
                element.Cursor = SwitchCursor(hitResult);
                if (hitResult is not HitResult.None)
                {
                    _activeShape = shape;
                    break;
                }
            }
        }
        // 1フレーム前のポインタを更新
        _oldPoint = currentPoint;
    }

    private void MouseDown(object param)
    {
        var element = param as SKElement;
        if (element is null)
        {
            return;
        }

        // マウスの座標を取得
        var position = Mouse.GetPosition(element);
        var currentPoint = new Point((float)position.X, (float)position.Y);

        if (Mouse.LeftButton != MouseButtonState.Pressed)
        {
            return;
        }
        // ShapePenがアクティブの場合
        if (_activeShape is IShapePen shapePen)
        {
            shapePen.Locate(currentPoint);
        }
        // 選択状態をリセット（アクティブな図形のみ選択状態にする）
        foreach (var shape in _shapes)
        {
            shape.IsSelected = shape == _activeShape;
        }

        element.InvalidateVisual();
    }

    private void MouseUp(object param)
    {
        var element = param as SKElement;
        if (element is null)
        {
            return;
        }
        if (Mouse.LeftButton != MouseButtonState.Released)
        {
            return;
        }
        if (_activeShape is null)
        {
            return;
        }
        _activeShape.Drop();
        if (_activeShape is IShapePen shapePen)
        {
            var shape = shapePen.CreateShape();
            if (shape is null)
            {
                return;
            }
            _shapes.Add(shape);
            _activeShape = shape;
        }
        element.InvalidateVisual();
    }

    private void ShapePenChecked(object param)
    {
        var mode = (PenMode)param;
        _shapePen = mode switch
        {
            PenMode.Default => null,
            PenMode.Rect => new ShapePen<RectangleShape>(
                    new Stroke(Color.Red, 2.0f),
                    new Fill(Color.LightSeaGreen)
                ),
            PenMode.Oval => new ShapePen<OvalShape>(
                    new Stroke(Color.Green, 1.0f),
                    new Fill(Color.LightYellow)
                ),
            _ => throw new InvalidOperationException()
        };
    }

    private Cursor SwitchCursor(HitResult hitResult)
    {
        return hitResult switch
        {
            HitResult.Body => Cursors.SizeAll,
            HitResult.ResizeN => Cursors.SizeNS,
            HitResult.ResizeS => Cursors.SizeNS,
            HitResult.ResizeE => Cursors.SizeWE,
            HitResult.ResizeW => Cursors.SizeWE,
            HitResult.ResizeNW => Cursors.SizeNWSE,
            HitResult.ResizeSE => Cursors.SizeNWSE,
            HitResult.ResizeNE => Cursors.SizeNESW,
            HitResult.ResizeSW => Cursors.SizeNESW,
            _ => Cursors.Arrow
        };
    }
}
