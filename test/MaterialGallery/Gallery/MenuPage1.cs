using ElmSharp;
using System.Collections.Generic;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class MenuPage : BaseGalleryPage
    {
        public override string Name => "MenuPage Gallery";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box bg = new Box(window)
            {
                BackgroundColor = Color.White,
            };
            conformant.SetContent(bg);
            bg.Show();

            var mai = new MActivityIndicator(window)
            {
                BackgroundColor = Color.Transparent,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            mai.Show();
            mai.PlayPulse();
            mai.Move(200, 500);
            mai.Resize(300, 300);
            

            var lb1 = new Label(window)
            {
                Text = "Material Menu test",
                BackgroundColor = Color.White,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            lb1.Move(250, 400);
            lb1.Resize(200, 50);
            lb1.Show();

            var list = new List<MenuItem>();
            list.Add(new MenuItem("a"));
            list.Add(new MenuItem("a"));
            list.Add(new MenuItem("b", "icon.png"));
            list.Add(new MenuItem("b", "icon.png"));
            list.Add(new MenuItem("b", "image.png"));
            list.Add(new MenuItem("c", "d.png"));
            list.Add(new MenuItem("c", "d.png"));

            var menu = new MMenu(window);
            menu.Contents = list;
            menu.Show();

            GestureLayer gl = new GestureLayer(window);
            gl.Attach(window);
            gl.SetTapCallback(GestureLayer.GestureType.Tap, GestureLayer.GestureState.End, (info) =>
            {
                menu.Move(info.X, info.Y);
                menu.Show();
            });
        }

        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
