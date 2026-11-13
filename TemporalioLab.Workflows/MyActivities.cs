using Temporalio.Activities;

namespace TemporalioLab.Workflows;

public class MyActivities
{
	[Activity]
	public string SayHello(string name)
	{
		return $"Hello, {name}!";
	}
}
