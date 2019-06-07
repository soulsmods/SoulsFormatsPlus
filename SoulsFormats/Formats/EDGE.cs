﻿using System;
using System.Collections.Generic;
using System.Numerics;

namespace SoulsFormats
{
    /// <summary>
    /// A Sekiro file that defines grapple points and hangable edges for a model.
    /// </summary>
    public class EDGE : SoulsFile<EDGE>
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Edges defined in this file.
        /// </summary>
        public List<Edge> Edges;

        internal override bool Is(BinaryReaderEx br)
        {
            throw new NotImplementedException();
        }

        internal override void Read(BinaryReaderEx br)
        {
            br.BigEndian = false;
            br.AssertInt32(4);
            int edgeCount = br.ReadInt32();
            ID = br.ReadInt32();
            br.AssertInt32(0);

            Edges = new List<Edge>(edgeCount);
            for (int i = 0; i < edgeCount; i++)
                Edges.Add(new Edge(br));
        }

        internal override void Write(BinaryWriterEx bw)
        {
            bw.BigEndian = false;
            bw.WriteInt32(4);
            bw.WriteInt32(Edges.Count);
            bw.WriteInt32(ID);
            bw.WriteInt32(0);

            foreach (Edge edge in Edges)
                edge.Write(bw);
        }

        /// <summary>
        /// A grapple point or hangable edge.
        /// </summary>
        public class Edge
        {
            /// <summary>
            /// The starting point of the edge.
            /// </summary>
            public Vector3 V1 { get; set; }

            /// <summary>
            /// The ending point of the edge.
            /// </summary>
            public Vector3 V2 { get; set; }

            /// <summary>
            /// Unknown.
            /// </summary>
            public int Unk30 { get; set; }

            /// <summary>
            /// Unknown.
            /// </summary>
            public byte Unk34 { get; set; }

            /// <summary>
            /// Unknown.
            /// </summary>
            public byte Unk35 { get; set; }

            /// <summary>
            /// Unknown.
            /// </summary>
            public byte Unk36 { get; set; }

            internal Edge(BinaryReaderEx br)
            {
                V1 = br.ReadVector3();
                br.AssertSingle(1);
                V2 = br.ReadVector3();
                br.AssertSingle(1);
                br.AssertPattern(0x10, 0x00);
                Unk30 = br.ReadInt32();
                Unk34 = br.ReadByte();
                Unk35 = br.ReadByte();
                Unk36 = br.ReadByte();
                br.AssertByte(0);
                br.AssertPattern(0x8, 0x00);
            }

            internal void Write(BinaryWriterEx bw)
            {
                bw.WriteVector3(V1);
                bw.WriteSingle(1);
                bw.WriteVector3(V2);
                bw.WriteSingle(1);
                bw.WritePattern(0x10, 0x00);
                bw.WriteInt32(Unk30);
                bw.WriteByte(Unk34);
                bw.WriteByte(Unk35);
                bw.WriteByte(Unk36);
                bw.WriteByte(0);
                bw.WritePattern(0x8, 0x00);
            }
        }
    }
}