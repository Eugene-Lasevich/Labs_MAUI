namespace MauiApp1;
using MauiApp1.Lab3.Services;
using MauiApp1.Lab3.Entities;

public partial class SQLlitePage : ContentPage
{
    private IDbService DbService { get; init; }

    public List<Performer> PerformersList { set; get; }

    public List<Song> SongsList { set; get; }

    public SQLlitePage(IDbService dbService)
    {
        DbService = dbService;
        DbService.Init();
        BindingContext = this;
        InitializeComponent();
    }

    public void OnLoaded(object sender, EventArgs e)
    {
        PerformersList = DbService.GetAllPerformers().ToList();
        picker.ItemsSource = PerformersList.ToList();

    }


    void OnPicker(object sender, EventArgs e)
    {

        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        Console.WriteLine(selectedIndex.ToString());


        if (selectedIndex != -1)
        {
            SongsList = (DbService.GetExecutableSongs((picker.SelectedItem as Performer).Id)).ToList();
            listView.ItemsSource = SongsList;
        }
    }

    void OnBtn(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        picker.ItemsSource = PerformersList.ToList();
    }
}