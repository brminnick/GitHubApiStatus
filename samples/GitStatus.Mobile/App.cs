namespace GitStatus;

class App(AppShell appShell) : Application
{
	readonly AppShell _appShell = appShell;

	protected override Window CreateWindow(IActivationState? activationState)
	{
		base.CreateWindow(activationState);
		return new(_appShell);
	}
}