//
//  Valve Binary Space Partitioning File
//  https://developer.valvesoftware.com/wiki/Source_BSP_File_Format#Plane

using RapidBSP.Lump_Types;
using RapidBSP.Lumps;
using RapidBSP.VBSP;
using System;
using System.IO;
using System.Windows;

namespace RapidBSP
{
    public sealed class VBSPFile
    {
        private string ident;                  //  BSP file identifier (0x50534256 little-endian "VBSP")
        private int version;                   //  BSP file version
        public Lump[] lumps = new Lump[64];    //  Lump directory array
        private int mapRevision;               //  the map's revision number

        public byte[] fileContents;                        //  All bytes of the file
        public byte[] fileLumpContents = new byte[1024];   //  All bytes of the lump directory array

        public VBSPFile(string fileDirectory)
        {
            fileContents = GetFileContents(fileDirectory);
            version = fileContents[4];
            ident = VBSPReader.ReadBytesUntil(fileContents, 3);

            InitializeLumpDirectory();
        }
        public void InitializeLumpDirectory()
        {
            Array.Copy(fileContents, 8, fileLumpContents, 0, 1023);
            InitializeLumps();
        }
        public void InitializeLumps()
        {
            uint fileLumpIndex = 0, lumpIndex = 0;
            char[] lumpIdent;

            while (fileLumpIndex < 1024 || lumpIndex < 64)
            {
                int lumpOffset = BitConverter.ToInt32(new byte[] { fileLumpContents[fileLumpIndex], fileLumpContents[fileLumpIndex + 1], fileLumpContents[fileLumpIndex + 2], fileLumpContents[fileLumpIndex + 3] }, 0);
                int lumpLength = BitConverter.ToInt32(new byte[] { fileLumpContents[fileLumpIndex + 4], fileLumpContents[fileLumpIndex + 5], fileLumpContents[fileLumpIndex + 6], fileLumpContents[fileLumpIndex + 7] }, 0);
                int lumpVersion = BitConverter.ToInt32(new byte[] { fileLumpContents[fileLumpIndex + 8], fileLumpContents[fileLumpIndex + 9], fileLumpContents[fileLumpIndex + 10], fileLumpContents[fileLumpIndex + 11] }, 0);
                lumpIdent = new char[] { (char)fileLumpContents[fileLumpIndex + 12], (char)fileLumpContents[fileLumpIndex + 13], (char)fileLumpContents[fileLumpIndex + 14], (char)fileLumpContents[fileLumpIndex + 15] };
                fileLumpIndex += 16;

                lumps[lumpIndex] = new Lump(lumpOffset, lumpLength, lumpVersion, lumpIdent);
                lumpIndex++;
            }
        }
        public byte[] GetFileContents(string dir)
        {
            try
            {
                return File.ReadAllBytes(dir);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Invalid file path entered", "Invalid Path", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return new byte[64]; // for now, return an empty byte array if the file couldnt be opened, final version wont use manual entry
        }
        public bool IsValidBSPFile()
        {
            if (ident == VBSPReader.VBSPMAGICNUM)
            {
                return true;
            }
            return false;
        }
        public int GetFileVersion()
        {
            return version;
        }
        public Lump[] GetLumpsArray()
        {
            // get the next 1024 bytes of the file (64 entries, 16 bytes per lump)

            return new Lump[64];
        }
        public int GetMapRevision()
        {
            // get the last 4 bytes of the header

            return 0;
        }

        // Only including games of interest, will add support for other versions if needed.
        // 19 games could possibly use version 20, add a file check first.
        public enum VBSPFileVersions
        {
            HL2 = 19,
            HL2DM = 19,
            CSS = 19,
            HL2EP1 = 20,
            HL2EP2 = 20,
            HL2LC = 20,
            GMOD = 20,
            TF2 = 20,
            PRTL = 20,
            L4D = 20,
            BMS = 20,
            L4D2 = 20,
            PRTL2 = 20,
            CSGO = 20,
        }
    }
}