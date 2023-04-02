using Linux.Bluetooth;
using System.Linq;
using static System.Console;

var adapters = await BlueZManager.GetAdaptersAsync();
var adapter = adapters.FirstOrDefault();
if (adapter == null) {
    throw new InvalidOperationException("NO BLE Adapters found!");
}


var adapterProps = await adapter.GetPropertiesAsync();

WriteLine($"== Controller: {adapterProps.Address}");
WriteLine($"== Name: {adapterProps.Name}");
WriteLine($"== Alias: {adapterProps.Alias}");
WriteLine($"== Powered: {adapterProps.Powered}");
WriteLine($"== Discoverable: {adapterProps.Discoverable}");
WriteLine($"== Pairable: {adapterProps.Pairable}");
WriteLine($"== Discovering: {adapterProps.Discovering}");
WriteLine($"== UUIDs:\n\t{string.Join("\n\t", adapterProps.UUIDs)}");

