using EvtTool.IO;

namespace EvtTool
{
    internal class MAtCommandData : CommandData
    {
        public int AttachFrame { get; set; }
        public int AttachObjectId { get; set; }
        public int HelperBoneId { get; set; }
        public int Static0C { get; set; } = 0;
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public int Field18 { get; set; }
        public int Field1C { get; set; }
        public int Field20 { get; set; }
        public int Field24 { get; set; }
        public int Static28 { get; set; } = 0;
        public int Static2C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            // 0 or 16
            AttachFrame = reader.ReadInt32();
            HelperBoneId = reader.ReadInt32();
            AttachObjectId = reader.ReadInt32();

            Static0C = reader.ReadInt32();

            // pos or neg, very large values. maybe these are supposed to be pos and rot vectors?
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadInt32();
            Field18 = reader.ReadInt32();

            Field1C = reader.ReadInt32();
            Field20 = reader.ReadInt32();
            Field24 = reader.ReadInt32();

            Static28 = reader.ReadInt32();
            Static2C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( AttachFrame );
            writer.Write( HelperBoneId );
            writer.Write( AttachObjectId );
            writer.Write( Static0C );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Field24 );
            writer.Write( Static28 );
            writer.Write( Static2C );
        }
    }
}