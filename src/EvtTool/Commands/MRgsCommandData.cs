using EvtTool.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace EvtTool
{
    public class MRgsCommandData : CommandData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public RegisterStatus Action { get; set; }
        public int Scene { get; set; } = 0;
        public int Static00 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            Action = (RegisterStatus)reader.ReadInt32();
            Scene = reader.ReadInt32();

            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( (int)Action );
            writer.Write( Scene );
            writer.Write( Static0C );
        }

        public enum RegisterStatus
        {
            Unknown = 0,
            Spawn = 1,
            Despawn = 2
        }
    }
}