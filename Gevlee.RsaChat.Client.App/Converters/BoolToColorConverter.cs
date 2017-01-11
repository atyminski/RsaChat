using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Gevlee.RsaChat.Client.App.Converters
{
	public class BoolToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter,
			CultureInfo culture)
		{
			bool b = (bool)value;
			return b ? Brushes.Green : Brushes.Red;
		}

		public object ConvertBack(object value, Type targetType, object parameter,
			CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}