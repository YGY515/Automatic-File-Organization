using FileOrganization_Api.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;

namespace FileOrganization_WPF;

public partial class LogsWindow : Window
{
    private static readonly HttpClient client = new HttpClient();

    public LogsWindow()
    {
        InitializeComponent();
        Loaded += async (s, e) => await LoadLogs(null);
    }

    private async Task LoadLogs(bool? cancelled)
    {
        string url = "https://localhost:7179/api/logs";
        if (cancelled.HasValue)
            url += $"?cancelled={cancelled.Value}";

        var logs = await client.GetFromJsonAsync<List<OrganizeLogDto>>(url);
        LogGrid.ItemsSource = logs;
    }

    private async void Filter_Changed(object sender, SelectionChangedEventArgs e)
    {
        var selected = (CancelledFilter.SelectedItem as ComboBoxItem)?.Content.ToString();
        bool? filter = selected switch
        {
            "취소됨" => true,
            "완료됨" => false,
            _ => null
        };
        await LoadLogs(filter);
    }
}