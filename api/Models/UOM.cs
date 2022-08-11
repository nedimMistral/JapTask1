using System.Text.Json.Serialization;

namespace Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
   
    // Units of measure Enums
    public enum UOM
    {
        piece,
        kilogram,
        gram,
        liter,
        milliliter,
        teaspoon,
        tablespoon
    }
}