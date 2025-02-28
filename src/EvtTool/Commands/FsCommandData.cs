using System.Diagnostics;
using System.Linq;
using EvtTool.IO;

namespace EvtTool
{
    internal class FsCommandData : CommandData
    {
        public bool Field04 { get; set; }
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public float Field18 { get; set; }
        public int Field1C { get; set; }
        public int Field20 { get; set; }
        public int Field24 { get; set; }
        public int Field28 { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;
        public int Static2C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            Field04 = reader.ReadInt32() == 1;

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadInt32();
            Field18 = reader.ReadSingle();
            Field1C = reader.ReadInt32();
            Field20 = reader.ReadInt32();
            Field24 = reader.ReadInt32();
            Field28 = reader.ReadInt32();

            Static2C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Field04 == true ? 1 : 0);
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Field24 );
            writer.Write( Field28 );
            writer.Write( Static2C );
        }
    }
}