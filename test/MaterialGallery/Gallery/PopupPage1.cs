using ElmSharp;
using System.Collections.Generic;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class PopupPage : BaseGalleryPage
    {
        public override string Name => "PopupPage";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window)
            {
                BackgroundColor = Color.White
            };
            conformant.SetContent(box);
            box.Show();

            var mai = new MActivityIndicator(window)
            {
                IsPulseMode = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            mai.Show();
            mai.PlayPulse();
            mai.Resize(300, 500);
            mai.Move(200, 250);


            List<MPopupItem> list1 = new List<MPopupItem>();
            list1.Add(new MPopupItem("Undo"));
            list1.Add(new MPopupItem("Redo"));
            list1.Add(new MPopupItem("Cut", null, true));
            list1.Add(new MPopupItem("Copy"));
            list1.Add(new MPopupItem("Paste"));

            List<MPopupItem> list2 = new List<MPopupItem>();
            list2.Add(new MPopupItem("Preview", "icon.png"));
            list2.Add(new MPopupItem("Share", "icon.png"));
            list2.Add(new MPopupItem("Get Link", "icon.png"));
            list2.Add(new MPopupItem("Preview", "icon.png", true));
            list2.Add(new MPopupItem("Download", "icon.png"));

            List<MPopupItem> list3 = new List<MPopupItem>();
            list3.Add(new MPopupItem());
            list3.Add(new MPopupItem("text"));
            list3.Add(new MPopupItem("", "icon.png"));
            list3.Add(new MPopupItem("", "", true));
            list3.Add(new MPopupItem("text", "icon.png"));
            list3.Add(new MPopupItem("text", "", true));
            list3.Add(new MPopupItem("", "icon.png", true));
            list3.Add(new MPopupItem("text", "", true));
            list3.Add(new MPopupItem("text", "icon.png", true));

            var pu1 = new MPopup(window, MPopupDirection.Bottom);
            pu1.Contents = list3;
            pu1.Show();

            //pu1.Contents[0];
            //var icon = new Image(window);
            //icon.Load("res/icon.png");

            //box.PackEnd(pu1);

            //var sheet = new MSheet(window, SheetDirection.Side)
            //{
            //    AlignmentX = -1,
            //    AlignmentY = -1,
            //    WeightX = 1,
            //    WeightY = 1,
            //};

            //sheet.Contents = sheetContents;
            //sheet.Show();
            //box.PackEnd(sheet);

        }

        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
