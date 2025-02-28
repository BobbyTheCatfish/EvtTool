using System;

namespace EvtTool.IO
{
    public static class Utils
    {
        public static byte[] ToBytes(string input) {
            if (input.StartsWith("#"))
            {
                input = input.Substring(1);
            }
            byte r = Convert.ToByte(input.Substring(0, 2), 16);
            byte g = Convert.ToByte(input.Substring(0, 2), 16);
            byte b = Convert.ToByte(input.Substring(0, 2), 16);
            byte a = Convert.ToByte(input.Substring(0, 2), 16);
            return new byte[] { r, g, b, a };
        }
        public static string ToHexString(byte[] B)
        {
            return $"#{B[0]:X2}{B[1]:X2}{B[2]:X2}{B[3]:X2}";
        }
    }
    public class Animation
    {
        public int ID { get; set; }
        public int InterpolatedFrames { get; set; }
        public bool Loop { get; set; }
        public float Speed { get; set; }
        public int StartingFrame { get; set; }
        public int EndingFrame { get; set; }
        public int Static1 { get; set; }
        public int Static2 { get; set; }
    }
}
