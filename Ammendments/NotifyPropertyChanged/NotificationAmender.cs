using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Reflection;

using Afterthought;

namespace Ammendments
{
	/// <summary>
	/// Static class containing a method that will be called after each property set.
	/// This method in outside of the Amendment<,> subclass to ensure that the amended type
	/// will not have a runtime dependency on Afterthought.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public static class NotificationAmender<T>
	{

        public static void BeforeConstructor(INotifyPropertyChangedAmendment instance, string constructor, object[] parameters) {
            instance.INotifyPropertyChangedAmendmentPropertyDependencies = new PropertyDependencyMap();
            foreach(PropertyInfo prop in instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)) {
                if(prop.Name == "INotifyPropertyChangedAmendmentPropertyDependencies") {
                    continue;
                }
                List<string> targetList = new List<string>();
                foreach(PropertyDependsAttribute attrib in prop.GetCustomAttributes(typeof(PropertyDependsAttribute), true).Cast<PropertyDependsAttribute>()) {
                    targetList.AddRange(attrib.Targets);
                }
                instance.INotifyPropertyChangedAmendmentPropertyDependencies.Add(prop.Name, targetList);
            }
        }

		public static void OnPropertyChanged<P>(INotifyPropertyChangedAmendment instance, string property, P oldValue, P value, P newValue) {

			// Only raise property changed if the value of the property actually changed
            if((oldValue == null ^ newValue == null) || (oldValue != null && !oldValue.Equals(newValue))) {
                foreach(string target in instance.INotifyPropertyChangedAmendmentPropertyDependencies[property]) {
                    string[] targetPartList = target.Split('.');
                    if(targetPartList.Length == 1) {

                    }
                }
                instance.OnPropertyChanged(new PropertyChangedEventArgs(property));
            }
		}

	}

	/// <summary>
	/// Amendment class that instructs Afterthought to implement INotifyPropertyChanged for the target types.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class NotificationAmendment<T> : Amendment<T, INotifyPropertyChangedAmendment>
	{
		public NotificationAmendment()
		{
			var propertyChanged = Events.Add<PropertyChangedEventHandler>("PropertyChanged");

			// Implement INotifyPropertyChanged, specifying the PropertyChanged event
			Implement<INotifyPropertyChanged>(
				propertyChanged
			);

			// Implement INotifyPropertyChangedAmendment, specifying a method that raises the PropertyChanged event
			Implement<INotifyPropertyChangedAmendment>(
				Methods.Raise(propertyChanged, "OnPropertyChanged")
			);

			// Raise Property Changed
			Properties
				.Where(p => p.PropertyInfo.CanRead && p.PropertyInfo.CanWrite && p.PropertyInfo.GetSetMethod().IsPublic)
				.AfterSet(NotificationAmender<T>.OnPropertyChanged);

            Properties.Add<PropertyDependencyMap>("INotifyPropertyChangedAmendmentPropertyDependencies");

            Constructors.Before(NotificationAmender<T>.BeforeConstructor);
		}

        private static Amendment<T, INotifyPropertyChangedAmendment>.PropertyEnumeration.AfterPropertySet GetPropertChangedDelegate<P>(string propertyName) {
            return ((INotifyPropertyChangedAmendment instance, string property, object _oldValue, object _value, object _newValue) => {
                P oldValue = (P)_oldValue;
                P value = (P)_value;
                P newValue = (P)_newValue;
                if((oldValue == null ^ newValue == null) || (oldValue != null && !oldValue.Equals(newValue)))
                    instance.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            });
        }
	}
}
