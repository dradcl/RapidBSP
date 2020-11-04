using RapidBSP.Lumps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace RapidBSP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int lumpIndex = 0, selectedIndex = 0;
        VBSPFile vBSPFile;
        string[] lumpNames = Enum.GetNames(typeof(LumpTypeIndex2004));
        public MainWindow()
        {
            InitializeComponent();
        }
        private void UpdateLumpInformation(int index1, int index2)
        {
            byteSize.Content = vBSPFile.lumps[index1].filelen;
            offsetLbl.Content = vBSPFile.lumps[index1].fileofs;
            versionLbl.Content = vBSPFile.lumps[index1].version;
            lumpType.Content = lumpNames[index2];
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
                List<string> files = Directory.GetFiles(fbd.SelectedPath).ToList();

                foreach (string file in files.ToList())
                {
                    if (!file.EndsWith(".bsp"))
                    {
                        files.Remove(file);
                    }
                }

                fileList.ItemsSource = files;
                fileCount.Content = files.Count + " files: ";
            }
        }
        private void lumpsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lumpIndex = lumpsList.Items.IndexOf(lumpsList.SelectedItem);
            
            if (lumpIndex > -1 && lumpIndex < 64)
            {
                selectedIndex = lumpsList.SelectedIndex;
                UpdateLumpInformation(selectedIndex, lumpIndex);
            }
            else
            {
                lumpIndex = 0;
            }
        }
        private void fileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vBSPFile = new VBSPFile(fileList.SelectedItem.ToString());
            lumpsList.ItemsSource = vBSPFile.lumps;
            lumpsList.SelectedIndex = selectedIndex;

            validBSP.Content = vBSPFile.IsValidBSPFile();
            UpdateLumpInformation(selectedIndex, selectedIndex);
        }
    }
}