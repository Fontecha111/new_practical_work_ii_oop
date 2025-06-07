namespace MAUI;

public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage()
    {
        InitializeComponent();
    }

    private async void OnSendRecoveryClicked(object sender, EventArgs e)
    {
        string email = emailEntry.Text?.Trim();

        if (string.IsNullOrEmpty(email))
        {
            await DisplayAlert("Error", "You have to introduce your email", "OK");
            return;
        }

        await DisplayAlert("Recovery email has been sent", $"An email has been send to {email}", "OK");
    }

    private async void OnBackToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}