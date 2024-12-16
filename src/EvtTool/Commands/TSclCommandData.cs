using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    public sealed class TSclCommandData : CommandData
    {
        public Vector2 Scale { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static04 { get; set; } = 4354;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            Static04 = reader.ReadInt32();

            Scale = reader.ReadVector2();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Static04 );
            writer.Write( Scale );
        }
    }
}
