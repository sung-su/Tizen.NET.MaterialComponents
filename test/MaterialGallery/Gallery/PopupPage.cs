using ElmSharp;
using System.Collections.Generic;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class PopupPage2 : BaseGalleryPage
    {
        public override string Name => "PopupPage2 Gallery";

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

            #region Popup
            MPopup popup1 = new MPopup(window, MPopupDirection.Bottom);
            List<MPopupItem> list1 = new List<MPopupItem>();
            list1.Add(new MPopupItem("Share", "icon.png"));
            list1.Add(new MPopupItem("Get link", "icon.png"));
            list1.Add(new MPopupItem("Edit name", "icon.png"));
            list1.Add(new MPopupItem("Delete collection", "icon.png"));
            popup1.Contents = list1;

            MPopup popup2 = new MPopup(window, MPopupDirection.Side);
            List<MPopupItem> list2 = new List<MPopupItem>();
            list2.Add(new MPopupItem("Event", "icon.png"));
            list2.Add(new MPopupItem("Personal", "icon.png"));
            list2.Add(new MPopupItem("Project", "icon.png"));
            list2.Add(new MPopupItem("Reminders", "icon.png"));
            list2.Add(new MPopupItem("Work", "icon.png"));
            popup2.Contents = list2;


            MPopup popup3 = new MPopup(window, MPopupDirection.Side);
            List<MPopupItem> list3 = new List<MPopupItem>();
            list3.Add(new MPopupItem());
            list3.Add(new MPopupItem("text"));
            list3.Add(new MPopupItem("", "icon.png"));
            list3.Add(new MPopupItem("text", "icon.png"));
            list3.Add(new MPopupItem("text", "empty"));
            popup3.Contents = list3;

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
                Text = "Bottom popup",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button1.Show();
            button1.Clicked += (s, e) =>
            {
                popup1.Show();
            };

            MButton button2 = new MButton(window)
            {
                Text = "Side popup",
                MinimumWidth = 600,
                AlignmentY = 0,
                WeightY = 0.3,
            };
            button2.Show();
            button2.Clicked += (s, e) =>
            {
                popup2.Show();
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
                popup3.Show();
            };

            btbox.PackEnd(button1);
            btbox.PackEnd(button2);
            btbox.PackEnd(button3);
            #endregion
        }
    }
}
