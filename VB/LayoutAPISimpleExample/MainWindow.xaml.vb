Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace LayoutAPISimpleExample

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Public Shared customDrawImage As Boolean

        Public Shared customDrawText As Boolean

        Public Shared customDrawTable As Boolean

        Public Shared customDrawPicture As Boolean

        Public Shared customDrawTextBox As Boolean

        Public Shared customDrawSeparator As Boolean

        Public Shared customDrawPage As Boolean

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.richEdit.LoadDocument("Grimm.docx")
            AddHandler Me.richEdit.DocumentLayout.DocumentFormatted, AddressOf Me.DocumentLayout_DocumentFormatted
        End Sub

#Region "#DocumentFormatted"
        Private Sub DocumentLayout_DocumentFormatted(ByVal sender As Object, ByVal e As EventArgs)
            Me.richEdit.Dispatcher.BeginInvoke(New Action(Sub()
                Dim pageCount As Integer = Me.richEdit.DocumentLayout.GetFormattedPageCount()
                For i As Integer = 0 To pageCount - 1
                    Dim visitor As MyDocumentLayoutVisitor = New MyDocumentLayoutVisitor()
                    visitor.Visit(Me.richEdit.DocumentLayout.GetPage(i))
                Next
            End Sub))
        End Sub

#End Region  ' #DocumentFormatted
        Private Sub RichEdit_BeforePagePaint(ByVal sender As Object, ByVal e As DevExpress.XtraRichEdit.BeforePagePaintEventArgs)
            e.Painter = New MyLayoutPainter()
        End Sub

        Private Sub CheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            customDrawText = If(Me.textCheckBox.IsChecked = True, True, False)
            Me.richEdit.Refresh()
        End Sub

        Private Sub TableCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            customDrawTable = If(Me.tableCheckBox.IsChecked = True, True, False)
            Me.richEdit.Refresh()
        End Sub

        Private Sub FloatingCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            customDrawPicture = If(Me.floatingCheckBox.IsChecked = True, True, False)
            Me.richEdit.Refresh()
        End Sub

        Private Sub TextBoxCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            customDrawTextBox = If(Me.textBoxCheckBox.IsChecked = True, True, False)
            Me.richEdit.Refresh()
        End Sub

        Private Sub InlineCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            customDrawImage = If(Me.inlineCheckBox.IsChecked = True, True, False)
            Me.richEdit.Refresh()
        End Sub

        Private Sub PageCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            customDrawPage = If(Me.pageCheckBox.IsChecked = True, True, False)
            Me.richEdit.Refresh()
        End Sub

        Private Sub ListCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            customDrawSeparator = If(Me.listCheckBox.IsChecked = True, True, False)
            Me.richEdit.Refresh()
        End Sub

        Private Sub CheckbtnCustomDraw_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If Me.checkbtnCustomDraw.IsChecked = True Then
                AddHandler Me.richEdit.BeforePagePaint, AddressOf Me.RichEdit_BeforePagePaint
            Else
                RemoveHandler Me.richEdit.BeforePagePaint, AddressOf Me.RichEdit_BeforePagePaint
            End If

            Me.richEdit.Refresh()
        End Sub
    End Class
End Namespace
