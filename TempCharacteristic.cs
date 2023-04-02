using System.Text;
using DotnetBleServer.Gatt;
using DotnetBleServer.Gatt.Description;

namespace YP.CPUTemp;

public class TempCharacteristic : BaseCharacteristic
{
    const string TEMP_CHARACTERISTIC_UUID = "00000002-710e-4a5b-8d75-3e5b444bc3cf";

    public TempCharacteristic()
    {
        Description = new GattCharacteristicDescription
        {
            // CharacteristicSource = new ExampleCharacteristicSource(),
            UUID = TEMP_CHARACTERISTIC_UUID,
            Flags = new[] { "notify", "read" }
        };

        Description.AddDescriptor(new UnitDescriptor().Description);
    }
}

public class TempDescriptor : BaseDescriptor
{
    const string TEMP_DESCRIPTOR_UUID = "2901";
    const string TEMP_DESCRIPTOR_VALUE = "CPU Temperature";

    public TempDescriptor()
    {
        Description = new GattDescriptorDescription
        {
            Value = Encoding.ASCII.GetBytes(TEMP_DESCRIPTOR_VALUE),
            UUID = TEMP_DESCRIPTOR_UUID,
            Flags = new[] { "read" }
        };
    }
}

internal class ExampleCharacteristicSource : ICharacteristicSource
{
    public Task WriteValueAsync(byte[] value)
    {
        Console.WriteLine("Writing value");
        return Task.Run(() => Console.WriteLine(Encoding.ASCII.GetChars(value)));
    }

    public Task<byte[]> ReadValueAsync()
    {
        Console.WriteLine("Reading value");
        return Task.FromResult(Encoding.ASCII.GetBytes("Hello BLE"));
    }
}