using DevExpress.Xpf.RichEdit;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Layout;
using System.Drawing;
using System.Windows.Media;

namespace LayoutAPISimpleExample
{
    class MyLayoutPainter : PagePainter
    {
        public override void DrawPlainTextBox(PlainTextBox plainTextBox)
        {
            if (MainWindow.customDrawText == true)
            {
                Canvas.DrawRectangle(new RichEditPen(System.Windows.Media.Color.FromRgb(141, 179, 226)), plainTextBox.Bounds);
            }
            else base.DrawPlainTextBox(plainTextBox);
        }

        public override void DrawFloatingPicture(LayoutFloatingPicture floatingPicture)
        {
            if (MainWindow.customDrawPicture == true)
            {
                Rectangle bounds = floatingPicture.Bounds;
                Point startPoint = new Point(bounds.X + Canvas.ConvertToDrawingLayoutUnits(10, DocumentLayoutUnit.Pixel), bounds.Y + bounds.Height - 
                    Canvas.ConvertToDrawingLayoutUnits(40, DocumentLayoutUnit.Pixel));
                RichEditPen pEn = new RichEditPen(System.Windows.Media.Color.FromRgb(220, 20, 60));
                pEn.Thickness = 30;
                pEn.DashStyle = RichEditDashStyle.Dash;
                Canvas.DrawEllipse(pEn, bounds);
                Canvas.DrawString("Approved", new Font("Courier New", 26), new RichEditBrush(System.Windows.Media.Color.FromRgb(139, 0, 139)), startPoint);
            }
            else
                base.DrawFloatingPicture(floatingPicture);
        }

        public override void DrawTableCell(LayoutTableCell tableCell)
        {
            if (MainWindow.customDrawTable == true)
            {
                Rectangle Tbounds = tableCell.Bounds;

                int x = Tbounds.X + Tbounds.Width / 2 - Canvas.ConvertToDrawingLayoutUnits(20, DocumentLayoutUnit.Pixel);
                int y = Tbounds.Y + Tbounds.Height / 2 - Canvas.ConvertToDrawingLayoutUnits(20, DocumentLayoutUnit.Pixel);
                Rectangle tableRectangle = new Rectangle(x, y, Canvas.ConvertToDrawingLayoutUnits(20, DocumentLayoutUnit.Pixel),
                    Canvas.ConvertToDrawingLayoutUnits(20, DocumentLayoutUnit.Pixel));

                Canvas.FillEllipse(new RichEditBrush(System.Windows.Media.Color.FromRgb(102, 205, 170)), tableRectangle);
                base.DrawTableCell(tableCell);
            }
            else
                base.DrawTableCell(tableCell);
        }

        public override void DrawInlinePictureBox(InlinePictureBox inlinePictureBox)
        {
            if (MainWindow.customDrawImage == true)
            {
                Rectangle Ebounds = inlinePictureBox.Bounds;
                RichEditPen pen = new RichEditPen(System.Windows.Media.Color.FromRgb(128, 0, 0), 50);
                pen.DashStyle = RichEditDashStyle.Dot;
                Canvas.DrawLine(pen, new Point(Ebounds.X, Ebounds.Y + Ebounds.Height), new Point(Ebounds.X + Ebounds.Width, Ebounds.Y));
                Canvas.DrawLine(pen, new Point(Ebounds.X, Ebounds.Y), new Point(Ebounds.X + Ebounds.Width, Ebounds.Y + Ebounds.Height));
                Rectangle inlineRect = new Rectangle(Ebounds.X, Ebounds.Y, Ebounds.Width, Ebounds.Height);
                Canvas.DrawRectangle(new RichEditPen(System.Windows.Media.Color.FromRgb(127, 255, 212), 40), inlineRect);
            }
            else
                base.DrawInlinePictureBox(inlinePictureBox);
        }

        public override void DrawTextBox(LayoutTextBox textBox)
        {
            if (MainWindow.customDrawTextBox == true)
            {
                Point[] StarPoints =
                    {
                new Point(textBox.Bounds.X+textBox.Bounds.Width/2,textBox.Bounds.Y),
                new Point(textBox.Bounds.X+textBox.Bounds.Width,textBox.Bounds.Y+textBox.Bounds.Height),
                new Point(textBox.Bounds.X,textBox.Bounds.Y+textBox.Bounds.Height/2),
                new Point(textBox.Bounds.X+textBox.Bounds.Width,textBox.Bounds.Y+textBox.Bounds.Height/2),
                new Point(textBox.Bounds.X,textBox.Bounds.Y+textBox.Bounds.Height),
                new Point(textBox.Bounds.X+textBox.Bounds.Width/2,textBox.Bounds.Y)
                    };
                Canvas.DrawLines(new RichEditPen(System.Windows.Media.Color.FromRgb(255, 105, 180), 30), StarPoints);
            }
            else
                base.DrawTextBox(textBox);
        }

        public override void DrawNumberingListWithSeparatorBox(NumberingListWithSeparatorBox numberingListWithSeparatorBox)
        {
            if (MainWindow.customDrawSeparator == true) Canvas.FillRectangle(new RichEditBrush(System.Windows.Media.Color.FromRgb(139, 0, 0)), 
                numberingListWithSeparatorBox.Bounds);
            else base.DrawNumberingListWithSeparatorBox(numberingListWithSeparatorBox);
        }

        public override void DrawPage(LayoutPage page)
        {
            if (MainWindow.customDrawPage == true)
            {
                Rectangle inlineRect = new Rectangle(100, 100, 150, 200);
                Canvas.DrawRectangle(new RichEditPen(System.Windows.Media.Color.FromRgb(127, 255, 212), Canvas.ConvertToDrawingLayoutUnits(4, DocumentLayoutUnit.Pixel)), 
                    Canvas.ConvertToDrawingLayoutUnits(inlineRect, DocumentLayoutUnit.Pixel));
            }
            base.DrawPage(page);
        }
    }
}
