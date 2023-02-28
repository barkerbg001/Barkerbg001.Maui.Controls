using Microsoft.Maui.Layouts;

namespace Barkerbg001.Maui.Controls.Components;

public partial class CustomPickerView : ContentPage
{
    private readonly string ID;
    private readonly EventHandler eventHandler;
    private readonly dynamic Picker;
    private IEnumerable<Class.CustomPickerDto> customItemsource;
    public CustomPickerView(dynamic Picker, string ID, string title, IEnumerable<Class.CustomPickerDto> itemsource, DataTemplate dataTemplate, EventHandler eventHandler, EventHandler eventHandlerAddNew, bool IsAddNewVisible = false)
    {
        InitializeComponent();

        this.ID = ID;
        this.eventHandler = eventHandler;
        btnAddNew.Clicked += eventHandlerAddNew;
        btnAddNew.IsVisible = IsAddNewVisible;
        this.Picker = Picker;
        lblSelectedField.Text = title;

        lvContent.ItemsSource = customItemsource = itemsource.ToList();
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
        else if (Device.RuntimePlatform == Device.UWP || Device.Idiom == TargetIdiom.Tablet)
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

    private async void lvContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = (Class.CustomPickerDto)((CollectionView)sender)?.SelectedItem;
        MessagingCenter.Send<Page, Class.CustomPickerDto>(this, ID, item);
        await Task.Delay(50);
        await FireEvent();
        Navigation.PopModalAsync();
    }

    public Task FireEvent()
    {
        if (eventHandler != null)
        {
            eventHandler(Picker, null);
        }
        return Task.CompletedTask;
    }

    private void scrSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        var result = customItemsource.Where(a => a.Name.Contains(e.NewTextValue, StringComparison.InvariantCultureIgnoreCase)).ToList();
        lvContent.ItemsSource = result;
    }
}