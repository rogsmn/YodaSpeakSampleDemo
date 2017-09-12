using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace YodaSpeakSampleDemo.ViewModels
{
    /// <summary>
    /// ViewModelBase class implements INotifyPropertyChanged interface.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Type of member variable</typeparam>
        /// <param name="storage">Member variable which needs to be changed</param>
        /// <param name="value">New value of the member variable</param>
        /// <param name="propertyName">Name of the property on which SetProperty was called</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            //Return if old value equals new value
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Method called when property of a ViewModel Changes
        /// </summary>
        /// <param name="propertyName">Name of property whose value changed</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
