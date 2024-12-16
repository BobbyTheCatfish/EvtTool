using EvtTool.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    public sealed class MIcCommandData : CommandData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public IconEnum Icon { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public IconSizeEnum IconSize { get; set; }
        public int Static00 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Static00 = reader.ReadInt32();

            Icon = (IconEnum)reader.ReadInt32();
            IconSize = (IconSizeEnum)reader.ReadInt32();

            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Static00 );
            writer.Write( (int)Icon );
            writer.Write( (int)IconSize );
            writer.Write( Static0C );
        }

        public enum IconEnum
        {
            Single_Exclamation = 1,
            Double_Exclamation = 2,
            Question_Mark = 3,
            Exclamation_and_Question_Mark = 4,
            Anger = 9,
            Anger2 = 10,
            Talking = 11,
            Talking_x2 = 12,
            Sleeping = 14,
            Phone_Ringing = 15,
            Sweat = 16,
            Panic = 17,
            Vert_Meow = 22,
            Horiz_Meow_R = 23,
            Horiz_Meow_L = 24,
            SS_Sparkle = 25,
            Sweat_Blue = 26,
        }

        public enum IconSizeEnum
        {
            Normal = 0,
            Small = 1,
            Medium = 2,
            Large = 3
        }
    }
}
