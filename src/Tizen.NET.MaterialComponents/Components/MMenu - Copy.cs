using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MMenu : Layout
    {
        bool _autoHide = true;
        bool _isHorizontal = false;
        EvasObject _parent;
        //bool _cascading;
        //bool Cascading
        //{
        //    get
        //    {
        //        return _cascading;
        //    }
        //    set
        //    {
        //        if (value)
        //            _autoHide = false;
        //        else
        //            _autoHide = true;
        //    }
        //}

        public event EventHandler Folded;

        public void Dismiss()
        {
            _menu.Hide();
            _menu?.Dismiss();
        }

        ContextPopup _menu;
        IList<MenuItem> _items;
        IList<MenuItem> _contents;

        public MMenu(EvasObject parent) : base(parent)
        {
            _parent = parent;

            _menu = new ContextPopup(parent)
            {
                IsHorizontal = _isHorizontal,
                AutoHide = _autoHide,
                Style = "material",
            };
            _menu.Dismissed += (s, e) =>
            {
                Folded?.Invoke(this, e);
            };
            //GestureLayer gl = new GestureLayer(parent);
            //gl.Attach(parent);
            //gl.SetTapCallback(GestureLayer.GestureType.Tap, GestureLayer.GestureState.End, (info) => {
            //    _menu.Move(info.X, info.Y);
            //    _menu.Show();
            //});
            //_menu.Move(0, 0);
            //_menu.Show();
            _contents = new List<MenuItem>();
        }

        public IList<MenuItem> Contents
        {
            get => _items;
            set
            {
                _items = value;
                UpdateContents();
            }
        }

        void UpdateContents()
        {
            if (_items.Count > 0)
            {
                if (_items != _contents)
                {
                    _contents.Clear();
                    _menu.Clear();

                    _contents = _items;
                    foreach (var item in _items)
                    {
                        if (!string.IsNullOrEmpty(item.Icon))
                        {
                            var img = new Image(_parent);
                            if (img.Load(Path.Combine(Applications.Application.Current.DirectoryInfo.Resource, item.Icon)))
                                _menu.Append(item.Text, img);
                        }
                        else
                        {
                            _menu.Append(item.Text);
                        }
                    }
                }
            }
        }
    }

    public class MenuItem
    {
        public string Text { get; set; }

        public string Icon { get; set; }

        public MenuItem(string text, string icon = null)
        {
            Text = text;
            Icon = icon;
        }
    }
}
