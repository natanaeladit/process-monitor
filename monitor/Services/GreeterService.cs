using Grpc.Core;
using System.Diagnostics;

namespace Monitor.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        string pid = string.Empty;
        try
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            path = Path.Combine(path, "..", "cli", "build", "./cli");
            Process process = new Process();
            process.StartInfo.FileName = path;
            process.StartInfo.Arguments = "-n";
            process.Start();
            pid = process.Id.ToString();
        }
        catch {}

        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name + $" PID {pid}"
        });
    }
}
