using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LayoutAPISimpleExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static bool customDrawImage;
        public static bool customDrawText;
        public static bool customDrawTable;
        public static bool customDrawPicture;
        public static bool customDrawTextBox;
        public static bool customDrawSeparator;
        public static bool customDrawPage;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            richEdit.LoadDocument("Grimm.docx");
            richEdit.DocumentLayout.DocumentFormatted += DocumentLayout_DocumentFormatted;
        }


        #region #DocumentFormatted
        private void DocumentLayout_DocumentFormatted(object sender, EventArgs e)
        {

            richEdit.Dispatcher.BeginInvoke(new Action(() =>
            {
                int pageCount = richEdit.DocumentLayout.GetFormattedPageCount();
                for (int i = 0; i < pageCount; i++)
                {
                    MyDocumentLayoutVisitor visitor = new MyDocumentLayoutVisitor();
                    visitor.Visit(richEdit.DocumentLayout.GetPage(i));
                }
            }));
        }
        #endregion #DocumentFormatted

        private void RichEdit_BeforePagePaint(object sender, DevExpress.XtraRichEdit.BeforePagePaintEventArgs e)
        {
            e.Painter = new MyLayoutPainter();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            customDrawText = (textCheckBox.IsChecked == true) ? true : false;
            richEdit.Refresh();
        }

        private void TableCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            customDrawTable = (tableCheckBox.IsChecked == true) ? true : false;
            richEdit.Refresh();
        }

        private void FloatingCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            customDrawPicture = (floatingCheckBox.IsChecked == true) ? true : false;
            richEdit.Refresh();
        }

        private void TextBoxCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            customDrawTextBox = (textBoxCheckBox.IsChecked == true) ? true : false;
            richEdit.Refresh();
        }

        private void InlineCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            customDrawImage = (inlineCheckBox.IsChecked == true) ? true : false;
            richEdit.Refresh();
        }

        private void PageCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            customDrawPage = (pageCheckBox.IsChecked == true) ? true : false;
            richEdit.Refresh();
        }

        private void ListCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            customDrawSeparator = (listCheckBox.IsChecked == true) ? true : false;
            richEdit.Refresh();
        }

        private void CheckbtnCustomDraw_Checked(object sender, RoutedEventArgs e)
        {
            if (checkbtnCustomDraw.IsChecked == true)
            {
                richEdit.BeforePagePaint += RichEdit_BeforePagePaint;
            }
            else
            {
                richEdit.BeforePagePaint -= RichEdit_BeforePagePaint;
            }
            richEdit.Refresh();
        }

    }
}
