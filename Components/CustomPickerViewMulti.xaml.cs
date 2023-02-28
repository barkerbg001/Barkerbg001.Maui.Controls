using Microsoft.Maui.Layouts;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Barkerbg001.Maui.Controls.Components;

public partial class CustomPickerViewMulti : ContentPage
{
    private readonly string ID;
    private readonly EventHandler eventHandler;
    private readonly dynamic Picker;
    private ObservableCollection<CustomPickerDto> customItemsource;
    public CustomPickerViewMulti(dynamic Picker, string ID, string title, IEnumerable<Classes.CustomPickerDto> itemsource, DataTemplate dataTemplate, EventHandler eventHandler, EventHandler eventHandlerAddNew, IEnumerable<Classes.CustomPickerDto> selectedItems, bool IsAddNewVisible = false)
    {
        InitializeComponent();

        this.ID = ID;
        this.eventHandler = eventHandler;
        btnAddNew.Clicked += eventHandlerAddNew;
        btnAddNew.IsVisible = IsAddNewVisible;
        this.Picker = Picker;
        lblSelectedField.Text = title;

        var data = itemsource.Select(x => new CustomPickerDto
        {
            ID = x.ID,
            Name = x.Name,
            IsSelected = false
        }).OrderBy(x => x.Name).ToList();

        if (selectedItems != null)
        {
            foreach (var item in selectedItems)
            {
                data.FirstOrDefault(x => x.ID == item.ID).IsSelected = true;
            }
        }
        btnSelectAll.Source = ImageSource.FromFile(data.Any(x => x.IsSelected == false) ? "checkno.png" : "checkyes.png");
        lvContent.ItemsSource = customItemsource = new ObservableCollection<CustomPickerDto>(data);
        lvContent.ItemTemplate = dataTemplate ?? MainListViewTemplate;
        //scrSearch.Text = string.Empty;
        this.LayoutChanged += CustomPickerView_LayoutChanged;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
    private void CustomPickerView_LayoutChanged(object sender, EventArgs e)
    {
        if (Device.Idiom == TargetIdiom.Tablet)
        {
            if (DeviceDisplay.Current.MainDisplayInfo.Orientation == DisplayOrientation.Portrait)
            {
                AbsoluteLayout.SetLayoutBounds(Main, new Rect(0.5, 0.5, 0.8, 0.8));
            }
            else
            {
                AbsoluteLayout.SetLayoutBounds(Main, new Rect(0.5, 0.5, 0.8, 0.8));
            }
        }
        else if (Device.RuntimePlatform == Device.WinUI || Device.Idiom == TargetIdiom.Tablet)
        {
            AbsoluteLayout.SetLayoutBounds(Main, new Rect(0.5, 0.5, 0.5, 0.5));

        }
        else
        {
            AbsoluteLayout.SetLayoutBounds(Main, new Rect(0.5, 0.5, 0.8, 0.8));
        }

        AbsoluteLayout.SetLayoutFlags(Main, AbsoluteLayoutFlags.All);
    }

    private void BtnCancelList_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void lvContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (lvContent.SelectedItem != null)
        {
            var item = (CustomPickerDto)((CollectionView)sender)?.SelectedItem;
            item.IsSelected = !item.IsSelected;
        }
        lvContent.SelectedItem = null;
    }

    public Task FireEvent()
    {
        if (eventHandler != null)
        {
            eventHandler(Picker, null);
        }
        return Task.CompletedTask;
    }

    private async void scrSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        var result = customItemsource.Where(a => a.Name.Contains(e.NewTextValue, StringComparison.InvariantCultureIgnoreCase)).ToList();
        lvContent.ItemsSource = result;
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var data = (CustomPickerDto)button.BindingContext;
        data.IsSelected = !data.IsSelected;
    }

    private class CustomPickerDto : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private bool _isSelected;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
            }
        }


        public void RaisePropertyChanged(string name)
        { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    private async void BtnSaveList_Clicked(object sender, EventArgs e)
    {
        var result = customItemsource.Where(x => x.IsSelected).Select(x => new Classes.CustomPickerDto
        {
            ID = x.ID,
            Name = x.Name,
        }).ToList();

        MessagingCenter.Send<Page, List<Classes.CustomPickerDto>>(this, ID, result);
        await Task.Delay(50);
        await FireEvent();
        Navigation.PopModalAsync();
    }

    private void btnSelectAll_Clicked(object sender, EventArgs e)
    {
        var butt = (ImageButton)sender;
        var file = (butt.Source as FileImageSource).File;
        var image = (file == "checkno.png") ? "checkyes.png" : "checkno.png";
        butt.Source = ImageSource.FromFile(image);
        foreach (var item in customItemsource)
        {
            item.IsSelected = !(image == "checkno.png");
        }
    }
}