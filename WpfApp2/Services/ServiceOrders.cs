using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseModel;
using WpfApp2.Model;

namespace WpfApp2.Services
{
    internal class ServiceOrders
    {
        private TestworkContext _database;

        public ModelOrder[] GetAllOrders()
        {
            ModelOrder[] result = new ModelOrder[0];
            try
            {
                using (_database = new TestworkContext())
                {
                    var a = from ord in _database.orders
                            join st in _database.user on ord.user_id equals st.id
                            select new ModelOrder
                            {
                                IdOrder = ord.id,
                                NameClient = st.name,
                                DateOrder = ord.created_on.Value,
                                DateChange = ord.modified_on.Value,
                                CountPosition = ord.order_line.Count,
                                SummOrder = ord.order_line.Sum(x => x.price.Value)
                            };
                    result = a.ToArray();
                }
            }
            catch (Exception e) {}
            return result;
        }   
        
        public ModelProduct[] GetProduct(int idOrders)
        {
            ModelProduct[] result = new ModelProduct[0];
            try
            {
                using (_database = new TestworkContext())
                {
                    var a = from ord in _database.order_line                           
                            where ord.order_id == idOrders
                            join pr in _database.product on ord.product_id equals pr.id                            
                            select new ModelProduct
                            {
                               Count = ord.quantity.Value,
                               Price = ord.price.Value,
                               NameProduct = pr.name
                            };
                    result = a.ToArray();
                }
            }
            catch (Exception e) { }
            return result;
        }
    }
}
