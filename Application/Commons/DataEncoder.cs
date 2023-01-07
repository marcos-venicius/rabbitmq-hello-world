using System.Text;
using Newtonsoft.Json;

namespace Commons;

public static class DataEncoder
{
    public static byte[] Encode(Data data)
    {
        var serialized = JsonConvert.SerializeObject(data);

        if (serialized is null)
            throw new ArgumentNullException(nameof(serialized), message: "cannot convert data object");

        return Encoding.UTF8.GetBytes(serialized);
    }

    public static Data Decode(byte[] bytes)
    {
        var serialized = Encoding.UTF8.GetString(bytes);

        if (serialized is null)
            throw new ArgumentNullException(nameof(serialized), message: "cannot get string from bytes");

        var data  = JsonConvert.DeserializeObject<Data>(serialized);

        if (data is null)
            throw new ArgumentNullException(nameof(data), "cannot deserialize object");

        return data;
    }
}