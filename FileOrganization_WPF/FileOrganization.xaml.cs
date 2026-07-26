using System.Windows;
using System.Diagnostics;
using MessageBox = System.Windows.MessageBox;

namespace FileOrganization_WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, IMainView
{
    private string _path = null;
    private readonly MainPresenter _presenter;

    public string SelectedPath => _path;
    public string SelectedMode
    {
        get
        {
            if (ExtensionRadio.IsChecked == true) return "확장자";
            if (DateRadio.IsChecked == true) return "날짜";
            if (LanguageRadio.IsChecked == true) return "언어";
            return null;
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        _presenter = new MainPresenter(this);
    }
    private void SelectFolder_Click(object sender, RoutedEventArgs e)
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();

        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            _path = dialog.SelectedPath;
        }

        PathDisplay.Text = _path;
    }

    private void OrganizeButton_Click(object sender, RoutedEventArgs e)
    {
        _presenter.OnOrganizeClicked();
    }

    public void ShowResult(string message)
    {
        var dialoug = System.Windows.MessageBox.Show(
                message + "\n\n정리된 폴더를 열어보시겠습니까?",
                "정리 완료",
                MessageBoxButton.YesNo
            );

        if (dialoug == MessageBoxResult.Yes)
            Process.Start("explorer.exe", _path);
    }

    public void ShowError(string message)
    {
        MessageBox.Show(message);
    }
    /*
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new FileOrganizerViewModel();
    }

    private void SelectFolder_Click(object sender, RoutedEventArgs e)
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();

        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            path = dialog.SelectedPath;
            if (Directory.Exists(path) == false)
            {
                System.Windows.MessageBox.Show("올바른 폴더를 입력하세요");
            }
        }

        PathDisplay.Text = path;
        var vm = (FileOrganizerViewModel)DataContext;
        //await vm.StartOrganizeAsync(path, selectedOrganizer);
    }

    private void OrganizeButton_Click(object sender, RoutedEventArgs e)
    {
        if (ExtensionRadio.IsChecked == true)
            organizer = new Extension();
        else if (DateRadio.IsChecked == true)
            organizer = new Date();
        else if (LanguageRadio.IsChecked == true)
            organizer = new Language();

        CancellationTokenSource cts = new CancellationTokenSource();
        string result = organizer.Organize(path, cts.Token);

        var dialoug = System.Windows.MessageBox.Show(
                result + "\n\n정리된 폴더를 열어보시겠습니까?",
                "정리 완료",
                MessageBoxButton.YesNo
            );

        if (dialoug == MessageBoxResult.Yes)
            Process.Start("explorer.exe", path);
    }
    */
}