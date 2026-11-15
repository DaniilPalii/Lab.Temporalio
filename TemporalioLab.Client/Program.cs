using Temporalio.Client;
using TemporalioLab.Workflows;

var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

var result = await client.ExecuteWorkflowAsync(
	(SayHelloWorkflow workflow) => workflow.RunAsync("Temporal"),
	options: new(
		id: $"my-workflow-id-{Guid.NewGuid()}",
		taskQueue: "my-task-queue"));

Console.WriteLine("Workflow result: {0}", result);
