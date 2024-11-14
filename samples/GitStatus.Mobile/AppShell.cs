namespace GitStatus;

partial class AppShell : Shell
{
	public AppShell(GraphQLApiStatusPage graphQLApiStatusPage, RestApiStatusPage restApiStatusPage)
	{
		Items.Add(new TabBar
		{
			Items =
			{
				graphQLApiStatusPage,
				restApiStatusPage
			}
		});
	}
}