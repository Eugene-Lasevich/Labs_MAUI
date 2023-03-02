namespace MauiApp1;


public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

    }

    List<double> numbers = new List<double>();
    List<string> signs = new List<string>();
    bool flagDigit = false;
    bool flagSign = false;
    bool flagDigitComa =false;
    int comaCounter = 0;

    private void OnButtonClicked(object sender, System.EventArgs e)
    {
        Button button = (Button)sender;
        double tmp = 0;
        if (!flagDigit) return;
        flagDigit = false;
        flagSign = true;
        comaCounter = 0;

        if (double.TryParse(DownLabel.Text, out tmp))
        {
            numbers.Add(tmp);
            UpLabel.Text += (DownLabel.Text + button.Text);
        }


        if (signs.Count == 0)
        {
            signs.Add(button.Text);
            DownLabel.Text = "";
        }
        if (numbers.Count == 1 && signs.Count > 0 && tmp != numbers.Last())
        {
            if (tmp == 0)
            {
                UpLabel.Text += signs.Last();
                return;
            }
            double f = RRR(numbers.Last(), tmp, signs[0]);
            UpLabel.Text = f.ToString() + button.Text;
            signs.Add(button.Text);
        }
        if (numbers.Count == 2)
        {
            double f = RRR(numbers[0], numbers[1], signs[0]);
            UpLabel.Text = f.ToString() + button.Text;
            DownLabel.Text = "";
            numbers.Clear();
            numbers.Add(f);
            signs.Clear();
            signs.Add(button.Text);
            //flagDigit = true;
        }


    }

    private double RRR(double el1, double el2, string str)
    {
        switch (str)
        {
            case "+":
                return el1 + el2;
            case "-":
                return el1 - el2;
            case "*":
                return el1 * el2;
            case "/":
                if (el2 == 0)
                {
                    DownLabel.Text = "";
                    UpLabel.Text = "";
                    numbers.Clear();
                    signs.Clear();
                    return 0;

                }
                return el1 / el2;

            case "^":
                return Math.Pow(el1, el2);
            case "%":
                return el1 * (el2 / 100);

        }
        return 0;
    }
    private void OnEqualsButtonClicked(object sender, System.EventArgs e)
    {
        if (!flagSign) return;
        Button button = (Button)sender;
        double tmp = 0;
        if (button.Text == "=")
        {
            if (double.TryParse(DownLabel.Text, out tmp))
            {
                numbers.Add(tmp);
                UpLabel.Text += (DownLabel.Text + button.Text);
            }

            if (numbers.Count == 0) return;


            if (numbers.Count == 1 && signs.Count > 0)
            {
                string sign = signs.Last();
                double f = RRR(numbers[0], numbers[0], sign);
                numbers.Clear();
                numbers.Add(f);
                signs.Clear();
                UpLabel.Text = f.ToString();
                DownLabel.Text = "";
                flagDigit = true;

            }



            if (numbers.Count == 2)
            {
                if(signs.Count == 0)
                {
                    numbers.Clear();
                    UpLabel.Text = DownLabel.Text;
                    numbers.Add(double.Parse(DownLabel.Text));
                    DownLabel.Text = "";
                    return;
                }
                double f = RRR(numbers[0], numbers[1], signs.Last());
                numbers.Clear();
                numbers.Add(f);
                UpLabel.Text = f.ToString();
                DownLabel.Text = "";
                signs.Clear();
                //flagDigit = true;



            }
        }
    }

    private void OnDigitButtonClicked(object sender, System.EventArgs e)
    {
        Button button = (Button)sender;
        DownLabel.Text += button.Text;
        flagDigit = true;
        flagDigitComa = true;
    }

    private void OnBackSpaceClicked(object sender, System.EventArgs e)
    {
        string tmp = "";
        tmp = DownLabel.Text;
        if (tmp.Length > 0) DownLabel.Text = tmp.Remove(tmp.Length - 1);


    }

    private void OnDeleteSpaceClicked(object sender, System.EventArgs e)
    {
        DownLabel.Text = "";
        UpLabel.Text = "";
        numbers.Clear();
        signs.Clear();
    }

    private void OnComaClicked(object sender, System.EventArgs e)
    {
        Button button = (Button)sender;
        if (flagDigitComa && comaCounter<1)
        {
            DownLabel.Text += button.Text;
            flagDigitComa = false;
            comaCounter++;
        }
    }
}
