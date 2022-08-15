using System.Text.Json.Serialization;

namespace Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
   
    // Units of measure Enums
    public enum UOM
    {
        piece = 0,
        kilogram = 1,
        gram = 2,
        liter = 3,
        milliliter = 4,
        teaspoon = 5,
        tablespoon = 6
    }
}