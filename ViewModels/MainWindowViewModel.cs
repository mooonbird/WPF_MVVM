using CrazyElephant.Client.Models;
using CrazyElephant.Client.Services;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrazyElephant.Client.ViewModels
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public DelegateCommand? SelectMenuItemCommand { get; set; }
        public DelegateCommand? PlaceOrderCommand { get; set; }

        private int _Count;
        public int Count
        {
            get { return _Count; }
            set 
            {
                _Count = value;
                this.PropertyChanged!.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        }
        private List<DishMenuItemViewModel>? _DishMenu;

        public List<DishMenuItemViewModel>? DishMenu
        {
            get { return _DishMenu; }
            set 
            {
                _DishMenu = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DishMenu)));
            }
        }
        private Restaurant? _Restaurant;

        public Restaurant? Restaurant
        {
            get { return _Restaurant; }
            set 
            {
                _Restaurant = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Restaurant)));
            }
        }


        public MainWindowViewModel()
        {
            LoadRestaurant();
            LoadDishMenu();
            this.PlaceOrderCommand = new DelegateCommand(PlaceOrder);
            this.SelectMenuItemCommand = new DelegateCommand(SelectMenuItem);
        }

        private void SelectMenuItem()
        {
            if (this.DishMenu != null)
            {
                this.Count = this.DishMenu.Count(e => e.IsSelected == true);
            }
        }

        private void PlaceOrder()
        {
            List<string?> selectedDishes = this._DishMenu.Where(e => e.IsSelected == true).Select(e => e.Dish.Name).ToList();
            var orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功！");

        }

        private void LoadDishMenu()
        {
            XmlDataService xmlDataService = new XmlDataService();
            var dishes = xmlDataService.GetAllDishes();
            this.DishMenu = new List<DishMenuItemViewModel>();
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel dishMenuItemViewModel = new DishMenuItemViewModel();
                dishMenuItemViewModel.Dish = dish;
                this.DishMenu.Add(dishMenuItemViewModel);
            }
        }

        private void LoadRestaurant()
        {
            this.Restaurant = new Restaurant()
            {
                Name = "Crazy大象",
                Address = "北京市海淀区万泉河路紫金庄园",
                PhoneNumber = "15210365423"
            };
        }
    }
}
