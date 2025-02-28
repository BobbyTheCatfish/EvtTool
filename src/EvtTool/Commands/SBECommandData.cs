using EvtTool.IO;

namespace EvtTool
{
    public sealed class SBECommandData : CommandData
    {
        public bool Enable { get; set; }
        public int SomeENum { get; set; }
        public int CueID { get; set; }
        public int Unused0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Enable = reader.ReadInt32() == 1;
            SomeENum = reader.ReadInt32();
            CueID = reader.ReadInt32();
            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Enable == true ? 1 : 0 );
            writer.Write( SomeENum );
            writer.Write( CueID );
            writer.Write( Unused0C );
        }
    }
}
