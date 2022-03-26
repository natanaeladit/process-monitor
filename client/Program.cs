using Grpc.Net.Client;
using Monitor;

try
{
    using var channel = GrpcChannel.ForAddress("https://localhost:7049");
    var client = new Greeter.GreeterClient(channel);
    var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });

    Console.WriteLine("Call service successfully");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}