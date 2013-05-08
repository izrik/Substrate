using System;
using Substrate;
using Substrate.Core;
using System.Linq;
using System.Collections.Generic;

namespace CopyMap
{
    class MainClass
    {
        struct Point
        {
            public Point(int x, int z)
            {
                X = x;
                Z = z;
            }
            public int X;
            public int Z;
        }

        class Hash<T> : Dictionary<string, T> { }

        class WorldData
        {
            public string Name;
            public AnvilWorld World;
            public RegionChunkManager ChunkManager;
            public Dictionary<Point, ChunkRef> ChunksByLocation = new Dictionary<Point, ChunkRef>();
            public char Label;
            public int id;
        }

        public static void Main(string[] args)
        {
            string[] worldNames = { 
                "happy planet",
//                "Tims Jungle",
                "Tims Happy Jungle Planet",
            };
            Dictionary<string, WorldData> worldsByName = new Dictionary<string, WorldData>();
            bool first = false;

            int minx = 0;
            int maxx = 0;
            int minz = 0;
            int maxz = 0;

            char label = 'A';
            int id = 1;

            foreach (string worldName in worldNames)
            {
                AnvilWorld world = AnvilWorld.Open("/Users/" + System.Environment.UserName + "/Library/Application Support/minecraft/saves/" + worldName);
                RegionChunkManager rcm = world.GetChunkManager();
                worldsByName[worldName] = 
                    new WorldData{
                        Name = worldName,
                        World = world,
                        ChunkManager = rcm,
                        Label = label,
                        id = id};
                label++;
                id *= 2;

                Dictionary<Point, ChunkRef> chunksByLocation = worldsByName[worldName].ChunksByLocation;

                foreach (ChunkRef cr in rcm)
                {
                    if (first)
                    {
                        minx = cr.X;
                        maxx = cr.X;
                        minz = cr.Z;
                        maxz = cr.Z;
                    }
                    else
                    {
                        if (cr.X < minx) minx = cr.X;
                        if (cr.X > maxx) maxx = cr.X;
                        if (cr.Z < minz) minz = cr.Z;
                        if (cr.Z > maxz) maxz = cr.Z;
        //                Console.WriteLine("{0}, {1} ({2}, {3})", cr.X, cr.Z, cr.LocalX, cr.LocalZ);
                    }
                    chunksByLocation[new Point(cr.X,cr.Z)] = cr;
                }
            }

            Console.WriteLine("minx: {0}, maxx: {1}", minx, maxx);
            Console.WriteLine("minz: {0}, maxz: {1}", minz, maxz);

            Console.WriteLine();

//            int x;
//            int z;
//            for (z = minz; z <= maxz; z++)
//            {
//                for (x = minx; x <= maxx; x++)
//                {
//                    int n = 0;
//                    foreach (WorldData wd in worldsByName.Values)
//                    {
//                        if (wd.ChunksByLocation.ContainsKey(new Point(x,z)))
//                        {
//                            n |= wd.id;
//                        }
//                    }
//                    if (n > 0)
//                    {
//                        Console.Write("{0}", n);
//                    }
//                    else
//                    {
//                        Console.Write(" ");
//                    }
//                }
//                Console.WriteLine();
//            }
//            world.Save();

            WorldData from = worldsByName["happy planet"];
            WorldData to = worldsByName["Tims Happy Jungle Planet"];

            foreach (ChunkRef cr in to.ChunkManager)
            {
                to.ChunkManager.DeleteChunk(cr.X, cr.Z);
            }
            foreach (ChunkRef cr in from.ChunkManager)
            {
                if (to.ChunkManager.ChunkExists(cr.X, cr.Z))
                {
                    to.ChunkManager.DeleteChunk(cr.X, cr.Z);
                }
                to.ChunkManager.SetChunk(cr.X, cr.Z, cr);
                to.World.GetBlockManager().SetID(cr.X * 16 + 2, 254, cr.Z * 16 + 2, BlockType.DIRT);
                to.World.GetBlockManager().SetID(cr.X * 16 + 2, 254, cr.Z * 16 - 2, BlockType.DIRT);
                to.World.GetBlockManager().SetID(cr.X * 16 - 2, 254, cr.Z * 16 + 2, BlockType.DIRT);
                to.World.GetBlockManager().SetID(cr.X * 16 - 2, 254, cr.Z * 16 - 2, BlockType.DIRT);
            }

            to.World.Save();
        }
    }
}
