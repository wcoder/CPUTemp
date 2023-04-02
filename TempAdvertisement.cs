using DotnetBleServer.Advertisements;
using DotnetBleServer.Core;

namespace YP.CPUTemp;

public class TempAdvertisement
{
    private const string THERMOMETER_SVC_UUID = "00000001-710e-4a5b-8d75-3e5b444bc3cf";

    private readonly AdvertisingManager _advertisingManager;

    public TempAdvertisement(ServerContext serverContext)
    {
        _advertisingManager = new AdvertisingManager(serverContext);
    }

    public async Task Register()
    {
        var advertisementProperties = new AdvertisementProperties
        {
            Type = "peripheral",
            ServiceUUIDs = new[] { THERMOMETER_SVC_UUID },
            LocalName = "Thermometer2",
            IncludeTxPower = true,
        };

        await _advertisingManager.CreateAdvertisement(advertisementProperties);
    }
}