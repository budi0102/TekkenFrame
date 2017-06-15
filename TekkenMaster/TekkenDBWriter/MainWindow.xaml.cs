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
using TekkenDB;
using TekkenDB.Helpers;
using TekkenDB.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace TekkenDBWriter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window//, INotifyPropertyChanged
    {
        public MainWindow()
        {
          
            InitializeComponent();
            TekkenTagTournament2 = new Tekken();
            this.DataContext = TekkenTagTournament2;
        }

        Tekken TekkenTagTournament2;

        private async void fileOpenButton_Click(object sender, RoutedEventArgs e)
        {
            await TekkenTagTournament2.ReadCharactersAsync(TekkenTagTournament2.FilePath);
        }

        private void fileBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                TekkenTagTournament2.FilePath = dialog.SelectedPath;
            }
        }
    }

    
}
