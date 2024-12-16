using EvtTool.IO;

namespace EvtTool
{
    public sealed class MFtsCommandData : CommandData
    {
        public FootstepDistortion FootstepDistortionBitfield { get; set; }
        public float FootstepDistortionStrength { get; set; }
        public int Static08 { get; set; } = 0;
        public int Static0C { get; set; } = 0;

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            FootstepDistortionBitfield = new FootstepDistortion
            {
                data = reader.ReadInt32()
            };
            FootstepDistortionStrength = reader.ReadSingle();

            Static08 = reader.ReadInt32();
            Static0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( FootstepDistortionBitfield.data );
            writer.Write( FootstepDistortionStrength );
            writer.Write( Static08 );
            writer.Write( Static0C );
        }

        public class FootstepDistortion
        {
            internal int data { get;  set; }

            public bool dummyBit
            {
                get { return (data & 1) == 1; }
                set { data += (value ? 1 : 0); }
            }

            public bool AreaDistortion
            {
                get { return (data & 2) == 2; }
                set { data += (value ? 1 : 0) << 1; }
            }

            public bool PuddleEffect
            {
                get { return (data & 4) == 4; }
                set { data += (value ? 1 : 0) << 2; }
            }
        }
    }
}
