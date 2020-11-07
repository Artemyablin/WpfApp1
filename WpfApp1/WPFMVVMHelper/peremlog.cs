using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFMVVMHelper
{
    public class peremlog : INotifyPropertyChanged
    {
        /// <summary>
        /// событие кторое что то делает
        /// я скачал это с интернета
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        /// <summary>
        /// передача данных в переменную
        /// </summary>
        /// <typeparam name="T">тип наверно</typeparam>
        /// <param name="field">переменная в которую передаём</param>
        /// <param name="value">значение которе передаём</param>
        /// <param name="Property">вообще без понятия зочем нужно</param>
        /// <returns>проверяет, была ли озменена переменная</returns>
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string Property = null)
        {
            if (Equals(field, value) || value == null) return false;
            field = value;
            OnPropertyChanged(Property);
            return true;
        }
    }
}