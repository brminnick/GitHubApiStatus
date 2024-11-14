using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GitStatus;

abstract partial class BaseStatusViewModel : BaseViewModel
{
	protected BaseStatusViewModel()
	{
		StatusLabelText = string.Empty;
	}

	[ObservableProperty]
	public partial string StatusLabelText { get; protected set; }

	[ObservableProperty, NotifyPropertyChangedFor(nameof(IsNotBusy)), NotifyCanExecuteChangedFor(nameof(GetStatusCommand))]
	public partial bool IsBusy { get; protected set; }

	public bool IsNotBusy => !IsBusy;

	[RelayCommand(CanExecute = nameof(IsNotBusy))]
	protected abstract Task GetStatus();
}