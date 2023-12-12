using GreenThumb.Data;
using GreenThumb.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
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
    public partial class AddPlantWindow : Window
    {

        public AddPlantWindow()
        {
            InitializeComponent();
        }


        private void searchbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void SaveBtn_Click_1(object sender, RoutedEventArgs e)
        {

            // om textrutan är null eller white space ´, visa varningsmeddelande
            // visa varningsmeddelande om namn på planta redan finns
            
            using (GreenThumbDbContext context = new())
            {
                // Check for duplicates
                var isDuplicate = context.Plants.Any(p => p.Name == txtAddPlant.Text);

                if (isDuplicate)
                {
                    // Meddelande till användare
                    MessageBox.Show("Plant is already taken");

                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtAddPlant.Text) && string.IsNullOrWhiteSpace(CareSearchbox.Text))
                {

                    // Meddelande till användare
                    MessageBox.Show("Warning, try again!");
                }
                else
                {

                
                RepositoryPlant<Plantmodel> plantRepository = new(context);
                RepositoryPlant<InstructionModel> instructionRepository = new(context);
                Plantmodel plantmodel = new Plantmodel()
                {
                    Name = txtAddPlant.Text,
                };

                plantRepository.Add(plantmodel);
                plantRepository.SaveChanges();

                var plantId = context.Plants.Where(p => p.Name == txtAddPlant.Text).Select(p => p.Id).FirstOrDefault();

                    if (plantId != 0)
                    {
                        foreach (ListViewItem instruction in lstView1.Items)
                        {   
                            InstructionModel selecetedinstruction = (InstructionModel)instruction.Tag; 

                            InstructionModel newInstruction = new InstructionModel()
                            {
                                PlantId = plantId,
                                Name = selecetedinstruction.Name
                            };
                            instructionRepository.Add(newInstruction);

                            instructionRepository.SaveChanges();
                        }

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Close();
                    }
                }
            }
        }

        private void AddInstructions_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddPlant.Text) && string.IsNullOrWhiteSpace(CareSearchbox.Text))
            {
            
                // Meddelande till användare
                MessageBox.Show("Warning, try again!");
            }
            else
            {
            
                InstructionModel model = new InstructionModel()
                {
                    Name = CareSearchbox.Text,
                };
                ListViewItem item = new();
                item.Tag = model;
                item.Content = model.Name;
                lstView1.Items.Add(item);
            }
        
        }
        private void lstView_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}


