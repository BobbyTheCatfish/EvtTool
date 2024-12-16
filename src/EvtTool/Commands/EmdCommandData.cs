using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;
using System.Numerics;

namespace EvtTool
{
    public sealed class EmdCommandData : CommandData
    {
        public Vector3[] Positions { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static04 { get; set; } = 4;
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;
        public int Static10 { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {

            Static00 = reader.ReadInt32();
            Static04 = reader.ReadInt32();

            Positions = reader.ReadVector3s(25);

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
            Static10 = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( Static04 );
            for (int i = 0; i < 25; i++)
            {
                writer.Write( Positions[i] );
            }
            writer.Write( Static08 );
            writer.Write( Static0C );
            writer.Write( Static10 );
        }
    }
}
