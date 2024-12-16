using EvtTool.IO;

namespace EvtTool
{
    internal class MabCommandData : CommandData
    {
        public int AnimationID { get; set; }
        public bool Loop { get; set; }
        public float AnimationSpeed { get; set; }
        public int Field04 { get; set; }
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public bool Field18 { get; set; }
        public float Field1C { get; set; }
        public byte Field20 { get; set; }
        public byte Field21 { get; set; }
        public short Field22 { get; set; }
        public int Field24 { get; set; }
        public int Field28 { get; set; }
        public int Field2C { get; set; }
        public int Field30 { get; set; }
        public int Field34 { get; set; }
        public int Static38 { get; set; } = 0;
        public int Static3C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            AnimationID = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Loop = reader.ReadInt32() == 1;
            AnimationSpeed = reader.ReadSingle();
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadInt32();
            Field18 = reader.ReadInt32() == 1;
            Field1C = reader.ReadSingle();
            Field20 = reader.ReadByte();
            Field21 = reader.ReadByte();
            Field22 = reader.ReadInt16();
            Field24 = reader.ReadInt32();
            Field28 = reader.ReadInt32();
            Field2C = reader.ReadInt32();
            Field30 = reader.ReadInt32();
            Field34 = reader.ReadInt32();

            Static38 = reader.ReadInt32();
            Static3C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write(AnimationID);
            writer.Write( Field04 );
            writer.Write( Loop == true ? 1 : 0 );
            writer.Write(AnimationSpeed);
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 == true ? 1 : 0 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Field21 );
            writer.Write( Field22 );
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