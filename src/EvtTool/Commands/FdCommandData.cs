using EvtTool.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.ComponentModel;

namespace EvtTool
{
    public class FdCommandData : CommandData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public fadeMode FadeMode { get; set; }
        public byte FadeType { get; set; }
        public bool Field00 { get; set; }
        public short Static06 { get; set; } = 0;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {

            Field00 = reader.ReadInt32() == 1;
            FadeMode = (fadeMode)reader.ReadByte();
            FadeType = reader.ReadByte();

            Static06 = reader.ReadInt16();
            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 == true ? 1 : 0 );
            writer.Write( (byte)FadeMode );
            writer.Write( FadeType );
            writer.Write( Static06 );
            writer.Write( Static08 );
            writer.Write( Static0C );
        }

        public enum fadeMode
        {
            Other = 0,
            FadeOut = 1,
            FadeIn = 2
        }

    }
}