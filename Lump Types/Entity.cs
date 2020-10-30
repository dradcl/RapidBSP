using RapidBSP.Lumps;

namespace RapidBSP.Lump_Types
{
    public sealed class Entity : Lump
    {
        public Entity(int offset, int length, int ver, char[] ilump) : base(offset, length, ver, ilump) { }
    }
}