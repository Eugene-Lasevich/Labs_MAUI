using Microsoft.Maui.ApplicationModel;

namespace MauiApp1;

public partial class Progress : ContentPage
{
    CancellationTokenSource cancelTokenSource1 = new CancellationTokenSource();
   // static CancellationToken token = cancelTokenSource.Token;



    public Progress()
    {
        InitializeComponent();
    }
    bool flagStart = true;
    bool flagCancel = false;

    private Task<string> CalculationOfIntegral()
    {

        return Task.Run(() =>
        {

            double sum = 0;
            double step = 0.000000001;
            double completion = 0;
            for (double x = 0; x <= 1; x += step)
            {
                if (cancelTokenSource1.IsCancellationRequested)
                {
                    return "";
                }
                sum += Math.Sin(x) * step;
                if (completion + 0.01 <= x * 100)
                {
                    completion = x * 100;

                    PROGRESS.Dispatcher.Dispatch(new Action(() =>
                    {
                        PROGRESS.Progress = completion / 100;
                        Percent.Text = completion.ToString("0.#") + '%';
                    }));
                }

            }
            return sum.ToString();
        });


    }





    private async void OnButtonStartClicked(object sender, System.EventArgs e)
    {
        if (flagStart)
        {
            Button button = (Button)sender;
            cancelTokenSource1 = new CancellationTokenSource();
            flagStart = false;
            flagCancel = true;
            UpLabel.Text = "Вычисление";
            PROGRESS.Progress = 0;
            string task = await CalculationOfIntegral();
            cancelTokenSource1 = null;

            if (task == "") return;

            flagStart = true;
            UpLabel.Text = "Результат вычисления " + task;
            PROGRESS.Progress = 0;
        }
       
    }

    private void OnButtonCancelClicked(object sender, System.EventArgs e)
    {
        if(flagCancel && cancelTokenSource1 != null)
        {
            Button button = (Button)sender;
            UpLabel.Text = "Задание отменено";
            cancelTokenSource1.Cancel();
            cancelTokenSource1 = null;
            flagStart = true;
            flagCancel = false;

        }

      
    }

  



}