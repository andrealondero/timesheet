using timesheet.Models;
using Xamarin.Forms;

namespace timesheet.Views
{
    public class PageBViewerCS : ContentPage

    {
        ListView listView;

        public PageBViewerCS()
        {
            Title = "TS";

            var toolbarItem = new ToolbarItem
            {
                Text = "+",
                Icon = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
            };
            toolbarItem.Clicked += async (sender, e) =>
            {

                await Navigation.PushAsync(new PageACompilerCS
                {
                    BindingContext = new TsItems()
                });
            };

            ToolbarItems.Add(toolbarItem);

            var pickerstatusLabel = new Label();
            var picker = new Picker { Title = "Select status", TitleColor = Color.DarkRed };
            picker.Items.Add("CONFIRMED");
            picker.Items.Add("REFUSED");
            picker.Items.Add("SUSPENDED");
            picker.SelectedIndexChanged += (sender, e) =>
            {
                int selectedIndex = picker.SelectedIndex;
                if (selectedIndex != -1)
                {
                    pickerstatusLabel.Text = picker.Items[selectedIndex];
                }
            };

            var contentStacklayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { pickerstatusLabel, picker }
            };

            listView = new ListView
            {
                Margin = new Thickness(20),
                ItemTemplate = new DataTemplate(() =>
                {

                    var label = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.Start
                    };
                    label.SetBinding(Label.TextProperty, "Date");

                    var label1 = new Label
                    {
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    label1.SetBinding(Label.TextProperty, "Description");

                    var tick = new Image
                    {
                        Source = ImageSource.FromFile("check.png"),
                        HorizontalOptions = LayoutOptions.End
                    };
                    tick.SetBinding(VisualElement.IsVisibleProperty, "ConfirmedStatus");

                    var tick1 = new Image
                    {
                        Source = ImageSource.FromFile("check.png"),
                        HorizontalOptions = LayoutOptions.End
                    };
                    tick1.SetBinding(VisualElement.IsVisibleProperty, "RefusedStatus");

                    var stackLayout = new StackLayout
                    {
                        Margin = new Thickness(20, 0, 0, 0),
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { label, label1, tick, tick1 }
                    };
                    return new ViewCell { View = stackLayout };
                })
            };

            listView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new PageACompilerCS
                    {
                        BindingContext = e.SelectedItem as TsItems
                    });
                }
            };
            Content = listView;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
    }
}