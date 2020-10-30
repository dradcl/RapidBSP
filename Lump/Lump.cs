namespace RapidBSP.Lumps
{
    // Subsections of the file that store different parts of the map data
    public class Lump
    {
        public int fileofs;                    // offset into file (bytes)
        public int filelen;                    // length of lump (bytes)
        public int version;                    // lump format version
        public char[] fourCC = new char[4];	   // lump ident code

        public Lump() { }
        public Lump(int offset, int length, int ver, char[] ilump)
        {
            fileofs = offset;
            filelen = length;
            version = ver;
            fourCC = ilump;
        }
    }

    // 2004 = HL2
    // 2007 = TF2, EP2, PRTL
    // 2009 = L4D2
    // 2006 = EP1
    // 2008 = L4D
    public enum LumpTypeIndex2004
    {
        LUMP_ENTITIES,
        LUMP_PLANES,
        LUMP_TEXDATA,
        LUMP_VERTEXES,
        LUMP_VISIBILITY,
        LUMP_NODES,
        LUMP_TEXINFO,
        LUMP_FACES,
        LUMP_LIGHTING,
        LUMP_OCCLUSION,
        LUMP_LEAFS,
        LUMP_EDGES = 12,
        LUMP_SURFEDGES,
        LUMP_MODELS,
        LUMP_WORLDLIGHTS,
        LUMP_LEAFFACES,
        LUMP_LEAFBRUSHES,
        LUMP_BRUSHES,
        LUMP_BRUSHSIDES,
        LUMP_AREAS,
        LUMP_AREAPORTALS,
        LUMP_PORTALS,
        LUMP_CLUSTERS,
        LUMP_PORTALVERTS,
        LUMP_CLUSTERPORTALS,
        LUMP_DISPINFO,
        LUMP_ORIGINALFACES,
        LUMP_PHYSCOLLIDE = 29,
        LUMP_VERTNORMALS,
        LUMP_VERTNORMALINDICES,
        LUMP_DISP_LIGHTMAP_ALPHAS,
        LUMP_DISP_VERTS,
        LUMP_DISP_LIGHTMAP_SAMPLE_POSITIONS,
        LUMP_GAME_LUMP,
        LUMP_LEAFWATERDATA,
        LUMP_PRIMITIVES,
        LUMP_PRIMVERTS,
        LUMP_PRIMINDICES,
        LUMP_PAKFILE,
        LUMP_CLIPPORTALVERTS,
        LUMP_CUBEMAPS,
        LUMP_TEXDATA_STRING_DATA,
        LUMP_TEXDATA_STRING_TABLE,
        LUMP_OVERLAYS,
        LUMP_LEAFMINDISTTOWATER,
        LUMP_FACE_MACRO_TEXTURE_INFO,
        LUMP_DISP_TRIS,
        LUMP_PHYSCOLLIDESURFACE
    }
    public enum LumpTypeIndex2006
    {
        LUMP_WATEROVERLAYS = 50,
        LUMP_LIGHTMAPPAGES,
        LUMP_LIGHTMAPPAGEINFOS,
        LUMP_LIGHTING_HDR,
        LUMP_WORLDLIGHTS_HDR,
        LUMP_LEAF_AMBIENT_LIGHTING_HDR,
        LUMP_LEAF_AMBIENT_LIGHTING,
        LUMP_XZIPPAKFILE,
        LUMP_FACES_HDR,
        LUMP_MAP_FLAGS
    }
    public enum LumpTypeIndex2007
    {
        LUMP_FACEIDS = 11,
        LUMP_UNUSED0 = 22,
        LUMP_UNUSED1,
        LUMP_UNUSED2,
        LUMP_UNUSED3,
        LUMP_PHYSDISP = 28,
        LUMP_LEAF_AMBIENT_INDEX_HDR = 51,
        LUMP_LEAF_AMBIENT_INDEX,
        LUMP_OVERLAY_FADES = 60
    }
    public enum LumpTypeIndex2008
    {
        LUMP_OVERLAY_SYSTEM_LEVELS = 61
    }
    public enum LumpTypeIndex2009
    {
        LUMP_PROPCOLLISION = 22,
        LUMP_PROPHULLS,
        LUMP_PROPHULLVERTS,
        LUMP_PROPTRIS,
        LUMP_PROP_BLOB = 49,
        LUMP_PHYSLEVEL = 62
    }
}