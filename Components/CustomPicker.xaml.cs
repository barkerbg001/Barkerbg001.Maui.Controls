using CommunityToolkit.Maui.Views;
namespace Barkerbg001.Maui.Controls.Components;

public partial class CustomPicker : ContentView
{
    public CustomPicker()
    {
        InitializeComponent();
        MessagingCenter.Subscribe<Page, List<Classes.CustomPickerDto>>(this, this.Id.ToString(), (p, value) =>
        {
            Text = value.Count + " Selected";
            SelectedItems = value;
        });

        MessagingCenter.Subscribe<Page, Classes.CustomPickerDto>(this, this.Id.ToString(), (p, value) =>
        {
            Text = value.Name;
            SelectedItem = value;
        });
        edtInput.GestureRecognizers.Add(TapGestureRecognizer = new TapGestureRecognizer());
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(String), typeof(CustomPicker), default(String), BindingMode.TwoWay, propertyChanged: OnTextPropertyChanged);
    private static void OnTextPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is CustomPicker current)
        {
            current.edtInput.Text = (string)newvalue;
        }
    }
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(Classes.CustomPickerDto), typeof(CustomPicker), null, BindingMode.TwoWay, propertyChanged: SelectedItemPropertyChanged);
    public Classes.CustomPickerDto SelectedItem
    {
        get => (Classes.CustomPickerDto)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    private static void SelectedItemPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is CustomPicker current)
        {
            current.Text = newvalue != null ? ((Classes.CustomPickerDto)newvalue).Name : string.Empty;
        }
    }

    public static readonly BindableProperty SelectedItemsProperty = BindableProperty.Create(nameof(SelectedItems), typeof(List<Classes.CustomPickerDto>), typeof(CustomPicker), null, BindingMode.TwoWay, propertyChanged: SelectedItemsPropertyChanged);
    public List<Classes.CustomPickerDto> SelectedItems
    {
        get => (List<Classes.CustomPickerDto>)GetValue(SelectedItemsProperty);
        set => SetValue(SelectedItemsProperty, value);
    }

    private static void SelectedItemsPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is CustomPicker current)
        {
            current.Text = newvalue != null ? ((List<Classes.CustomPickerDto>)newvalue).Count() + " Selected" : "0 Selected";
        }
    }


    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(String), typeof(CustomPicker), "Select a Value", BindingMode.TwoWay);
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// bool to determine if the picker is a multiple selection
    /// </summary>
    public static readonly BindableProperty MultipleProperty = BindableProperty.Create(nameof(Multiple), typeof(bool), typeof(CustomPicker), false, BindingMode.TwoWay);
    public bool Multiple
    {
        get => (bool)GetValue(MultipleProperty);
        set => SetValue(MultipleProperty, value);
    }

    public static readonly BindableProperty IsAddNewVisibleProperty = BindableProperty.Create(nameof(IsAddNewVisible), typeof(bool), typeof(CustomPicker), false, BindingMode.TwoWay);
    public bool IsAddNewVisible
    {
        get => (bool)GetValue(IsAddNewVisibleProperty);
        set => SetValue(IsAddNewVisibleProperty, value);
    }

    public static readonly BindableProperty IsOrderedProperty = BindableProperty.Create(nameof(IsOrdered), typeof(bool), typeof(CustomPicker), true, BindingMode.TwoWay);
    public bool IsOrdered
    {
        get => (bool)GetValue(IsOrderedProperty);
        set => SetValue(IsOrderedProperty, value);
    }

    public static readonly BindableProperty TextColourProperty = BindableProperty.Create(nameof(TextColour), typeof(Color), typeof(CustomPicker), default(Color), BindingMode.TwoWay, propertyChanged: TextColourPropertyChanged);
    private static void TextColourPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is CustomPicker current)
        {
            current.edtInput.TextColor = (Color)newvalue;
        }
    }
    public Color TextColour
    {
        get => (Color)GetValue(TextColourProperty);
        set => SetValue(TextColourProperty, value);
    }

    public static readonly BindableProperty BackgroundColourProperty = BindableProperty.Create(nameof(BackgroundColour), typeof(Color), typeof(CustomPicker), Color.FromArgb("#ffffff"), BindingMode.TwoWay, propertyChanged: BackgroundColourPropertyChanged);
    private static void BackgroundColourPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is CustomPicker current)
        {
            current.edtInput.TextColor = (Color)newvalue;
        }
    }
    public Color BackgroundColour
    {
        get => (Color)GetValue(BackgroundColourProperty);
        set => SetValue(BackgroundColourProperty, value);
    }

    public static readonly BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(CustomPicker), default(TextAlignment), BindingMode.TwoWay, propertyChanged: HorizontalTextAlignmentPropertyChanged);
    private static void HorizontalTextAlignmentPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is CustomPicker current)
        {
            current.edtInput.HorizontalTextAlignment = (TextAlignment)newvalue;
        }
    }
    public TextAlignment HorizontalTextAlignment
    {
        get => (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
        set => SetValue(HorizontalTextAlignmentProperty, value);
    }

    public static readonly BindableProperty VerticalTextAlignmentProperty = BindableProperty.Create(nameof(VerticalTextAlignment), typeof(TextAlignment), typeof(CustomPicker), default(TextAlignment), BindingMode.TwoWay, propertyChanged: VerticalTextAlignmentPropertyChanged);
    private static void VerticalTextAlignmentPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is CustomPicker current)
        {
            current.edtInput.VerticalTextAlignment = (TextAlignment)newvalue;
        }
    }
    public TextAlignment VerticalTextAlignment
    {
        get => (TextAlignment)GetValue(VerticalTextAlignmentProperty);
        set => SetValue(VerticalTextAlignmentProperty, value);
    }

    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(Double), typeof(CustomPicker), Convert.ToDouble("15"), BindingMode.TwoWay, propertyChanged: FontSizePropertyChanged);
    private static void FontSizePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        if (bindable is CustomPicker current)
        {
            current.edtInput.FontSize = (Double)newvalue;
        }
    }
    public Double FontSize
    {
        get => (Double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<Classes.CustomPickerDto>), typeof(CustomPicker), defaultValue: null, BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
    {
        if (bindable is CustomPicker current)
        {
            var value = (IEnumerable<Classes.CustomPickerDto>)newValue;
            var check = value.FirstOrDefault(x => x.IsDefault == true);
            if (check != null)
            {
                current.SelectedItem = check;
            }
        }
    });

    public IEnumerable<Classes.CustomPickerDto> ItemsSource
    {
        get => (IEnumerable<Classes.CustomPickerDto>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public static readonly BindableProperty DataTemplateProperty = BindableProperty.Create(nameof(DataTemplate), typeof(DataTemplate), typeof(CustomPicker), defaultValue: null, BindingMode.TwoWay);

    public DataTemplate DataTemplate
    {
        get => (DataTemplate)GetValue(DataTemplateProperty);
        set => SetValue(DataTemplateProperty, value);
    }

    private readonly object _tappedEventPadlock = new object();
    /// <summary>
    /// Event invoked when this button's TapGestureRecogniser is tapped
    /// </summary>string
    public event System.EventHandler<Microsoft.Maui.Controls.TappedEventArgs> Tapped
    {
        add
        {
            lock (_tappedEventPadlock)
            {
                TapGestureRecognizer.Tapped += value;
            }

        }
        remove
        {
            lock (_tappedEventPadlock)
            {
                TapGestureRecognizer.Tapped -= value;
            }
        }
    }

    /// <summary>
    /// Handles tap events on this button, by default will invoke TapGestureRecognizer_Tapped, and call the Tapped ICommand
    /// </summary>
    protected TapGestureRecognizer TapGestureRecognizer
    {
        get;
        set;
    }

    public event EventHandler EnterClicked;
    public event EventHandler AddNew_Clicked;

    private async void CustomLabel_Tapped(object sender, TappedEventArgs e)
    {
        //try
        //{
        //    if (ItemsSource != null)
        //    {
        //        var items = IsOrdered ? ItemsSource.OrderBy(x => x.Name) : ItemsSource;
        //        if (Multiple)
        //        {
        //            await Navigation.PushModalAsync(new CustomPickerViewMulti(this, this.Id.ToString(), Title, ItemsSource, DataTemplate, EnterClicked, AddNew_Clicked, SelectedItems, IsAddNewVisible));
        //        }
        //        else
        //        {
        //            await Navigation.PushModalAsync(new CustomPickerView(this, this.Id.ToString(), Title, ItemsSource, DataTemplate, EnterClicked, AddNew_Clicked, IsAddNewVisible));
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    edtInput.Text = ex.Message;
        //}

        // Create a new PopupPage

        var datatem = new DataTemplate(() =>
        {
            var lbl = new Label
            {
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Colors.Black,
                Margin = new Thickness(10, 0, 0, 0)
            };
            lbl.SetBinding(Label.TextProperty, "Name");
            return lbl;
        });
        
        var popup = new Popup { Color = Colors.Transparent };

        var lblTitle = new Label
        {
            WidthRequest = 200,
            FontSize = 15,
            HeightRequest = 25,
            HorizontalTextAlignment = TextAlignment.Center,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start,
            Text = Title
        };

        var btnCancel = new Button { Text = "Cancel", HorizontalOptions = LayoutOptions.Start };
        btnCancel.Clicked += delegate (object senders, EventArgs ed)
        {
            popup.Close();
        };
        var btnAdd = new Button { Text = "Add", IsVisible = IsAddNewVisible, HorizontalOptions = LayoutOptions.End };
        btnAdd.Clicked += AddNew_Clicked;

        //Create grid for the popup that will hold the content
        var grdMiddle = new Grid { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.FillAndExpand };
        grdMiddle.AddRowDefinition(new RowDefinition { Height = 45 });
        grdMiddle.AddRowDefinition(new RowDefinition { Height = GridLength.Star });
        grdMiddle.AddRowDefinition(new RowDefinition { Height = 45 });
        grdMiddle.Add(new SearchBar { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Start, Placeholder = "Search", IsSpellCheckEnabled = true }, 0, 0);
        grdMiddle.Add(new CollectionView { ItemTemplate = datatem, ItemsSource = ItemsSource }, 0, 1);
        grdMiddle.Add(new HorizontalStackLayout { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.End, Children = { btnCancel, btnAdd } }, 0, 2);

        popup.Content = new Frame {  CornerRadius = 20, Content = new VerticalStackLayout { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill, Children = { lblTitle, grdMiddle } } };

        //Get the current page this control is on
        bool loop = true;
        var p = Parent;
        do
        {
            if (p.GetType().Name.Contains("Page"))
            {
                loop = false;
            }
            else
            {
                p = p.Parent;
            }
        } while (loop);
        var page = (Page)p;

        await PopupExtensions.ShowPopupAsync(page, popup);
    }
}