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
		Public Shared customDrawImage As Boolean
		Public Shared customDrawText As Boolean
		Public Shared customDrawTable As Boolean
		Public Shared customDrawPicture As Boolean
		Public Shared customDrawTextBox As Boolean
		Public Shared customDrawSeparator As Boolean
		Public Shared customDrawPage As Boolean


		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			richEdit.LoadDocument("Grimm.docx")
			AddHandler richEdit.DocumentLayout.DocumentFormatted, AddressOf DocumentLayout_DocumentFormatted
		End Sub


		#Region "#DocumentFormatted"
		Private Sub DocumentLayout_DocumentFormatted(ByVal sender As Object, ByVal e As EventArgs)

			richEdit.Dispatcher.BeginInvoke(New Action(Sub()
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

		Private Sub CheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			customDrawText = If(textCheckBox.IsChecked = True, True, False)
			richEdit.Refresh()
		End Sub

		Private Sub TableCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			customDrawTable = If(tableCheckBox.IsChecked = True, True, False)
			richEdit.Refresh()
		End Sub

		Private Sub FloatingCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			customDrawPicture = If(floatingCheckBox.IsChecked = True, True, False)
			richEdit.Refresh()
		End Sub

		Private Sub TextBoxCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			customDrawTextBox = If(textBoxCheckBox.IsChecked = True, True, False)
			richEdit.Refresh()
		End Sub

		Private Sub InlineCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			customDrawImage = If(inlineCheckBox.IsChecked =True, True, False)
			richEdit.Refresh()
		End Sub

		Private Sub PageCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			customDrawPage = If(pageCheckBox.IsChecked = True, True, False)
			richEdit.Refresh()
		End Sub

		Private Sub ListCheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			customDrawSeparator = If(listCheckBox.IsChecked = True, True, False)
			richEdit.Refresh()
		End Sub

		Private Sub CheckbtnCustomDraw_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If checkbtnCustomDraw.IsChecked = True Then
				AddHandler richEdit.BeforePagePaint, AddressOf RichEdit_BeforePagePaint
			Else
				RemoveHandler richEdit.BeforePagePaint, AddressOf RichEdit_BeforePagePaint
			End If
			richEdit.Refresh()
		End Sub

	End Class
End Namespace
