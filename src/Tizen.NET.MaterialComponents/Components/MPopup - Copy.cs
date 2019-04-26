using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public enum MPopupDirection
    {
        Bottom,
        Side,
    }

    public class MPopupItem
    {
        string _text;
        string _icon;

        public MPopupItem(string text, string icon = null)
        {
            _text = text;
            _icon = icon;
        }
    }

    public class MPopup : MBox, IColorSchemeComponent
    {
        EvasObject _header;
        Popup _popup;
        PopupOrientation _orientation;
        MPopupDirection _direction;
        bool _allowEvent = false;
        bool _scrim = true;
        bool _isOpen = true;

        IList<MPopupItem> _items;                   // input item list
        ObservableCollection<MPopupItem> _contents; // internal imte list

        Color _backgroundColor = Color.Default;
        Color _defaultBackgroundColor;
        Color _defaultBackgroundColorForDisabled;
        Color _defaultTextColor;
        Color _defaultActiveBackgroundColor;
        Color _defaultActiveTextColor;

        event EventHandler Opend;
        event EventHandler Folded;

        public MPopup(EvasObject parent, MPopupDirection direction) : base(parent)
        {
            Direction = direction;
            Scrim = true; // mobile, modal

            _contents = new ObservableCollection<MPopupItem>();

            _popup = new Popup(parent)
            {
                Orientation = _orientation,
                AllowEvents = _allowEvent,
            };

            _popup.ShowAnimationFinished += (s, e) => { Opend?.Invoke(this, e); };
            _popup.OutsideClicked += (s, e) => { _popup.Hide(); };
            _popup.Dismissed += (s, e) => { Folded?.Invoke(this, e); };

            PackEnd(_popup);

            //var gl = new GestureLayer(parent);
            //gl.Attach(parent);
            //gl.SetTapCallback(GestureLayer.GestureType.Tap, GestureLayer.GestureState.End, (info) => {
            //    IsOpen = !IsOpen;
            //});

            LayoutUpdated += (s, e) =>
            {
                UpdateChildGeometry();
            };
            MColors.AddColorSchemeComponent(this);
        }

        public bool IsOpen
        {
            get => _popup.IsVisible;
            set
            {
                if (value)
                {
                    _popup.Show();
                }
                else
                {
                    _popup.Dismiss();
                }
            }
        }

        public override Color BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                Color effectiveColor = _backgroundColor.IsDefault ? _defaultBackgroundColor : _backgroundColor;
                _popup.BackgroundColor = effectiveColor;
            }
        }

        public IList<MPopupItem> Contents
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                UpdateContents();
            }
        }

        public MPopupDirection Direction // choice hide or public
        {
            get
            {
                return _direction;
            }
            set
            {
                if (value == MPopupDirection.Bottom)
                {
                    _orientation = PopupOrientation.Bottom;
                    _direction = MPopupDirection.Bottom;
                }
                else if (value == MPopupDirection.Side)
                {
                    _orientation = PopupOrientation.Right; // navigation drawer => left, side sheet => right
                    _direction = MPopupDirection.Side;
                }
            }
        }

        public bool Scrim // choice hide or public
        {
            get
            {
                return _scrim;
            }
            set
            {
                if (value)
                {
                    _allowEvent = false;
                    _scrim = true;
                }
                else
                {
                    _allowEvent = true;
                    _scrim = false;
                }
            }
        }

        void UpdateContents()
        {
            //if (_items == null)
            //{
            //    _contents.Clear();
            //}
            //else
            //{
            //    for (int i = 0; i < _items.Count; i++)
            //    {
            //        if (_items[i] != _contents[i])
            //        {
            //            //do something
            //        }
            //    }
            //}
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            _defaultBackgroundColor = MColors.Current.SurfaceColor;
            _defaultBackgroundColorForDisabled = MColors.Current.SurfaceColor.WithAlpha(0.32);
            _defaultTextColor = MColors.Current.OnSurfaceColor;
            _defaultActiveBackgroundColor = MColors.Current.PrimaryColor.WithAlpha(0.12);
            _defaultActiveTextColor = MColors.Current.PrimaryColor;

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

        void UpdateChildGeometry()
        {
            int headerHeight = 0;
            if (_header != null)
            {
                headerHeight = _header.MinimumHeight;
                _header.Geometry = new Rect(Geometry.X, Geometry.Y, Geometry.Width, headerHeight);
            }
            _popup.Geometry = new Rect(Geometry.X, Geometry.Y + headerHeight, Geometry.Width, Geometry.Height - headerHeight);
        }
    }
}
