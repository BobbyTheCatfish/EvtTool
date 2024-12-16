using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class CaaCommandData : CommandData
    {
        public bool Field00 { get; set; }
        public int Field04 { get; set; }
        public bool Field08 { get; set; }
        public float Static0C { get; set; } = 1;
        public int Unused10 { get; set; } = 0;
        public int Unused14 { get; set; } = 0;
        public int Unused18 { get; set; } = 0;
        public int Unused1C { get; set; } = 0;
        public int Unused20 { get; set; } = 0;
        public int Unused24 { get; set; } = 0;
        public int Unused28 { get; set; } = 0;
        public int Unused2C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32() == 1;
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32() == 1;
            // buncha useless values
            Static0C = reader.ReadSingle();
            Unused10 = reader.ReadInt32();
            Unused14 = reader.ReadInt32();
            Unused18 = reader.ReadInt32();
            Unused1C = reader.ReadInt32();
            Unused20 = reader.ReadInt32();
            Unused24 = reader.ReadInt32();
            Unused28 = reader.ReadInt32();
            Unused2C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 == true ? 1 : 0 );
            writer.Write( Field04 );
            writer.Write( Field08 == true ? 1 : 0 );
            writer.Write( Static0C );
            writer.Write( Unused10 );
            writer.Write( Unused14 );
            writer.Write( Unused18 );
            writer.Write( Unused1C );
            writer.Write( Unused20 );
            writer.Write( Unused24 );
            writer.Write( Unused28 );
            writer.Write( Unused2C );
        }
    }
}
