Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace LayoutAPISimpleExample
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            AddHandler richEdit.BeforePagePaint, AddressOf RichEdit_BeforePagePaint
            richEdit.LoadDocument("Grimm.docx")
            AddHandler richEdit.DocumentLayout.DocumentFormatted, AddressOf DocumentLayout_DocumentFormatted
        End Sub


        #Region "#DocumentFormatted"
        Private Sub DocumentLayout_DocumentFormatted(ByVal sender As Object, ByVal e As EventArgs)

            richEdit.BeginInvoke(New Action(Sub()
                Dim pageCount As Integer = richEdit.DocumentLayout.GetFormattedPageCount()
                For i As Integer = 0 To pageCount - 1
                    Dim visitor As New MyDocumentLayoutVisitor()
                    visitor.Visit(richEdit.DocumentLayout.GetPage(i))
                Next i
            End Sub))
        End Sub
        #End Region ' #DocumentFormatted

        Private Sub RichEdit_BeforePagePaint(ByVal sender As Object, ByVal e As DevExpress.XtraRichEdit.BeforePagePaintEventArgs)
            e.Painter = New MyLayoutPainter()
        End Sub
    End Class
End Namespace
