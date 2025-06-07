using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;
using System.IO;

namespace MAUI;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string name = nameEntry.Text?.Trim();
        string username = usernameEntry.Text?.Trim();
        string email = emailEntry.Text?.Trim();
        string password = passwordEntry.Text;
        string confirmPassword = confirmPasswordEntry.Text;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) ||
            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(confirmPassword))
        {
            await DisplayAlert("Error", "You must fill all the posible fields", "OK");
            return;
        }

        if (name == username)
        {
            await DisplayAlert("Error", "Name and username must be different.", "OK");
            return;
        }

        if (password != confirmPassword)
        {
            await DisplayAlert("Error", "Passwords must be equal", "OK");
            return;
        }

        if (!IsValidPassword(password))
        {
            await DisplayAlert("Error", "Password must have at least 8 characters, one uppercase, one lowercase, one number, and one special symbol.", "OK");
            return;
        }

        if (!termsCheckBox.IsChecked)
        {
            await DisplayAlert("Error", "You must accept the privacy policy.", "OK");
            return;
        }

        string filePath = "users.csv";

        bool fileExists = File.Exists(filePath);
        using (var writer = new StreamWriter(filePath, append: true))
        {
            if (!fileExists)
                writer.WriteLine("Name,Username,Email,Password,Operations");

            writer.WriteLine($"{name},{username},{email},{password},0");
        }

        await DisplayAlert("Success", "User registered successfully!", "OK");
        await Navigation.PushAsync(new MainPage()); //This will make you go back to the Main Page
    }

    private bool IsValidPassword(string password)
    {
        return password.Length >= 8 &&
               password.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()) >= 0 &&
               password.IndexOfAny("abcdefghijklmnopqrstuvwxyz".ToCharArray()) >= 0 &&
               password.IndexOfAny("0123456789".ToCharArray()) >= 0 &&
               password.IndexOfAny("!@#€&%/-_".ToCharArray()) >= 0;
    }
    private async void OnGoToLoginTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}