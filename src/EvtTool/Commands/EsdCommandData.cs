using System.ComponentModel;
using System.Numerics;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EsdCommandData : CommandData
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static1C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            
            // these might be mixed up, no firm way to tell but this seems logical in my mind for position to go first for some reason
            Position = reader.ReadVector3();
            Rotation = reader.ReadVector3();

            Static1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Position );
            writer.Write( Rotation );
            writer.Write( Static1C );
        }
    }
}
