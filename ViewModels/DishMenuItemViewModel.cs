using CrazyElephant.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Client.ViewModels
{
    public class DishMenuItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public Dish? Dish { get; set; }

        private bool _IsSelected;

        public bool IsSelected
        {
            get { return _IsSelected; }
            set 
            {
                _IsSelected = value;
                this.PropertyChanged!.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
            }
        }

    }
}
