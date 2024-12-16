using EvtTool.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    public sealed class GPoeCommandData : CommandData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public poemType PoemType { get; set; }
        public int PoemMajorId { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            // gameover is the only one actually used lol
            PoemType = (poemType)reader.ReadInt32();
            PoemMajorId = reader.ReadInt32();

            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( (int)PoemType );
            writer.Write( PoemMajorId );
            writer.Write( Static0C );
        }

        public enum poemType : int
        {
            rankup,
            max,
            gameover
        }
    }
}
