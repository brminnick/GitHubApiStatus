namespace GitStatus;

class RestApiStatusPage : BaseStatusPage<RestApiStatusViewModel>
{
	public RestApiStatusPage(RestApiStatusViewModel restApiStatusViewModel) : base(restApiStatusViewModel, "REST API Status")
	{
	}
}