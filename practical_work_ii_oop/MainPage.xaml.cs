using System;
using System.IO;
using Microsoft.Maui.Storage;

namespace MAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnSignInClicked(object sender, EventArgs e)
	{
		string username = usernameEntry.Text?.Trim();
		string password = passwordEntry.Text?.Trim();

		if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
		{
			await DisplayAlert("Error", "Please enter username and password", "OK");
			return;
		}

		string filePath = "users.csv";

		if (!File.Exists(filePath))
		{
			await DisplayAlert("Error", "User file not found", "OK");
			return;
		}

		var lines = File.ReadAllLines(filePath).Skip(1);

		foreach (var line in lines)
		{
			var parts = line.Split(',');

			if (parts.Length < 5) continue;

			string csvUsername = parts[1];
			string csvPassword = parts[3];

			if (csvUsername == username && csvPassword == password)
			{
				await Navigation.PushAsync(new CalculatorPage());
				return;
			}
		}

		await DisplayAlert("Error", "Invalid username or password", "OK");
	}

	private async void OnForgotPasswordTapped(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ForgotPasswordPage());
	}

	private async void OnGoToRegisterClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new RegisterPage());
	}

	private async void OnGoToCalculator(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CalculatorPage());
	}

	


}            