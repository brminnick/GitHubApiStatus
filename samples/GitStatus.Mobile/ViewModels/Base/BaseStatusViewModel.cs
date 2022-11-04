using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GitStatus;

abstract partial class BaseStatusViewModel : BaseViewModel
{
    [ObservableProperty]
    string _statusLabelText = string.Empty;

    [ObservableProperty, NotifyCanExecuteChangedFor(nameof(GetStatusCommand))]
    bool _isBusy;

    public bool IsNotBusy => !IsBusy;

    [RelayCommand(CanExecute = nameof(IsNotBusy))]
    protected abstract Task GetStatus();
}
