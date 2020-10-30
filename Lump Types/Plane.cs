//  Lump 1
//  The basis of the BSP geometry is defined by planes, which are used as splitting surfaces across the BSP tree structure.

using RapidBSP.Lumps;
using System;

namespace RapidBSP.Lump_Types
{
    public class Plane : Lump
    {
        private Vector _normal;  // normal vector
        private float _dist;     // distance from origin
        private int _type;	     // plane axis identifier

        public const UInt16 MAX_MAP_PLANES = UInt16.MaxValue;   // max amount of planes a map can contain

        public Plane(Vector normal, float dist, int type, int offset, int length, int ver, char[] ilump) : base(offset, length, ver, ilump)
        {
            _normal = normal;
            _dist = dist;
            _type = type;
        }
        public int NumberOfPlanes()
        {
            return filelen / 20;
        }
        public bool IsValidPlane()
        {
            return false;
        }
    }
}