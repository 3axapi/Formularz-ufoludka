using Microsoft.Win32;
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

namespace Formularz_ufoludka
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

        private void save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Dane z Formułarza do zapisu";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "pliki tekstów (*.txt) | *txt";


            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                string filePath = saveFileDialog.FileName;
                string dane = zapiszDane();
                System.IO.File.WriteAllText(filePath, dane);
            }
        }

        private string zapiszDane()
        {
            DateTime? wybranaData = calen.SelectedDate;
            string wybranaDataString = wybranaData.HasValue ? wybranaData.Value.ToString() : "brak daty";
            string? wybranaPlec = ((ComboBoxItem)plec.SelectedItem).Content.ToString();
            string wybranyWzrost = wzrost.Value.ToString();
            var wybraneWyposazenie = new List<string>();
            string editowaneWybraneWyposazenie = "";
            string? wybranaRola;
            int ogolnaMoc;

            if (szer.IsChecked == true) wybraneWyposazenie.Add(szer.Content.ToString());
            if (piki.IsChecked == true) wybraneWyposazenie.Add(piki.Content.ToString());
            if (rang.IsChecked == true) wybraneWyposazenie.Add(rang.Content.ToString());
            if (strz.IsChecked == true) wybraneWyposazenie.Add(strz.Content.ToString());
            if (golm.IsChecked == true) wybraneWyposazenie.Add(golm.Content.ToString());
            if (uzdr.IsChecked == true) wybraneWyposazenie.Add(uzdr.Content.ToString());
            if (wybraneWyposazenie.Count == 0) wybraneWyposazenie.Add("brak wyposażenia");

            foreach (string wypsz in wybraneWyposazenie)
            {
                editowaneWybraneWyposazenie = $"{editowaneWybraneWyposazenie} {wypsz} ";
            }

            ogolnaMoc = 1000 / wybraneWyposazenie.Count();

            if (czlk.IsChecked == true) wybranaRola = czlk.Content.ToString();
            else if (elf.IsChecked == true) wybranaRola = elf.Content.ToString();
            else if (kras.IsChecked == true) wybranaRola = kras.Content.ToString();
            else if (ork.IsChecked == true) wybranaRola = ork.Content.ToString();
            else if (choh.IsChecked == true) wybranaRola = choh.Content.ToString();
            else if (trol.IsChecked == true) wybranaRola = trol.Content.ToString();
            else wybranaRola = "spectator";

            return $"— twój nickname: {nick.Text}\n" +
                $"— data narodzenia: {wybranaDataString.ToString()}\n" +
                $"— wybrana płeć: {wybranaPlec}\n" +
                $"— wybrany wzróst: {wybranyWzrost}\n" +
                $"— wybrane wyposazenie: {editowaneWybraneWyposazenie}\n" +
                $"— wybrana rola: {wybranaRola}\n\n" +
                $"— ogólna moc: {ogolnaMoc}";
        }

        private void next(object sender, RoutedEventArgs e)
        {
            if (hasl1.Password == hasl2.Password)
            {
                haslalert.Text = "";
                reg.Visibility = Visibility.Hidden;
                character.Visibility = Visibility.Visible;
            } else
            {
                haslalert.Text = "Nie poprawnie napisano hasło\nSprawdz czy hasła są idedntyczne";
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            nick.Text = "";
            hasl1.Password = "";
            hasl2.Password = "";
            plec.Text = "";
            wzrost.Value = 50;
            szer.IsChecked = false;
            piki.IsChecked = false;
            strz.IsChecked = false;
            rang.IsChecked = false;
            golm.IsChecked = false;
            uzdr.IsChecked = false;
            czlk.IsChecked = false;
            elf.IsChecked = false;
            kras.IsChecked = false;
            ork.IsChecked = false;
            choh.IsChecked = false;
            trol.IsChecked = false;
            character.Visibility = Visibility.Hidden;
            reg.Visibility = Visibility.Visible;
        }
    }
}
