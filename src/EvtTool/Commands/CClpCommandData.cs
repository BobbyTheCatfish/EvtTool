using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class CClpCommandData : CommandData
    {
        public float NearClip { get; set; }
        public float FarClip { get; set; }
        public int Unused00 { get; set; } = 0;
        public int Unused04 { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Unused00 = reader.ReadInt32();
            Unused04 = reader.ReadInt32();
            NearClip = reader.ReadSingle();
            FarClip = reader.ReadSingle();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Unused00 );
            writer.Write( Unused04 );
            writer.Write( NearClip );
            writer.Write( FarClip );
        }
    }
}
