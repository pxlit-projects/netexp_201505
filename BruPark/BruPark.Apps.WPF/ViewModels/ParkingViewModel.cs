using BruPark.WebApi.Models;

namespace BruPark.Apps.WPF.ViewModels
{
    public class ParkingViewModel : AbstractViewModel
    {
        private ParkingRO model;



        public string AddressFR
        {
            get
            {
                return model.AddressFR;
            }
        }

        public string AddressNL
        {
            get
            {
                return model.AddressNL;
            }
        }

        public bool Disabled
        {
            get
            {
                return model.Disabled;
            }
        }

        public long Distance
        {
            get
            {
                return model.Distance;
            }
        }

        public long Duration
        {
            get
            {
                return model.Duration;
            }
        }

        public int Id
        {
            get
            {
                return model.Id;
            }
        }

        public int Spaces
        {
            get
            {
                return model.Spaces;
            }
        }

        public int SuccessRate
        {
            get
            {
                return model.SuccessRate;
            }

            set
            {
                model.SuccessRate = value;

                FirePropertyChanged(nameof(SuccessRate));
            }
        }

        

        public ParkingViewModel(ParkingRO model)
        {
            this.model = model;
        }
    }
}
