using System.ComponentModel;
using System.Numerics;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class CmdCommandData : CommandData
    {
        public Vector3[] Movements {  get; set; } 
        public int Field00 { get; set; }
        public float Field04 { get; set; }
        public float Field08 { get; set; }
        public float Field0C { get; set; }
        public float Field10 { get; set; }
        public float Field14 { get; set; }
        public float Field18 { get; set; }
        public float Field1C { get; set; }
        public int Field20 { get; set; }
        public float Field24 { get; set; }
        public float Field28 { get; set; }
        public float Field2C { get; set; }
        public float Field30 { get; set; }
        public int Field34 { get; set; }
        public int Static38 { get; set; } = 0;
        public int Static3C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 15 or 31
            Field00 = reader.ReadInt32();
            // these seem to be movement values
            // Field20 (entry 4 single 3) was originally an int32. not sure if this was a typo or not
            Movements = reader.ReadVector3s(4);

            // 0-4
            Field34 = reader.ReadInt32();

            Static38 = reader.ReadInt32();
            Static3C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Field24 );
            writer.Write( Field28 );
            writer.Write( Field2C );
            writer.Write( Field30 );
            writer.Write( Field34 );
            writer.Write( Static38 );
            writer.Write( Static3C );
        }
    }
}
