using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MMenu : ContextPopup, IColorSchemeComponent
    {
        IList<MMenuItem> _items = new List<MMenuItem>();

        public MMenu(EvasObject parent) : base(parent)
        {
            Style = Styles.Material;
            IsHorizontal = false;
            AutoHide = true;
            MColors.AddColorSchemeComponent(this);
        }

        public new void Clear()
        {
            base.Clear();
            _items.Clear();
        }

        void IColorSchemeComponent.OnColorSchemeChanged(bool fromConstructor)
        {
            // TBD : if support additional themes, may need to change the color of the item text.
        }

        public MMenuItem AddItem(string text, bool divider = false)
        {
            return AddItem(text, null, divider);
        }

        public MMenuItem AddItem(string text, string icon, bool divider = false)
        {
            ContextPopupItem cpi;

            if (string.IsNullOrEmpty(icon))
            {
                cpi = Append(text);
            }
            else
            {
                var img = new Image(this.Parent);
                img.Load(Path.Combine(Tizen.Applications.Application.Current.DirectoryInfo.Resource, icon));
                cpi = Append(text, img);
            }

            if (divider)
            {
                cpi.SetPartColor("divider", MColors.Current.OnSurfaceColor.WithAlpha(0.12));
            }

            var item = new MMenuItem(cpi, divider);
            _items.Add(item);
            return item;
        }

        public IList<MMenuItem> Contents
        {
            get => _items;
        }
    }

    public class MMenuItem
    {
        ContextPopupItem _item;

        public string Text { get => _item.Text; }

        public EvasObject Icon { get => _item.Icon; }

        public bool Divider { get; private set; }

        event EventHandler Selected;

        public MMenuItem(ContextPopupItem item, bool divider)
        {
            _item = item;
            Divider = divider;
            item.Selected += (s, e) =>
            {
                Selected?.Invoke(s, e);
            };
        }
    }
}
