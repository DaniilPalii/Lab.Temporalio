using Temporalio.Client;
using Temporalio.Worker;
using TemporalioLab.Workflows;

var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

using var cancellationTokenSource = new CancellationTokenSource();
Console.CancelKeyPress += (_, eventArgs) =>
{
	cancellationTokenSource.Cancel();
	eventArgs.Cancel = true;
};

var activity = new MyActivities();

using var worker = new TemporalWorker(
	client,
	new TemporalWorkerOptions("my-task-queue")
		.AddActivity(activity.SayHello)
		.AddWorkflow<SayHelloWorkflow>());

Console.WriteLine("Running worker");

try
{
	await worker.ExecuteAsync(cancellationTokenSource.Token);
}
catch (OperationCanceledException)
{
	Console.WriteLine("Operation cancelled");
}