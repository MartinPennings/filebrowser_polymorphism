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
using System.IO;

namespace FileBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<FSBaseObject> lst;

        public MainWindow()
        {
            InitializeComponent();

            lst = new List<FSBaseObject>();

            fillBox("c:\\");

        }

        private void fillBox(string mainPath)
        {
            lst.Clear();
            fileListBox.ItemsSource = null;
            lblCurrentDir.Content = mainPath;

            DirectoryInfo parentInfo = Directory.GetParent(mainPath);
            if (parentInfo != null)
            {
                FSDirectoryObject dirParent = new FSDirectoryObject(parentInfo.FullName);
                dirParent.Name = "..";

                lst.Add(dirParent);
            }

            string[] dirs = Directory.GetDirectories(mainPath);
            string[] files = Directory.GetFiles(mainPath);

            foreach (string s in dirs)
            {
                FSDirectoryObject dir = new FSDirectoryObject(s);
                lst.Add(dir);
            }

            foreach (string s in files)
            {
                FSFileObject file = new FSFileObject(s);
                lst.Add(file);
            }


            fileListBox.ItemsSource = lst;
            fileListBox.SelectedIndex = 0;

        }

        private void fileListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fileListBox.SelectedItem != null)
            {
                txtDetails.Text = ((FSBaseObject)fileListBox.SelectedItem).Details();
            }
        }

        private void fileListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (fileListBox.SelectedItem != null)
            {
                var d = fileListBox.SelectedItem as FSDirectoryObject;
                if (d != null)
                {
                    fillBox(d.Path);
                }
            }
        }
    }
}