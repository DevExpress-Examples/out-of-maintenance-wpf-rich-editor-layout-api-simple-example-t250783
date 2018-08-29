using DevExpress.Xpf.RichEdit;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Layout;
using System.Drawing;

namespace LayoutAPISimpleExample {
    #region #MyLayoutPainter
    class MyLayoutPainter : PagePainter {
        public override void DrawPlainTextBox(PlainTextBox plainTextBox) {
            Canvas.DrawRectangle(new RichEditPen(System.Windows.Media.Color.FromRgb(141, 179, 226)), plainTextBox.Bounds);
            //base.DrawPlainTextBox(plainTextBox);
        }
        public override void DrawFloatingPicture(LayoutFloatingPicture floatingPicture) {
            base.DrawFloatingPicture(floatingPicture);
            Rectangle bounds = floatingPicture.Bounds;
            Point startPoint = new Point(bounds.X + Canvas.ConvertToDrawingLayoutUnits(40, DocumentLayoutUnit.Pixel), bounds.Y + bounds.Height - Canvas.ConvertToDrawingLayoutUnits(120, DocumentLayoutUnit.Pixel));
            Canvas.DrawString("Approved", new Font("Courier New", 26), new RichEditBrush(System.Windows.Media.Colors.DarkRed), startPoint);
        }
    }
    #endregion #MyLayoutPainter
}
