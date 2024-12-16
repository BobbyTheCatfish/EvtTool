using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    public sealed class CmCnCommandData : CommandData
    {
        public int Unused00 { get; set; } = 0;
        [JsonConverter(typeof(StringEnumConverter))]
        public DirectionEnum Direction { get; set; }
        public float Distance { get; set; }
        public int Unused0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Unused00 = reader.ReadInt32();
            Direction = (DirectionEnum)reader.ReadInt32();
            Distance = reader.ReadSingle();
            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Unused00 );
            writer.Write( (int)Direction );
            writer.Write( Distance );
            writer.Write( Unused0C );
        }

        public enum DirectionEnum
        {
            Other = 0,
            Forward = 1,
            Backward = 2,
            Left = 3,
            Right = 4,
            Up = 5,
            Down = 6
        }
    }
}
