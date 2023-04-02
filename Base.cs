using DotnetBleServer.Gatt.Description;

namespace YP.CPUTemp;

public abstract class BaseCharacteristic
{
    public GattCharacteristicDescription Description { get; init; }
}

public abstract class BaseDescriptor
{
    public GattDescriptorDescription Description { get; init; }
}