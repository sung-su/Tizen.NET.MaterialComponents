using ElmSharp;
using System.Collections.Generic;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class SheetSidePage : BaseGalleryPage
    {
        public override string Name => "SheetPage(Side) Gallery";

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

            //var mai = new MActivityIndicator(window)
            //{
            //    IsPulseMode = true,
            //    AlignmentX = -1,
            //    AlignmentY = -1,
            //    WeightX = 1,
            //    WeightY = 1,
            //};
            //mai.Show();
            //mai.PlayPulse();
            //mai.Resize(300, 500);
            //mai.Move(200, 250);

            var lb1 = new Label(window)
            {
                Text = "Side Sheet test",
                BackgroundColor = Color.White,
            };
            box.PackEnd(lb1);

            Box sheetContents = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            var lb = new Label(window) {
                Text = "This is Sheet",
                BackgroundColor = Color.White,
            };
            lb.Show();
            sheetContents.PackEnd(lb);

            //var sheet = new MSheet(window, SheetDirection.Side)
            //{
            //    AlignmentX = -1,
            //    AlignmentY = -1,
            //    WeightX = 1,
            //    WeightY = 1,
            //};
            var sheet = new MSheet(window, SheetDirection.Side);

            sheet.Contents = sheetContents;
            sheet.Show();
            box.PackEnd(sheet);
        }

        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
