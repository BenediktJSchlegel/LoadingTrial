using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LoadingTrial
{
    public partial class MainPage : LoadingPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private bool _isBusy = false;
        public new bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private string _name = "Bla";
        public string Name
        {
            get => _name;
            set 
            {
                if (value.Length > 20)
                    value = value.Substring(18);

                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private async void Button_Pressed(object sender, EventArgs e)
        {
            Name = Name + Name;
            IsBusy = !IsBusy;

            await Task.Run(() => {
                Thread.Sleep(10000);
                Device.BeginInvokeOnMainThread(() => {
                    this.IsBusy = false;
                });
            });
        }



    }

    public class LoadingPage : ContentPage
    {

    }
}
