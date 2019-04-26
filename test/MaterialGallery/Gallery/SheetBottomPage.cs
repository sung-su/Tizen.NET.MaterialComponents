using ElmSharp;
using System.Collections.Generic;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class SheetBottomPage : BaseGalleryPage
    {
        public override string Name => "SheetPage(Bottom) Gallery";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box bg = new Box(window)
            {
                BackgroundColor = Color.White
            };
            conformant.SetContent(bg);
            bg.Show();

            Box mainContents = new Box(window);
            mainContents.Show();
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
            //mai.Resize(300, 500);
            //mai.Move(200, 250);
            var lb1 = new Label(window)
            {
                Text = "BottomSheet",
                BackgroundColor = Color.White,
            };
            lb1.Show();
            mainContents.PackEnd(mai);
            mainContents.PackEnd(lb1);
            //bg.SetContent(mainContents);
            bg.PackEnd(mainContents);

            var sheet = new MSheet(window, SheetDirection.Bottom)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            Box sheetContents = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            var lb = new Label(window)
            {
                Text = "This is Sheet",
                BackgroundColor = Color.White,
            };
            lb.Show();
            sheetContents.PackEnd(lb);
            sheet.Contents = sheetContents;
            sheet.Show();
            bg.SetContent(sheet);
            //bg.PackEnd(sheet);
        }

        public override void TearDown()
        {
            base.TearDown();
        }
    }
}
