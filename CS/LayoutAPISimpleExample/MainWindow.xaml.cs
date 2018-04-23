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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            richEdit.LoadDocument("Grimm.docx");
            richEdit.DocumentLayout.DocumentFormatted += DocumentLayout_DocumentFormatted;
        }

        #region #DocumentFormatted
        private void DocumentLayout_DocumentFormatted(object sender, EventArgs e)
        {

            richEdit.BeginInvoke(new Action(() =>
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
    }
}
