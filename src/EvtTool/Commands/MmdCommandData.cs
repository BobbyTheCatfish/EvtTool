using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    internal class MmdCommandData : CommandData
    {
        public Vector3[] Positions { get; set; } = new Vector3[24];
        public bool Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field128 { get; set; }
        public float Field12C { get; set; }
        public int Field130 { get; set; }
        public int Field134 { get; set; }
        public int Field138 { get; set; }
        public int Field13C { get; set; }
        public bool Field140 { get; set; }
        public float Field144 { get; set; }
        public int Field148 { get; set; }
        public int Static14C { get; set; } = 0;
        public int Static150 { get; set; } = 0;
        public int Static154 { get; set; } = 0;
        public int Field158 { get; set; }
        public int Field15C { get; set; }
        public bool Field160 { get; set; }
        public float Field164 { get; set; }
        public int Field168 { get; set; }
        public int Static16C { get; set; } = 0;
        public int Static170 { get; set; } = 0;
        public int Static174 { get; set; } = 0;
        public int Static178 { get; set; } = 0;
        public int Static17C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32() == 1;
            // 1-6
            Field04 = reader.ReadInt32();
            for ( int i = 0; i < Positions.Length; i++ )
                Positions[ i ] = reader.ReadVector3();
            // 0-80ish
            Field128 = reader.ReadInt32();
            // 0-10
            Field12C = reader.ReadSingle();
            
            Field130 = reader.ReadInt32();
            Field134 = reader.ReadInt32();
            Field138 = reader.ReadInt32();
            Field13C = reader.ReadInt32();
            Field140 = reader.ReadInt32() == 1;
            // 0-3
            Field144 = reader.ReadSingle();

            Field148 = reader.ReadInt32();

            Static14C = reader.ReadInt32();
            Static150 = reader.ReadInt32();
            Static154 = reader.ReadInt32();
            
            Field158 = reader.ReadInt32();
            Field15C = reader.ReadInt32();
            Field160 = reader.ReadInt32() == 1;
            // 0-10
            Field164 = reader.ReadSingle();

            Field168 = reader.ReadInt32();

            Static16C = reader.ReadInt32();
            Static170 = reader.ReadInt32();
            Static174 = reader.ReadInt32();
            Static178 = reader.ReadInt32();
            Static17C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 == true ? 1 : 0 );
            writer.Write( Field04 );
            writer.Write( Positions );
            writer.Write( Field128 );
            writer.Write( Field12C );
            writer.Write( Field130 );
            writer.Write( Field134 );
            writer.Write( Field138 );
            writer.Write( Field13C );
            writer.Write( Field140 == true ? 1 : 0 );
            writer.Write( Field144 );
            writer.Write( Field148 );
            writer.Write( Static14C );
            writer.Write( Static150 );
            writer.Write( Static154 );
            writer.Write( Field158 );
            writer.Write( Field15C );
            writer.Write( Field160 == true ? 1 : 0 );
            writer.Write( Field164 );
            writer.Write( Field168 );
            writer.Write( Static16C );
            writer.Write( Static170 );
            writer.Write( Static174 );
            writer.Write( Static178 );
            writer.Write( Static17C );
        }
}
}