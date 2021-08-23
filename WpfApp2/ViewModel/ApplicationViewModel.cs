using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfApp2.Model;
using DataBaseModel;
using WpfApp2.Services;

namespace WpfApp2.ViewModel
{
    internal class ApplicationViewModel : INotifyPropertyChanged
    {
        private ModelOrder selectedOrder;
        private string _nameOrder;
        private int selectedIndex;
        ServiceOrders _serviceOrders;
        public ObservableCollection<ModelOrder> Orders { get; set; }

        public ObservableCollection<ModelProduct> SelectedProducts { get; set; }

        public string NameOrder
        {
            get { return _nameOrder; }
            set { _nameOrder = value; }
        }

        public ModelOrder SelectedOrder
        {
            get { return selectedOrder; }
            set
            {                
                selectedOrder = value;
                if(SelectedProducts != null)
                    SelectedProducts.Clear();
                if (selectedOrder != null)
                {
                    ModelProduct[] orderLines = _serviceOrders.GetProduct(selectedOrder.IdOrder);
                    for (var i = 0; i < orderLines.Length; i++)
                    {
                        SelectedProducts.Add(orderLines[i]);
                    }
                    NameOrder = selectedOrder.IdOrder.ToString();
                }
                OnPropertyChanged("SelectedOrder");
                OnPropertyChanged("SelectedProducts");
                OnPropertyChanged("NameOrder");
            }
        }

        public int SelectedOrderIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
            }
        }       
       

        public event PropertyChangedEventHandler PropertyChanged;

        public ApplicationViewModel()
        {
            _serviceOrders = new ServiceOrders();
            ModelOrder[] models = _serviceOrders.GetAllOrders();
            if(models.Length > 0)
            {
                selectedOrder = models[0];
                ModelProduct[] orderLines = _serviceOrders.GetProduct(selectedOrder.IdOrder);
                SelectedProducts = new ObservableCollection<ModelProduct>(orderLines);
                NameOrder = models[0].IdOrder.ToString();
            }

            Orders = new ObservableCollection<ModelOrder>(models);              
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
