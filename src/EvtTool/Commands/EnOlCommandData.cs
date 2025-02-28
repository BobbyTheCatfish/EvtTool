using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EnOlCommandData : CommandData
    {
        public float Field08 { get; set; }
        public float Field0C { get; set; }
        public float Field10 { get; set; }
        public float Field14 { get; set; }
        public float Field18 { get; set; }
        public int Field1C { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static04 { get; set; } = 4354;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            Static04 = reader.ReadInt32();

            // ngl chief idk about these values
            Field08 = reader.ReadSingle();
            Field0C = reader.ReadSingle();
            Field10 = reader.ReadSingle();
            Field14 = reader.ReadSingle();
            Field18 = reader.ReadSingle();
            // usually a float in the hundreds... even though it's an int? idk man i just work here
            Field1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Static04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
        }
    }
}
