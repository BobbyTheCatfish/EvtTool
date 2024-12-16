using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EshCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Static04 { get; set; } = 0;
        public int Static08 { get; set; } = 4354;
        public int Static0C { get; set; } = 4354;
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public int Static18 { get; set; } = 0;
        public int Static1C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            
            Static04 = reader.ReadInt32();
            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadInt32();

            Static18 = reader.ReadInt32();
            Static1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Static04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Static18 );
            writer.Write( Static1C );
        }
    }
}
