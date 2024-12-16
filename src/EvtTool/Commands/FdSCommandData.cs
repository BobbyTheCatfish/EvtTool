using EvtTool.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    public class FdSCommandData : CommandData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public FadeType FadeType { get; set; }
        public bool Field00 { get; set; }
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32() == 1;
            FadeType = ( FadeType ) reader.ReadInt32();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 == true ? 1 : 0 );
            writer.Write( (int)FadeType );
            writer.Write( Static08 );
            writer.Write( Static0C );
        }
    }

    public enum FadeType
    {
        None,
        BlackIn,
        BlackOut,
        WhiteIn,
        WhiteOut
    }
}