Imports DevExpress.Xpf.RichEdit
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Layout
Imports System.Drawing

Namespace LayoutAPISimpleExample
    #Region "#MyLayoutPainter"
    Friend Class MyLayoutPainter
        Inherits PagePainter

        Public Overrides Sub DrawPlainTextBox(ByVal plainTextBox As PlainTextBox)
            Canvas.DrawRectangle(New RichEditPen(System.Windows.Media.Color.FromRgb(141, 179, 226)), plainTextBox.Bounds)
            'base.DrawPlainTextBox(plainTextBox);
        End Sub
        Public Overrides Sub DrawFloatingPicture(ByVal floatingPicture As LayoutFloatingPicture)
            MyBase.DrawFloatingPicture(floatingPicture)
            Dim bounds As Rectangle = floatingPicture.Bounds
            Dim startPoint As New Point(bounds.X + 40, bounds.Y + bounds.Height - 120)
            Canvas.DrawString("Approved", New Font("Courier New", 26), New RichEditBrush(System.Windows.Media.Colors.DarkRed), startPoint)
        End Sub
    End Class
    #End Region ' #MyLayoutPainter
End Namespace
