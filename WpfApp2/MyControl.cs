using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace WpfApp2
{
    class MyControl: FrameworkElement
    {
        // 1. Создание свойства зависимостей.
        // Идентификатор свойства зависимости - поле представляющее свойство зависимости.
        public static DependencyProperty DataProperty;

        // 2. регистрация свойства зависимостей
        static MyControl()
        {
            // параметр 1: Имя свойства.
            // параметр 2: Тип данных свойства.
            // параметр 3: Тип, которому принадлежит это свойство.
            DataProperty = DependencyProperty.Register("Data", typeof(DateTime?), typeof(MyControl));
        }

        // 3. Упаковка свойства зависимостей в традиционное свойство.
        // Методы SetValue и GetValue унаследованы от класса DependencyObject

        public DateTime? Data
        {
            get
            {
                return (DateTime?)GetValue(DataProperty);
            }
            set
            {
                SetValue(DataProperty, value);
            }
        }
    }
}
