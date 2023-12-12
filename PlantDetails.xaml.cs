using GreenThumb.Data;
using GreenThumb.models;
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
using System.Windows.Shapes;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for PlantDetails.xaml
    /// </summary>
    public partial class PlantDetails : Window
    {
        public PlantDetails(Plantmodel plant)
        {
            InitializeComponent();
            Plantname.Content = plant.Name;
            using (GreenThumbDbContext context = new GreenThumbDbContext())
            {

                var instructionsOfPlant = context.Instructions.Where(i => i.PlantId == plant.Id).ToList();

                foreach (var instruction in instructionsOfPlant)
                {
                    ListViewItem item = new ListViewItem();
                    item.Content = instruction.Name.ToString();  
                    
                    item.Tag = instruction;

                    lstInstruction.Items.Add(item);
                }
            }

        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }

        private void lstPlantDescription_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }
        private void lstInstruction_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        private void lstInstruction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
