using EvtTool.IO;

namespace EvtTool
{
    public sealed class SFltCommandData : CommandData
    {
        public bool Field00 { get; set; }
        public int Field04 { get; set; }
        public float Field08 { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32() == 1;
            // 0-5 (mode?)
            Field04 = reader.ReadInt32();
            // 0-1 (strength?)
            Field08 = reader.ReadSingle();
            // small
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 == true ? 1 : 0 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
        }
    }
}
