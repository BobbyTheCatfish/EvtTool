using System.ComponentModel;
using System.Numerics;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class EnFhCommandData : CommandData
    {
        public int Static00 { get; set; } = 1;
        public int Static04 { get; set; } = 4354;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;
        public Vector3 Field10 { get; set; }
        public int Static1C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();
            Static04 = reader.ReadInt32();
            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            // might be a vector? if not it's 3 singles.
            Field10 = reader.ReadVector3();
            Static1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Static04 );
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.Write( Field10 );
            writer.Write( Static1C );
        }
    }
}
