using timesheet.Models;
using Xamarin.Forms;

namespace timesheet.Views
{
    public class PageCConfirmationListCS : ContentPage

    {
        ListView listView;

        public PageCConfirmationListCS()
        {
            Title = "TS";

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
                        Children = { label, tick }
                    };
                    return new ViewCell { View = stackLayout };
                })
            };

            listView.ItemSelected += async (sender, e) =>
            {
                //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TsItems).ID;
                //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TsItems).ID);
                if (e.SelectedItem != null)
                {
                    await Navigation.PushAsync(new PageDConfirmation
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
            listView.ItemsSource = await App.Database.GetAllItemsAsync();
        }
    }
}