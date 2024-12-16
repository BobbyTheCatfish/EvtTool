using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    public sealed class MLwCommandData : CommandData
    {
        public Vector2 Direction1 { get; set; }
        public Vector2 Direction2 { get; set; }
        public int Delay1 { get; set; }
        public int Delay2 { get; set; }
        public bool Field00 { get; set; }
        public int Static1C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32() == 1;
            // i'd assume these would be xy rotation pairs
            Direction1 = reader.ReadVector2();
            Direction2 = reader.ReadVector2();
            // time until next look
            Delay1 = reader.ReadInt32();
            Delay2 = reader.ReadInt32();

            Static1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Direction1 );
            writer.Write( Direction2 );
            writer.Write( Delay1 );
            writer.Write( Delay2 );
            writer.Write( Static1C );
        }
    }
}
