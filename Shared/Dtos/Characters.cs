using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dotnet_CRUD.Shared.Dtos
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3
    }

    public class CharacterDTO
    {
        [JsonPropertyName("charterID")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("charterName")]
        public string Name { get; set; } = null!;

        public int HitPoints { get; set; }
        public RpgClass Class { get; set; }
    }


    public class AddCharacterDto
    {
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }

    public class UpdateCharacterDto
    {
        [JsonPropertyName("charterID")]
        public string Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public RpgClass Class { get; set; } = RpgClass.Knight;
    }
}