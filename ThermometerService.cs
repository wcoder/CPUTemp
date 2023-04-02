using DotnetBleServer.Core;
using DotnetBleServer.Gatt;
using DotnetBleServer.Gatt.Description;

namespace YP.CPUTemp;

public class ThermometerService
{
    private const string THERMOMETER_SVC_UUID = "00000001-710e-4a5b-8d75-3e5b444bc3cf";

    private readonly GattApplicationManager _gattApplicationManager;

    public ThermometerService(ServerContext serverContext)
    {
        _gattApplicationManager = new GattApplicationManager(serverContext);
    }

    public async Task Register()
    {
        var appBuilder = new GattApplicationBuilder();

        var service = new GattServiceDescription
        {
            UUID = THERMOMETER_SVC_UUID,
            Primary = true
        };
        appBuilder.AddService(service);

        service.AddCharacteristic(new TempCharacteristic().Description);
        service.AddCharacteristic(new UnitCharacteristic().Description);

        var finalServiceDescriptions = appBuilder.BuildServiceDescriptions();

        await _gattApplicationManager.RegisterGattApplication(finalServiceDescriptions);
    }
}