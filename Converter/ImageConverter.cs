using System.Globalization;

namespace Barkerbg001.Maui.Controls.Converter;

public class ImageConverter : IValueConverter
{
    public string ImageChosen { get; set; }
    public string ImageUnchosen { get; set; }
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value == true ? ImageChosen : ImageUnchosen;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
