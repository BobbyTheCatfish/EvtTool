using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    /// <summary>
    /// Model Look At. Makes a model object look at a target.
    /// </summary>
    public class MLaCommandData : CommandData
    {
        public Vector3 Position { get; set; }
        public int Flags { get; set; }
        public short MotionType { get; set; }
        public short SpeedType { get; set; }
        public short TargetType { get; set; }
        public int TargetModelId { get; set; }
        public int TargetHelperID { get; set; }
        public short Unused08 { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Flags = reader.ReadInt32();
            MotionType = reader.ReadInt16();
            SpeedType = reader.ReadInt16();

            Unused08 = reader.ReadInt16();

            TargetType = reader.ReadInt16();
            Position = reader.ReadVector3();
            TargetModelId = reader.ReadInt32();
            TargetHelperID = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Flags );
            writer.Write( MotionType );
            writer.Write( SpeedType );
            writer.Write( Unused08 );
            writer.Write( TargetType );
            writer.Write( Position );
            writer.Write( TargetModelId );
            writer.Write( TargetHelperID );
        }
    }

    public enum LookAtInterpolationMode
    {
        None,
        Smooth1,
        Smooth2,
        Smooth3
    }
}