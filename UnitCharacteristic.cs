using System.Text;
using DotnetBleServer.Gatt.Description;

namespace YP.CPUTemp;

public class UnitCharacteristic : BaseCharacteristic
{
    const string UNIT_CHARACTERISTIC_UUID = "00000003-710e-4a5b-8d75-3e5b444bc3cf";

    public UnitCharacteristic()
    {
        Description = new GattCharacteristicDescription
        {
            UUID = UNIT_CHARACTERISTIC_UUID,
            Flags = new[] { "read", "write" }
        };

        Description.AddDescriptor(new UnitDescriptor().Description);
    }
}

public class UnitDescriptor : BaseDescriptor
{
    const string UNIT_DESCRIPTOR_UUID = "2901";
    const string UNIT_DESCRIPTOR_VALUE = "Temperature Units (F or C)";

    public UnitDescriptor()
    {
        Description = new GattDescriptorDescription
        {
            Value = Encoding.ASCII.GetBytes(UNIT_DESCRIPTOR_VALUE),
            UUID = UNIT_DESCRIPTOR_UUID,
            Flags = new[] { "read" }
        };
    }
}
