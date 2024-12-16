using System.ComponentModel;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class CQukCommandData : CommandData
    {
        public float QuakeIntensity { get; set; }
        public float QuakeAngle { get; set; }
        public int EaseDuration { get; set; }
        public int Unused00 { get; set; } = 0;
        public int Unused10 { get; set; } = 0;
        public int Unused14 { get; set; } = 0;
        public int Unused18 { get; set; } = 0;
        public int Unused1C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Unused00 = reader.ReadInt32();
            
            QuakeIntensity = reader.ReadSingle();
            QuakeAngle = reader.ReadSingle();
            EaseDuration = reader.ReadInt32();

            // Unused10 has unique values when used in EVTs, but I guess the value isn't read?
            Unused10 = reader.ReadInt32();
            Unused14 = reader.ReadInt32();
            Unused18 = reader.ReadInt32();
            Unused1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Unused00 );
            writer.Write( QuakeIntensity );
            writer.Write( QuakeAngle );
            writer.Write( EaseDuration );
            writer.Write( Unused10 );
            writer.Write( Unused14 );
            writer.Write( Unused18 );
            writer.Write( Unused1C );
        }
    }
}
