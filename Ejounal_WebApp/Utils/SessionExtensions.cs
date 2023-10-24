namespace Ejounal_WebApp.Utils;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
        };

        var serializedValue = JsonSerializer.Serialize(value, options);
        session.SetString(key, serializedValue);
    }

    public static T? Get<T>(this ISession session, string key)
    {
        var serializedValue = session.GetString(key);
        if (serializedValue == null)
        {
            return default;
        }

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
        };

        return JsonSerializer.Deserialize<T>(serializedValue, options);
    }

}
