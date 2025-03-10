﻿using System;
using System.Collections;
using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    public class CsdCommandData : CommandData
    {
        public int SomeCameraBitfield { get; set; }
        public BitArray Bitfield { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; } // in degrees
        public float Fov { get; set; }
        public float Field20 { get; set; }
        public float Field24 { get; set; }
        public float Field28 { get; set; }
        public float Field2C { get; set; }
        public int Field30 { get; set; }
        public int Field34 { get; set; }
        public float Field38 { get; set; }
        public float Field3C { get; set; }
        public int Field40 { get; set; }
        public int Field44 { get; set; }
        public int Field48 { get; set; }
        public int Field4C { get; set; }

        internal override void Read(Command command, EndianBinaryReader reader)
        {
            SomeCameraBitfield = reader.ReadInt32();
            Bitfield = new BitArray(BitConverter.GetBytes(SomeCameraBitfield));
            Position = reader.ReadVector3();
            Rotation = reader.ReadVector3();
            Fov = reader.ReadSingle();

            Field20 = reader.ReadSingle();
            Field24 = reader.ReadSingle();
            Field28 = reader.ReadSingle();
            Field2C = reader.ReadSingle();
            // 0-5
            Field30 = reader.ReadInt32();
            // pos or neg ints that are very high or very low
            Field34 = reader.ReadInt32();
            Field38 = reader.ReadSingle();
            Field3C = reader.ReadSingle();
            Field40 = reader.ReadInt32();
            Field44 = reader.ReadInt32();
            Field48 = reader.ReadInt32();
            Field4C = reader.ReadInt32();
        }

        internal override void Write(Command command, EndianBinaryWriter writer)
        {
            writer.Write(SomeCameraBitfield);
            writer.Write(Position);
            writer.Write(Rotation);
            writer.Write(Fov);
            writer.Write(Field20);
            writer.Write(Field24);
            writer.Write(Field28);
            writer.Write(Field2C);
            writer.Write(Field30);
            writer.Write(Field34);
            writer.Write(Field38);
            writer.Write(Field3C);
            writer.Write(Field40);
            writer.Write(Field44);
            writer.Write(Field48);
            writer.Write(Field4C);
        }
    }
}