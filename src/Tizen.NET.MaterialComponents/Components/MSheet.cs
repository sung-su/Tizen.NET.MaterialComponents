using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MSheet2 : MBox, IColorSchemeComponent
    {
        Window _window;
        SheetDirection _direction;
        double _ratio;
        readonly double _minSideRatio = 0.01;     // peek ?
        readonly double _maxSideRatio = 0.8444;   // side sheet ratio, -56px
        readonly double _minBottomRatio = 0.1167; // bottom sheet minimum ratio, 56dp
        readonly double _maxBottomRatio = 0.5;    // bottom sheet maximum ratio

        Color _backgroundColor = Color.Default;
        Color _defaultBackgroundColor;
        Color _defaultBackgroundColorForDisabled;
        Color _defaultTextColor;

        Box _container;
        Box _contents;
        Box _scrim;
        Panel _panel;
        bool _isLock = false;
        bool _scrollerable = true;

        // panel
        // isopen, direction, ratio
        // toggled
        // SetScrollable(), SetScrollableArea(ratio);

        // sheet
        // Main, scrim, Menu, SideSheet, BottomSheet




        public MSheet2(EvasObject parent) : base(parent)
        {
            Style = Styles.Material;
            MColors.AddColorSchemeComponent(this);
            //
            _window = (Window)parent;
            _direction = direction;
            //

            //_container = new Box(parent)
            //{
            //    AlignmentX = -1,
            //    AlignmentY = -1,
            //    WeightX = 1,
            //    WeightY = 1,
            //    BackgroundColor = Color.Red
            //};
            //_container.Show();
            //PackEnd(_container);

            _scrim = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                BackgroundColor = MColors.Current.OnSurfaceColor.WithAlpha(0.32)
            };
            PackEnd(_scrim);

            _panel = new Panel(parent);
            _panel.SetScrollable(!_isLock);
            
            if (direction == SheetDirection.Bottom)
            {
                _panel.Direction = PanelDirection.Bottom;
                _panel.SetScrollableArea(_maxBottomRatio);
            }
            else
            {
                _panel.Direction = PanelDirection.Right;
                _panel.SetScrollableArea(_maxSideRatio);
            }

            _panel.Toggled += (s, e) =>
            {
                UpdateScrim();
                Toggled?.Invoke(this, e);
            };

            _panel.Show();
            PackEnd(_panel);

            var gl = new GestureLayer(_scrim);
            gl.Attach(_scrim);
            gl.SetTapCallback(GestureLayer.GestureType.Tap, GestureLayer.GestureState.End, (info) => {
                _panel.Hide();
            });

            LayoutUpdated += (s, e) =>
            {
                UpdateContentGeometry();
            };
        }

        public event EventHandler Toggled;

        public Box Contents
        {
            get
            {
                return _contents;
            }
            set
            {
                UpdateContent(value);
            }
        }

        public bool IsOpen
        {
            get
            {
                return _panel.IsOpen;
            }
            set
            {
                _panel.IsOpen = value;
            }
        }

        public bool IsLock
        {
            get
            {
                return _isLock;
            }
            set
            {
                _isLock = value;
                _panel.SetScrollable(!_isLock);
            }
        }

        public SheetDirection Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                PanelDirection _panelDirection;
                if (_direction == SheetDirection.Bottom)
                {
                    _panelDirection = PanelDirection.Bottom;
                }
                else
                {
                    _panelDirection = PanelDirection.Bottom;

                }
                _panel.Direction = _panelDirection;
            }
        }

        public double Ratio
        {
            get => _ratio;
            set
            {
                _ratio = value;
                if (_direction == SheetDirection.Side)
                {
                    if (value < _minSideRatio)
                    {
                        _ratio = _minSideRatio;
                    }
                    else if (value > _maxSideRatio)
                    {
                        _ratio = _maxSideRatio;
                    }
                    else
                    {
                        _ratio = value;
                    }
                }
                else
                {
                    if (value < _minBottomRatio)
                    {
                        _ratio = _minBottomRatio;
                    }
                    else if (value > _maxBottomRatio)
                    {
                        _ratio = _maxBottomRatio;
                    }
                    else
                    {
                        _ratio = value;
                    }
                }
                _panel.SetScrollableArea(_ratio);
            }
        }

        void UpdateContent(Box contents)
        {
            if (_contents != null)
            {
                _contents.Hide();
            }

            _contents = contents;

            if (_contents != null)
            {
                _contents.SetAlignment(-1, -1);
                _contents.SetWeight(1, 1);
                if (!_contents.IsVisible)
                {
                    _contents.Show();
                }
                _panel.SetContent(_contents, true);
                UpdateScrim();
                UpdateContentGeometry();
            }
            else
            {
                _panel.SetContent(null, true);
            }
        }

        void UpdateScrim()
        {
            if (_panel.IsOpen)
            {
                _scrim.Show();
                _window.Modal = true;
            }
            else
            {
                _scrim.Hide();
                _window.Modal = false;
            }
        }

        void UpdateContentGeometry()
        {
            if (_contents != null)
            {
                _panel.Geometry = Geometry;
                _scrim.Geometry = Geometry;
            }
        }

        public void OnColorSchemeChanged(bool fromConstructor = false)
        {
            _defaultBackgroundColor = MColors.Current.SurfaceColor;
            _defaultBackgroundColorForDisabled = MColors.Current.SurfaceColor.WithAlpha(0.32);
            _defaultTextColor = MColors.Current.OnSurfaceColor;

            if (_backgroundColor.IsDefault)
            {
                BackgroundColor = _backgroundColor;
            }

            //if (_items != null)
            //{
            //    foreach (var item in _items)
            //    {
            //        if (item.GenItem != null)
            //        {
            //            item.GenItem.SetPartColor(Parts.Widget.BackgroundDisabled, _defaultBackgroundColorForDisabled);
            //            item.GenItem.SetPartColor(Parts.GenListItem.BackgroundActivated, _defaultActiveBackgroundColor);

            //            item.GenItem.SetPartColor(Parts.Widget.Text, _defaultTextColor);
            //            item.GenItem.SetPartColor(Parts.Widget.TextPressed, _defaultActiveTextColor);
            //            item.GenItem.SetPartColor(Parts.Widget.Icon, _defaultTextColor);
            //            item.GenItem.SetPartColor(Parts.Widget.IconPressed, _defaultActiveTextColor);
            //        }
            //    }
            //}
        }
    }

    public enum SheetDirection
    {
        Bottom,
        None,
        Side,
    }
}
