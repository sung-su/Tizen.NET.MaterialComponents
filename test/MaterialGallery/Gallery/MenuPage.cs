using ElmSharp;
using System.Collections.Generic;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class MenuPage : BaseGalleryPage
    {
        public override string Name => "Menu Gallery";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new ColoredBox(window);
            conformant.SetContent(box);
            box.Show();

            #region ThemeButton
            Box hbox = new Box(window)
            {
                IsHorizontal = true,
                WeightX = 1,
                WeightY = 0.1,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            hbox.Show();
            box.PackEnd(hbox);

            var defaultColor = new MButton(window)
            {
                Text = "default",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            var light = new MButton(window)
            {
                Text = "light",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            var dark = new MButton(window)
            {
                Text = "Dark",
                MinimumWidth = 200,
                WeightY = 1,
                AlignmentY = 0.5
            };
            defaultColor.Show();
            light.Show();
            dark.Show();
            hbox.PackEnd(defaultColor);
            hbox.PackEnd(light);
            hbox.PackEnd(dark);

            defaultColor.Clicked += (s, e) => MColors.Current = MColors.Default;
            light.Clicked += (s, e) => MColors.Current = MColors.Light;
            dark.Clicked += (s, e) => MColors.Current = MColors.Dark;
            #endregion

            #region Menus
            MMenu menu1 = new MMenu(window);
            menu1.AddItem("Undo");
            menu1.AddItem("Redo");
            menu1.AddItem("Cut", true);
            menu1.AddItem("Copy");
            menu1.AddItem("Paste");

            MMenu menu2 = new MMenu(window);
            menu2.AddItem("Preview", "visible.png");
            menu2.AddItem("Share", "add-user-male.png");
            menu2.AddItem("Get Link", "link.png");
            menu2.AddItem("Preview", "copy.png", true);
            menu2.AddItem("Download", "download.png");

            MMenu menu3 = new MMenu(window);
            menu3.AddItem("1. text");
            menu3.AddItem("text");
            menu3.AddItem("2. empty text, icon");
            menu3.AddItem("", "icon.png");
            menu3.AddItem("3. empty text, invalid icon");
            menu3.AddItem("", "cannot.load");
            menu3.AddItem("4. text, icon");
            menu3.AddItem("text", "icon.png");
            menu3.AddItem("5. text, invalid icon");
            menu3.AddItem("text", "cannot.load");
            menu3.AddItem("6. empty text, divider");
            menu3.AddItem("", true);
            menu3.AddItem("7. text, divider");
            menu3.AddItem("text", true);
            menu3.AddItem("8. empty text, icon, divider");
            menu3.AddItem("", "icon.png", true);
            menu3.AddItem("9. empty text, invalid icon, divider");
            menu3.AddItem("", "cannot.load", true);
            menu3.AddItem("10. text, icon, divider");
            menu3.AddItem("text", "icon.png", true);
            menu3.AddItem("11. text, invalid icon, divider");
            menu3.AddItem("text", "cannot.load", true);
            #endregion

            #region Buttons
            Box btbox = new Box(window)
            {
                WeightX = 1,
                WeightY = 0.3,
                AlignmentX = -1,
                AlignmentY = -1,
            };
            btbox.Show();
            box.PackEnd(btbox);

            MButton button1 = new MButton(window)
            {
                Text = "Text list",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button1.Show();
            button1.Clicked += (s, e) =>
            {
                menu1.Show();
            };

            MButton button2 = new MButton(window)
            {
                Text = "Text and icon list",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button2.Show();
            button2.Clicked += (s, e) =>
            {
                menu2.Show();
            };

            MButton button3 = new MButton(window)
            {
                Text = "Items test",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button3.Show();
            button3.Clicked += (s, e) =>
            {
                menu3.Show();
            };

            btbox.PackEnd(button1);
            btbox.PackEnd(button2);
            btbox.PackEnd(button3);
            #endregion
        }
    }
}
