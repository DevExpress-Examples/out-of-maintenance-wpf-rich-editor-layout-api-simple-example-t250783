Imports DevExpress.Xpf.RichEdit
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Layout
Imports System.Drawing

Namespace LayoutAPISimpleExample

    Friend Class MyLayoutPainter
        Inherits PagePainter

        Public Overrides Sub DrawPlainTextBox(ByVal plainTextBox As PlainTextBox)
            If MainWindow.customDrawText = True Then
                Canvas.DrawRectangle(New RichEditPen(System.Windows.Media.Color.FromRgb(141, 179, 226)), plainTextBox.Bounds)
            Else
                MyBase.DrawPlainTextBox(plainTextBox)
            End If
        End Sub

        Public Overrides Sub DrawFloatingPicture(ByVal floatingPicture As LayoutFloatingPicture)
            If MainWindow.customDrawPicture = True Then
                Dim bounds As Rectangle = floatingPicture.Bounds
                Dim startPoint As Point = New Point(bounds.X + Canvas.ConvertToDrawingLayoutUnits(10, DocumentLayoutUnit.Pixel), bounds.Y + bounds.Height - Canvas.ConvertToDrawingLayoutUnits(40, DocumentLayoutUnit.Pixel))
                Dim pEn As RichEditPen = New RichEditPen(System.Windows.Media.Color.FromRgb(220, 20, 60))
                pEn.Thickness = 30
                pEn.DashStyle = RichEditDashStyle.Dash
                Canvas.DrawEllipse(pEn, bounds)
                Canvas.DrawString("Approved", New Font("Courier New", 26), New RichEditBrush(System.Windows.Media.Color.FromRgb(139, 0, 139)), startPoint)
            Else
                MyBase.DrawFloatingPicture(floatingPicture)
            End If
        End Sub

        Public Overrides Sub DrawTableCell(ByVal tableCell As LayoutTableCell)
            If MainWindow.customDrawTable = True Then
                Dim Tbounds As Rectangle = tableCell.Bounds
                Dim x As Integer = Tbounds.X + Tbounds.Width \ 2 - Canvas.ConvertToDrawingLayoutUnits(20, DocumentLayoutUnit.Pixel)
                Dim y As Integer = Tbounds.Y + Tbounds.Height \ 2 - Canvas.ConvertToDrawingLayoutUnits(20, DocumentLayoutUnit.Pixel)
                Dim tableRectangle As Rectangle = New Rectangle(x, y, Canvas.ConvertToDrawingLayoutUnits(20, DocumentLayoutUnit.Pixel), Canvas.ConvertToDrawingLayoutUnits(20, DocumentLayoutUnit.Pixel))
                Canvas.FillEllipse(New RichEditBrush(System.Windows.Media.Color.FromRgb(102, 205, 170)), tableRectangle)
                MyBase.DrawTableCell(tableCell)
            Else
                MyBase.DrawTableCell(tableCell)
            End If
        End Sub

        Public Overrides Sub DrawInlineDrawingObject(ByVal inlinePictureBox As InlineDrawingObjectBox)
            If MainWindow.customDrawImage = True Then
                Dim Ebounds As Rectangle = inlinePictureBox.Bounds
                Dim pen As RichEditPen = New RichEditPen(System.Windows.Media.Color.FromRgb(128, 0, 0), 50)
                pen.DashStyle = RichEditDashStyle.Dot
                Canvas.DrawLine(pen, New Point(Ebounds.X, Ebounds.Y + Ebounds.Height), New Point(Ebounds.X + Ebounds.Width, Ebounds.Y))
                Canvas.DrawLine(pen, New Point(Ebounds.X, Ebounds.Y), New Point(Ebounds.X + Ebounds.Width, Ebounds.Y + Ebounds.Height))
                Dim inlineRect As Rectangle = New Rectangle(Ebounds.X, Ebounds.Y, Ebounds.Width, Ebounds.Height)
                Canvas.DrawRectangle(New RichEditPen(System.Windows.Media.Color.FromRgb(127, 255, 212), 40), inlineRect)
            Else
                MyBase.DrawInlineDrawingObject(inlinePictureBox)
            End If
        End Sub

        Public Overrides Sub DrawTextBox(ByVal textBox As LayoutTextBox)
            If MainWindow.customDrawTextBox = True Then
                Dim StarPoints As Point() = {New Point(textBox.Bounds.X + textBox.Bounds.Width \ 2, textBox.Bounds.Y), New Point(textBox.Bounds.X + textBox.Bounds.Width, textBox.Bounds.Y + textBox.Bounds.Height), New Point(textBox.Bounds.X, textBox.Bounds.Y + textBox.Bounds.Height \ 2), New Point(textBox.Bounds.X + textBox.Bounds.Width, textBox.Bounds.Y + textBox.Bounds.Height \ 2), New Point(textBox.Bounds.X, textBox.Bounds.Y + textBox.Bounds.Height), New Point(textBox.Bounds.X + textBox.Bounds.Width \ 2, textBox.Bounds.Y)}
                Canvas.DrawLines(New RichEditPen(System.Windows.Media.Color.FromRgb(255, 105, 180), 30), StarPoints)
            Else
                MyBase.DrawTextBox(textBox)
            End If
        End Sub

        Public Overrides Sub DrawNumberingListWithSeparatorBox(ByVal numberingListWithSeparatorBox As NumberingListWithSeparatorBox)
            If MainWindow.customDrawSeparator = True Then
                Canvas.FillRectangle(New RichEditBrush(System.Windows.Media.Color.FromRgb(139, 0, 0)), numberingListWithSeparatorBox.Bounds)
            Else
                MyBase.DrawNumberingListWithSeparatorBox(numberingListWithSeparatorBox)
            End If
        End Sub

        Public Overrides Sub DrawPage(ByVal page As LayoutPage)
            If MainWindow.customDrawPage = True Then
                Dim inlineRect As Rectangle = New Rectangle(100, 100, 150, 200)
                Canvas.DrawRectangle(New RichEditPen(System.Windows.Media.Color.FromRgb(127, 255, 212), Canvas.ConvertToDrawingLayoutUnits(4, DocumentLayoutUnit.Pixel)), Canvas.ConvertToDrawingLayoutUnits(inlineRect, DocumentLayoutUnit.Pixel))
            End If

            MyBase.DrawPage(page)
        End Sub
    End Class
End Namespace
