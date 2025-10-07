using System.Diagnostics;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using MaterialDesignThemes.Wpf;

namespace QuestionDemo;

public partial class MainWindowViewModel : ObservableObject
{
    //This is using the source generators from CommunityToolkit.Mvvm to generate an ObservableProperty
    //See: https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/generators/observableproperty
    //and: https://learn.microsoft.com/windows/communitytoolkit/mvvm/observableobject
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(IncrementCountCommand))]
    private int _count;

    [ObservableProperty]
    private List<string> _options = ["Item 1", "Item 2", "Item 3"];
    [ObservableProperty]
    private string? _selectedOption;

    [ObservableProperty]
    private PackIcon? _specialCommandBadge;
    [ObservableProperty]
    private string? _specialCommandTooltip;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SendSpecialCommand))]
    private bool _canInteract = true;

    public MainWindowViewModel()
    {

    }

    //This is using the source generators from CommunityToolkit.Mvvm to generate a RelayCommand
    //See: https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/generators/relaycommand
    //and: https://learn.microsoft.com/windows/communitytoolkit/mvvm/relaycommand
    [RelayCommand(CanExecute = nameof(CanIncrementCount))]
    private void IncrementCount()
    {
        Count++;
        CanInteract = !CanInteract;
    }

    private bool CanIncrementCount() => Count < 5;

    [RelayCommand]
    private void ClearCount()
    {
        Count = 0;
    }

    private bool CanInteractWithButton()
    {
        bool isGenConnected = CanInteract;

        if (isGenConnected)
        {
            SpecialCommandBadge = null;
            SpecialCommandTooltip = null;
        }
        else
        {
            SpecialCommandBadge = new() { Kind = PackIconKind.CommentAlert };
            SpecialCommandTooltip = "";
            SpecialCommandTooltip += !CanInteract ? " - Cannot interact with button at the moment." : "";
        }
        return isGenConnected;
    }

    [RelayCommand(CanExecute = nameof(CanInteractWithButton))]
    private void SendSpecial()
    {
        Debug.WriteLine("Sending special command");
    }
}
