using GreenThumb.Data;
using GreenThumb.models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (GreenThumbDbContext context = new())
            {
                var repository = new RepositoryPlant<Plantmodel>(context);

                var allPlants = repository.GetAll();
                var filteredPlants = allPlants;

                foreach (var plant in filteredPlants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;
                    Plantlist.Items.Add(item);
                }
            }
        }


        private void btnAddPlantWindow_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow addPlantWindow = new AddPlantWindow();
            addPlantWindow.Show();
            Close();
            
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem? item = (ListViewItem)Plantlist.SelectedItem;


            if (item != null)
            {
                Plantmodel plantmodel = (Plantmodel)item.Tag;
            

                PlantDetails plantDetails = new PlantDetails(plantmodel);
                plantDetails.Show();
                Close();
            }
            else
            // Öppna pop-up ruta om planta inte är vald. Lås tillgång till detailswindow
            {
                MessageBox.Show("Select plant");
            }
            
        }
    

        private void searchbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (GreenThumbDbContext context = new())
            {
                var repository = new RepositoryPlant<Plantmodel>(context);

                var allPlants = repository.GetAll();
                string searchPlant = searchbox.Text.ToLower();

                
                var filteredPlants = allPlants.Where(p => p.Name.ToLower().Contains(searchPlant));
                Plantlist.Items.Clear();

                foreach (var plant in filteredPlants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;
                    Plantlist.Items.Add(item);
                }
            }
        }

        private void Plantlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)Plantlist.SelectedItem;
            if (selectedItem != null)


            {
                Plantmodel removePlant = selectedItem.Tag as Plantmodel;
                Plantlist.Items.Remove(selectedItem);

                using (GreenThumbDbContext context = new())
                {
                    var repository = new RepositoryPlant<Plantmodel>(context);
                    repository.RemoveAsync(removePlant);
                }
            }
            else
            {
                // textruta för delete knapp om planta ej valts
                MessageBox.Show("Choose item");
            }
        }
    }
}