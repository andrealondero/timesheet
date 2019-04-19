using timesheet.Helpers;
using timesheet.Models;
using Xamarin.Forms;

namespace timesheet.Views
{
    public class PageDConfirmationCS : ContentPage

    {
        public PageDConfirmationCS()
        {
            Title = "Ts Item";

            var datePicker = new DatePicker();
            datePicker.SetBinding(DatePicker.DateProperty, "Date");

            var workedhEntry = new Entry();
            workedhEntry.SetBinding(Entry.TextProperty, "Hours");

            var notesEditor = new Editor();
            notesEditor.SetBinding(Editor.TextProperty, "Description");

            var conSwitch = new Switch();
            conSwitch.SetBinding(Switch.IsToggledProperty, "ConfirmedStatus");

            var refSwitch = new Switch();
            refSwitch.SetBinding(Switch.IsToggledProperty, "RefusedStatus");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var tsItem = (TsItems)BindingContext;
                await App.Database.SaveItemAsync(tsItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var tsItem = (TsItems)BindingContext;
                await App.Database.DeleteItemAsync(tsItem);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            var speakButton = new Button { Text = "Speak" };
            speakButton.Clicked += (sender, e) =>
            {                var tsItem = (TsItems)BindingContext;
                DependencyService.Get<ITextToSpeech>().Speak(tsItem.Hours + " " + tsItem.Description);
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Date" },
                    new Label { Text = "Hours" },
                    workedhEntry,
                    new Label { Text = "Description" },
                    notesEditor,
                    new StackLayout(),
                    new Label { Text = "Confirm" },
                    conSwitch,
                    new Label { Text = "Refuse"},
                    refSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton,
                    speakButton
                }
            };
        }
    }
}