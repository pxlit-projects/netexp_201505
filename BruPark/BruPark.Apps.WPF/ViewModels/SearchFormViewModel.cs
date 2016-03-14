using BruPark.OpenData.Client;
using BruPark.OpenData.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace BruPark.Apps.WPF.ViewModels
{
    public class SearchFormViewModel : AbstractViewModel
    {

        private string label = "Randomize";



        public ObservableCollection<Municipality> Municipalities { get; set; }

        public ICommand Randomize { get; set; }

        public string RandomizeLabel
        {
            get
            {
                return label;
            }

            set
            {
                label = value;

                FirePropertyChanged(nameof(RandomizeLabel));
            }
        }



        public SearchFormViewModel()
        {
            this.Municipalities = new ObservableCollection<Municipality>(new MunicipalityManager().GetMunicipalitiesByPostalCode());

            this.Randomize = new RandomizeCommand(this);
        }










        private class RandomizeCommand : ICommand
        {

            public event EventHandler CanExecuteChanged;

            private SearchFormViewModel model;

            private Random rng = new Random();



            public RandomizeCommand(SearchFormViewModel model)
            {
                this.model = model;
            }



            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                int number = rng.Next(1000);

                model.RandomizeLabel = string.Format("Randomize ({0})", number);
            }

        }

    }
}
