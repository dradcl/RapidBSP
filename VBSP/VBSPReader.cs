using RapidBSP.Lumps;

namespace RapidBSP.VBSP
{
    public sealed class VBSPReader
    {
        public const string VBSPMAGICNUM = "0x50534256";
        public static string ReadBytesUntil(byte[] bytes, int startIndex)
        {
            string result = "";

            while(startIndex >= 0)
            {
                result += bytes[startIndex].ToString("X");
                startIndex--;
            }

            return "0x" + result;
        }
        public static Lump[] IndexLumps(byte[] bytes, int lumpArrayOffset)
        {
            return new Lump[3];
        } // cut the 1024 bytes into 64, 16 byte chunks and cast them to a Lump class
        public static int GetEngineYear(VBSPFile BSPfile)
        {
            return 2004;
        }
        public static LumpTypeIndex2004 DetermineLumpType2004()
        {
            return LumpTypeIndex2004.LUMP_CLUSTERS;
        }
    }
}