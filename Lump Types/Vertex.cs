//  Lump 3
//  The vertex lump is an array of coordinates of all the vertices (corners) of brushes in the map geometry

using RapidBSP.Lumps;
using System;

namespace RapidBSP.Lump_Types
{
    public sealed class Vertex : Lump
    {
        private Vector[] vertices;                             // array of all verticies in a map
        public const UInt16 MAX_MAP_VERTS = UInt16.MaxValue;   // max amount of vertices in a map

        public Vertex()
        {
            vertices = new Vector[MAX_MAP_VERTS];
        }

        public void AddVertexChunk()
        {

        }
    }
}