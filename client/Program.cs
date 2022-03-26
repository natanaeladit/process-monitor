using Grpc.Net.Client;
using Monitor;

try
{
    var httpHandler = new HttpClientHandler();
    httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
    using var channel = GrpcChannel.ForAddress("https://localhost:7049", new GrpcChannelOptions { HttpHandler = httpHandler });
    var client = new Greeter.GreeterClient(channel);
    var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });

    Console.WriteLine($"Call service successfully {reply.Message}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}