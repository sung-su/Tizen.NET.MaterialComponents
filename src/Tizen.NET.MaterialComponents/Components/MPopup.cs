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
        PopupItem _item;

        public string Text { get => _item.Text; }

        public EvasObject Icon { get => _item.Icon; }

        public MPopupItem(PopupItem item)
        {
            _item = item;
        }
    }

    public class MPopup : Popup, IColorSchemeComponent
    {
        IList<MPopupItem> _items;

        public MPopup(EvasObject parent, MPopupDirection direction) : base(parent)
        {
            if (direction == MPopupDirection.Bottom)
            {
                Orientation = PopupOrientation.Bottom;
            }
            else
            {
                Orientation = PopupOrientation.Right;
            }
            AllowEvents = false; // mobile, modal, scrim

            Style = Styles.Material;
            MColors.AddColorSchemeComponent(this);


            var p = new Popup(parent);

            p.SetContent();
        }

        public MPopupDirection Direction
        {
            get
            {
                if (Orientation == PopupOrientation.Bottom)
                {
                    return MPopupDirection.Bottom;
                }
                return MPopupDirection.Side;
            }
            set
            {
                if (value == MPopupDirection.Bottom)
                {
                    Orientation = PopupOrientation.Bottom;
                }
                else
                {
                    Orientation = PopupOrientation.Right;
                }
            }
        }

        public MPopupItem AddItem(string text, string icon = null)
        {
            PopupItem pi;

            if (string.IsNullOrEmpty(icon))
            {
                pi = Append(text);
            }
            else
            {
                var img = new Image(this.Parent);
                img.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, icon));
                pi = Append(text, img);
            }

            var item = new MPopupItem(pi);
            _items.Add(item);
            return item;
        }

        public IList<MPopupItem> Contents
        {
            get
            {
                return _items;
            }
        }

        void UpdateContents()
        {
            RemoveChild(this);
            if (_items.Count > 0)
            {
                foreach (var item in _items)
                {
                    if (string.IsNullOrEmpty(item.Icon))
                    {
                        Append(item.Text);
                    }
                    else
                    {
                        var img = new Image(this.Parent);
                        img.Load(Path.Combine(Applications.Application.Current.DirectoryInfo.Resource, item.Icon));
                        Append(item.Text, img);
                    }
                }
            }
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            //bool isDefaultBackgroundColor = fromConstructor || _defaultBackgroundColor == GetPartColor(Parts.Widget.Background);
            //bool isDefaultTextColor = fromConstructor || GetPartColor(Parts.Widget.Text) == _defaultTextColor;

            //_defaultBackgroundColor = MColors.Current.OnBackgroundColor.WithAlpha(0.7);
            //_defaultTextColor = MColors.Current.OnPrimaryColor;

            //if (isDefaultBackgroundColor)
            //{
            //    SetPartColor(Parts.Widget.Background, _defaultBackgroundColor);
            //}
            //if (isDefaultTextColor)
            //{
            //    SetPartColor(Parts.Widget.Text, _defaultTextColor);
            //}
        }
    }
}
