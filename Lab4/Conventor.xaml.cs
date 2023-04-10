namespace MauiApp1.Lab4;
using Lab4.Entities;
using Lab4.Services;
//using Microsoft.UI.Xaml.Controls;

public partial class Conventor : ContentPage
{
    private IRateService _rateService;
    public List<Rate> RatesList { get; set; } = new();

    public DateTime TodayDate { get; init; }

    private Rate _curRate { get; set; } = null;

    public void value_initialization(List<Rate> rates)
    {
        foreach(var rate in rates)
        {
            var num = decimal.Parse(Byn.Text);
            if (rate.Cur_Abbreviation == "USD") l1.Text = (num * rate.Cur_Scale / rate.Cur_OfficialRate).ToString();
            if (rate.Cur_Abbreviation == "EUR") l2.Text = (num * rate.Cur_Scale / rate.Cur_OfficialRate).ToString();
            if (rate.Cur_Abbreviation == "PLN") l3.Text = (num * rate.Cur_Scale / rate.Cur_OfficialRate).ToString();
            if (rate.Cur_Abbreviation == "CNY") l4.Text = (num * rate.Cur_Scale / rate.Cur_OfficialRate).ToString();


        }
    }

    public Conventor(IRateService service)
	{
        TodayDate = DateTime.Today;
        InitializeComponent();
        _rateService = service;
        BindingContext = this;
    }

    public async void DateSelected(object sender, EventArgs e)
    {
        l1.Text = "";
        l2.Text = "";
        l3.Text = "";
        l4.Text = "";
        RatesList.Clear();
        
        RatesList = (await _rateService.GetRates(datePicker.Date)).ToList();
        p5.ItemsSource = RatesList;
        value_initialization(RatesList);
    }


    public void OnPicker(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (OtherCur.Text == null) return;


        if (selectedIndex != -1)
        {
            var num = decimal.Parse(OtherCur.Text);
            var tmp = picker.SelectedItem as Rate;
            Byn.Text = (num / tmp.Cur_Scale * tmp.Cur_OfficialRate).ToString();
            value_initialization(RatesList);
            
        }
    }
    public async void OnLoaded(object sender, EventArgs e)
    {
        RatesList = (await _rateService.GetRates(datePicker.Date)).ToList();

        p5.ItemsSource = RatesList;
        value_initialization(RatesList);
        


    }
}