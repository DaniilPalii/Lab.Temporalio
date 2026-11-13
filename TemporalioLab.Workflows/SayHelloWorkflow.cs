using Temporalio.Workflows;

namespace TemporalioLab.Workflows;

[Workflow]
public class SayHelloWorkflow
{
	[WorkflowRun]
	public async Task<string> RunAsync(string name)
	{
		return await Workflow.ExecuteActivityAsync<MyActivities, string>(
			activitiy => activitiy.SayHello(name),
			options: new()
			{
				StartToCloseTimeout = TimeSpan.FromMinutes(5),
			});
	}
}
