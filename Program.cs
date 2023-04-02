using DotnetBleServer.Core;
using YP.CPUTemp;

// Port to .NET: https://github.com/Douglas6/cputemp
// BLE server example: https://github.com/phylomeno/dotnet-ble-server/tree/master/Examples
await Task.Run(async () =>
{
    using (var serverContext = new ServerContext())
    {
        await serverContext.Connect();

        await new TempAdvertisement(serverContext).Register();
        await new ThermometerService(serverContext).Register();

        Console.WriteLine("Press CTRL+C to quit");
        await Task.Delay(-1);
    }
});
