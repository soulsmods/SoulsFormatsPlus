using System.Numerics;

namespace SoulsFormats.Formats.FLVER.FLVER0
{
    public partial class FLVER0
    {
        /// <summary>
        /// General metadata about a FLVER0.
        /// </summary>
        public class FLVER0Header
        {
            /// <summary>
            /// If true FLVER will be written big-endian, if false little-endian.
            /// </summary>
            public bool BigEndian { get; set; }

            /// <summary>
            /// Version of the format indicating presence of various features.
            /// </summary>
            public int Version { get; set; }

            /// <summary>
            /// Minimum extent of the entire model.
            /// </summary>
            public Vector3 BoundingBoxMin { get; set; }

            /// <summary>
            /// Maximum extent of the entire model.
            /// </summary>
            public Vector3 BoundingBoxMax { get; set; }

            /// <summary>
            /// Size of vertex indices; either 16 or 32.
            /// </summary>
            public byte VertexIndexSize { get; set; }

            /// <summary>
            /// If true strings are UTF-16, if false Shift-JIS.
            /// </summary>
            public bool Unicode { get; set; }

            /// <summary>
            /// Unknown. Typically 1. Probably a flag.
            /// </summary>
            public byte Unk4A { get; set; }

            /// <summary>
            /// Unknown. Typically 0.
            /// </summary>
            public byte Unk4B { get; set; }

            /// <summary>
            /// Unknown. Typically 0xFFFF
            /// </summary>
            public int Unk4C { get; set; }

            /// <summary>
            /// Unknown. Typically 0.
            /// </summary>
            public int Unk5C { get; set; }
        }
    }
}
