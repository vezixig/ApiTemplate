using Projects;

var builder = DistributedApplication.CreateBuilder(args);

// add ApiTemplate
var api = builder.AddProject<Framework>("ApiTemplate");
api.WithUrl($"{api.GetEndpoint("https")}/scalar", "Scalar");

await builder.Build().RunAsync();