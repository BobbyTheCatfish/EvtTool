using EvtTool.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class SndCommandData : CommandData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SndMan SoundType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SndAction Action { get; set; }
        public SndChannel Channel { get; set; }
        public int CueId { get; set; }
        public int FadeoutDuration { get; set; }
        public int Unused00 { get; set; }
        public int Unused14 { get; set; }
        public int Unused1C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Unused00 = reader.ReadInt32();
            SoundType = (SndMan)reader.ReadInt32();
            Action = (SndAction)reader.ReadInt32();
            Channel = (SndChannel)reader.ReadInt32();
            CueId = reader.ReadInt32();
            Unused14 = reader.ReadInt32();
            FadeoutDuration = reader.ReadInt32();
            Unused1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Unused00 );
            writer.Write( (int)SoundType);
            writer.Write( (int)Action );
            writer.Write( (int)Channel );
            writer.Write( CueId );
            writer.Write( Unused14 );
            writer.Write( FadeoutDuration );
            writer.Write( Unused1C );
        }

        public enum SndMan
        {
            Skip = 0,
            Bgm = 1,
            System = 2,
            Event = 3
        }

        public enum SndAction
        {
            Skip = 0,
            Play = 1,
            Stop = 2,
        }
        // not tested, just possible values.
        public enum SndChannel
        {
            Mono = 0,
            Stereo = 1,
            Left = 2,
            Right = 3,
        }
    }
}
