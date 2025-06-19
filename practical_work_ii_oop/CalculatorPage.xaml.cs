using oppguidedpw;

namespace MAUI;

public partial class CalculatorPage : ContentPage
{

    private User currentUser = new User("", "", "");
    private Converter converter = new Converter();
    public CalculatorPage(User user)
    {
        InitializeComponent();
        currentUser = user;
        
    }

    
    private void OnNumberClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            inputEntry.Text += button.Text;
        }
    }

    private void OnSymbolClicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            inputEntry.Text += button.Text;
        }
    }


    private void OnClearClicked(object sender, EventArgs e)
    {
        inputEntry.Text = string.Empty;
        bitsEntry.Text = string.Empty;
    }

    private async void OnDecimalToBinaryClicked(object sender, EventArgs e)
    {
        string input = inputEntry.Text;
        string result = converter.PerformConversion(1, input);
        inputEntry.Text = $"Binary: {result}";
        currentUser.IncrementOperation();
    }

    private async void OnDecimalToOctalClicked(object sender, EventArgs e)
    {
        string input = inputEntry.Text;
        string result = converter.PerformConversion(2, input);
        inputEntry.Text = $"Octal: {result}";
        currentUser.IncrementOperation();
    }

    private async void OnDecimalToHexadecimalClicked(object sender, EventArgs e)
    {
        string input = inputEntry.Text;
        string result = converter.PerformConversion(3, input);
        inputEntry.Text = $"Hexadecimal: {result}";
        currentUser.IncrementOperation();
    }

    private async void OnDecimalToTwoComplementClicked(object sender, EventArgs e)
    {
        string input = inputEntry.Text;
        string bitsText = bitsEntry.Text;

        int bits;
        if (!int.TryParse(bitsText, out bits) || bits <= 0)
        {
            await DisplayAlert("Stop", "Enter a valid bit size", "OK");
            inputEntry.Text = "";
            return;
        }

        try
        {
            int number = int.Parse(input);
            int minValue = -(1 << (bits - 1));
            int maxValue = (1 << (bits - 1)) - 1;

            if (number < minValue || number > maxValue)
            {
                await DisplayAlert("Error", $"The number must be between {minValue} and {maxValue}", "OK");
                inputEntry.Text = "";
                return;
            }

            string result;

            if (number < 0)
            {
                int value = (1 << bits) + number;
                result = Convert.ToString(value, 2).PadLeft(bits, '0');
            }
            else
            {
                result = Convert.ToString(number, 2).PadLeft(bits, '0');
            }

            inputEntry.Text = $"Two Complement: {result}";
            currentUser.IncrementOperation();
        }

        catch
        {
            await DisplayAlert("Error", "This is an invalid input for this conversion", "OK");
            inputEntry.Text = "";
        }
        
    }

    private async void OnBinaryToDecimalClicked(object sender, EventArgs e)
    {
        string input = inputEntry.Text;
        string result = converter.PerformConversion(5, input);
        inputEntry.Text = $"Decimal: {result}";
        currentUser.IncrementOperation();
    }

    private async void OnOctalToDecimalClicked(object sender, EventArgs e)
    {
        string input = inputEntry.Text;
        string result = converter.PerformConversion(7, input);
        inputEntry.Text = $"Decimal: {result}";
        currentUser.IncrementOperation();
    }

    private async void OnHexadecimalToDecimalClicked(object sender, EventArgs e)
    {
        string input = inputEntry.Text;
        string result = converter.PerformConversion(8, input);
        inputEntry.Text = $"Decimal: {result}";
        currentUser.IncrementOperation();
    }

    private async void OnTwoComplementToDecimalClicked(object sender, EventArgs e)
    {
        string input = inputEntry.Text.Trim();
        if (!int.TryParse(bitsEntry.Text, out int bits) || bits <= 0)
        {
            await DisplayAlert("Error", "Invalid bit size.", "OK");
            return;
        }

        if (input.Length > bits)
        {
            input = input.Substring(input.Length - bits);  
        }

        else if (input.Length < bits)
        {
            await DisplayAlert("Error", $"Input must be exactly {bits} bits.", "OK");
            return;
        }

        if (!input.All(c => c == '0' || c == '1'))
        {
            await DisplayAlert("Error", "Input must be a binary number.", "OK");
            return;
        }

        try
        {
            int value = Convert.ToInt32(input, 2);
            if (input[0] == '1')
                value -= (1 << bits); 

            inputEntry.Text = $"Decimal: {value}";
            currentUser.IncrementOperation();
        }
        catch
        {
            await DisplayAlert("Error", "Invalid conversion.", "OK");
            inputEntry.Text = "";
        }
    }

    private async void OnShowUserInfoClicked(object sender, EventArgs e)
    {
        string info = $"Name: {currentUser.getName()}\n" + $"Username: {currentUser.getUsername()}\n" + $"Password: {currentUser.getPassword()}\n" + $"Operations: {currentUser.getOperationCount()}";

        await DisplayAlert("User Info", info, "OK");
    }
}
