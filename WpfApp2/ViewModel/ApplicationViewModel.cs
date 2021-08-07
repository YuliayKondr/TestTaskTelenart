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
        private int selectedPhoneIndex;
        ServiceOrders _serviceOrders;
        public ObservableCollection<ModelOrder> Orders { get; set; }

        public ObservableCollection<ModelProduct> SelectedProducts { get; set; }

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
                }
                OnPropertyChanged("SelectedOrder");
                OnPropertyChanged("SelectedProducts");
            }
        }

        public int SelectedOrderIndex
        {
            get { return selectedPhoneIndex; }
            set
            {
                selectedPhoneIndex = value;
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
