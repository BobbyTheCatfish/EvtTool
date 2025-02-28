using EvtTool.IO;

namespace EvtTool
{
    public class FodCommandData : CommandData
    {
        public bool Display { get; set; }
        public int ObjectID { get; set; }
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Display = reader.ReadInt32() == 1; // double check name
            ObjectID = reader.ReadInt32(); // double check

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Display == true ? 1 : 0 );
            writer.Write( ObjectID );
            writer.Write( Static08 );
            writer.Write( Static0C );
        }
    }
}