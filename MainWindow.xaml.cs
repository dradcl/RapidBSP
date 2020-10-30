using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace RapidBSP
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

        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                VBSPFile file = new VBSPFile(ofd.FileName);
            }
        }

        private void menuDirOpen_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);

                fileList.ItemsSource = files;
                fileCount.Content = files.Length + " files: ";
            }
        }

        //  https://stackoverflow.com/questions/6938752/wpf-how-do-i-handle-a-click-on-a-listbox-item
        private void fileList_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(fileList, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                VBSPFile vBSPFile = new VBSPFile((string) item.Content);

                validBSP.Content = vBSPFile.IsValidBSPFile();
                byteSize.Content = vBSPFile.lumps[2].filelen;
                offsetLbl.Content = vBSPFile.lumps[2].fileofs;
                versionLbl.Content = vBSPFile.lumps[2].version;
                lumpsList.ItemsSource = vBSPFile.lumps;
            }
        }
    }
}