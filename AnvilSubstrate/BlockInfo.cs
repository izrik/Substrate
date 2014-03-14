﻿using System;
using System.Collections.Generic;
using Substrate.Nbt;

namespace Substrate
{
    /// <summary>
    /// Provides named id values for known block types.
    /// </summary>
    /// <remarks><para>The preferred method to lookup
    /// Minecraft block IDs is to access the ID field of the corresponding static BlockInfo
    /// object in the BlockInfo class.</para>
    /// <para>The static BlockInfo objects can be re-bound to new BlockInfo objects, allowing
    /// the named object to be bound to a new block ID.  This gives the developer more flexibility
    /// in supporting nonstandard worlds, and the ability to future-proof their application against
    /// changes to Block IDs, by implementing functionality to import block/ID mappings from an
    /// external source and rebinding the objects in BlockInfo.</para></remarks>
    public enum BlockType
    {
        AIR = 0,
        STONE = 1,
        GRASS = 2,
        DIRT = 3,
        COBBLESTONE = 4,
        WOOD_PLANK = 5,
        SAPLING = 6,
        BEDROCK = 7,
        WATER = 8,
        STATIONARY_WATER = 9,
        LAVA = 10,
        STATIONARY_LAVA = 11,
        SAND = 12,
        GRAVEL = 13,
        GOLD_ORE = 14,
        IRON_ORE = 15,
        COAL_ORE = 16,
        WOOD = 17,
        LEAVES = 18,
        SPONGE = 19,
        GLASS = 20,
        LAPIS_ORE = 21,
        LAPIS_BLOCK = 22,
        DISPENSER = 23,
        SANDSTONE = 24,
        NOTE_BLOCK = 25,
        BED = 26,
        POWERED_RAIL = 27,
        DETECTOR_RAIL = 28,
        STICKY_PISTON = 29,
        COBWEB = 30,
        TALL_GRASS = 31,
        DEAD_SHRUB = 32,
        PISTON = 33,
        PISTON_HEAD = 34,
        WOOL = 35,
        PISTON_MOVING = 36,
        YELLOW_FLOWER = 37,
        RED_ROSE = 38,
        BROWN_MUSHROOM = 39,
        RED_MUSHROOM = 40,
        GOLD_BLOCK = 41,
        IRON_BLOCK = 42,
        DOUBLE_STONE_SLAB = 43,
        STONE_SLAB = 44,
        BRICK_BLOCK = 45,
        TNT = 46,
        BOOKSHELF = 47,
        MOSS_STONE = 48,
        OBSIDIAN = 49,
        TORCH = 50,
        FIRE = 51,
        MONSTER_SPAWNER = 52,
        WOOD_STAIRS = 53,
        CHEST = 54,
        REDSTONE_WIRE = 55,
        DIAMOND_ORE = 56,
        DIAMOND_BLOCK = 57,
        CRAFTING_TABLE = 58,
        CROPS = 59,
        FARMLAND = 60,
        FURNACE = 61,
        BURNING_FURNACE = 62,
        SIGN_POST = 63,
        WOOD_DOOR = 64,
        LADDER = 65,
        RAILS = 66,
        COBBLESTONE_STAIRS = 67,
        WALL_SIGN = 68,
        LEVER = 69,
        STONE_PLATE = 70,
        IRON_DOOR = 71,
        WOOD_PLATE = 72,
        REDSTONE_ORE = 73,
        GLOWING_REDSTONE_ORE = 74,
        REDSTONE_TORCH_OFF = 75,
        REDSTONE_TORCH_ON = 76,
        STONE_BUTTON = 77,
        SNOW = 78,
        ICE = 79,
        SNOW_BLOCK = 80,
        CACTUS = 81,
        CLAY_BLOCK = 82,
        SUGAR_CANE = 83,
        JUKEBOX = 84,
        FENCE = 85,
        PUMPKIN = 86,
        NETHERRACK = 87,
        SOUL_SAND = 88,
        GLOWSTONE_BLOCK = 89,
        PORTAL = 90,
        JACK_O_LANTERN = 91,
        CAKE_BLOCK = 92,
        REDSTONE_REPEATER_ON = 93,
        REDSTONE_REPEATER_OFF = 94,
        LOCKED_CHEST = 95,
        TRAPDOOR = 96,
        SILVERFISH_STONE = 97,
        STONE_BRICK = 98,
        HUGE_RED_MUSHROOM = 99,
        HUGE_BROWN_MUSHROOM = 100,
        IRON_BARS = 101,
        GLASS_PANE = 102,
        MELON = 103,
        PUMPKIN_STEM = 104,
        MELON_STEM = 105,
        VINES = 106,
        FENCE_GATE = 107,
        BRICK_STAIRS = 108,
        STONE_BRICK_STAIRS = 109,
        MYCELIUM = 110,
        LILLY_PAD = 111,
        NETHER_BRICK = 112,
        NETHER_BRICK_FENCE = 113,
        NETHER_BRICK_STAIRS = 114,
        NETHER_WART = 115,
        ENCHANTMENT_TABLE = 116,
        BREWING_STAND = 117,
        CAULDRON = 118,
        END_PORTAL = 119,
        END_PORTAL_FRAME = 120,
        END_STONE = 121,
        DRAGON_EGG = 122,
        REDSTONE_LAMP_OFF = 123,
        REDSTONE_LAMP_ON = 124,
        DOUBLE_WOOD_SLAB = 125,
        WOOD_SLAB = 126,
        COCOA_PLANT = 127,
        SANDSTONE_STAIRS = 128,
        EMERALD_ORE = 129,
        ENDER_CHEST = 130,
        TRIPWIRE_HOOK = 131,
        TRIPWIRE = 132,
        EMERALD_BLOCK = 133,
        SPRUCE_WOOD_STAIRS = 134,
        BIRCH_WOOD_STAIRS = 135,
        JUNGLE_WOOD_STAIRS = 136,
        COMMAND_BLOCK = 137,
        BEACON_BLOCK = 138,
        COBBLESTONE_WALL = 139,
        FLOWER_POT = 140,
        CARROTS = 141,
        POTATOES = 142,
        WOOD_BUTTON = 143,
        HEADS = 144,
        ANVIL = 145,

        QUARTZ_BLOCK = 155,
        QUARTZ_STAIRS = 156,
    }

    /// <summary>
    /// Represents the physical state of a block, such as solid or fluid.
    /// </summary>
    public enum BlockState
    {
        /// <summary>
        /// A solid state that stops movement.
        /// </summary>
        SOLID,

        /// <summary>
        /// A nonsolid state that can be passed through.
        /// </summary>
        NONSOLID,

        /// <summary>
        /// A fluid state that flows and impedes movement.
        /// </summary>
        FLUID
    }

    /// <summary>
    /// Provides information on a specific type of block.
    /// </summary>
    /// <remarks>By default, all known MC block types are already defined and registered, assuming Substrate
    /// is up to date with the current MC version.  All unknown blocks are given a default type and unregistered status.
    /// New block types may be created and used at runtime, and will automatically populate various static lookup tables
    /// in the <see cref="BlockInfo"/> class.</remarks>
    public class BlockInfo
    {
        /// <summary>
        /// The maximum number of sequential blocks starting at 0 that can be registered.
        /// </summary>
        public const int MAX_BLOCKS = 4096;

        /// <summary>
        /// The maximum opacity value that can be assigned to a block (fully opaque).
        /// </summary>
        public const int MAX_OPACITY = 15;

        /// <summary>
        /// The minimum opacity value that can be assigned to a block (fully transparent).
        /// </summary>
        public const int MIN_OPACITY = 0;

        /// <summary>
        /// The maximum luminance value that can be assigned to a block.
        /// </summary>
        public const int MAX_LUMINANCE = 15;

        /// <summary>
        /// The minimum luminance value that can be assigned to a block.
        /// </summary>
        public const int MIN_LUMINANCE = 0;

        private static readonly BlockInfo[] _blockTable;
        private static readonly int[] _opacityTable;
        private static readonly int[] _luminanceTable;

        private class CacheTableArray<T> : ICacheTable<T>
        {
            private T[] _cache;

            public T this[int index]
            {
                get { return _cache[index]; }
            }

            public CacheTableArray (T[] cache)
            {
                _cache = cache;
            }
        }

        private class DataLimits
        {
            private int _low;
            private int _high;
            private int _bitmask;

            public int Low
            {
                get { return _low; }
            }

            public int High
            {
                get { return _high; }
            }

            public int Bitmask
            {
                get { return _bitmask; }
            }

            public DataLimits (int low, int high, int bitmask)
            {
                _low = low;
                _high = high;
                _bitmask = bitmask;
            }

            public bool Test (int data)
            {
                int rdata = data & ~_bitmask;
                return rdata >= _low && rdata <= _high;
            }
        }

        private int _id = 0;
        private string _name = "";
        private int _tick = 0;
        private int _opacity = MAX_OPACITY;
        private int _luminance = MIN_LUMINANCE;
        private bool _transmitLight = false;
        private bool _blocksFluid = true;
        private bool _registered = false;

        private BlockState _state = BlockState.SOLID;

        private DataLimits _dataLimits;

        private static readonly CacheTableArray<BlockInfo> _blockTableCache;
        private static readonly CacheTableArray<int> _opacityTableCache;
        private static readonly CacheTableArray<int> _luminanceTableCache;

        /// <summary>
        /// Gets the lookup table for id-to-info values.
        /// </summary>
        public static ICacheTable<BlockInfo> BlockTable
        {
            get { return _blockTableCache; }
        }

        /// <summary>
        /// Gets the lookup table for id-to-opacity values.
        /// </summary>
        public static ICacheTable<int> OpacityTable
        {
            get { return _opacityTableCache; }
        }

        /// <summary>
        /// Gets the lookup table for id-to-luminance values.
        /// </summary>
        public static ICacheTable<int> LuminanceTable
        {
            get { return _luminanceTableCache; }
        }

        /// <summary>
        /// Get's the block's Id.
        /// </summary>
        public int ID
        {
            get { return _id; }
        }

        /// <summary>
        /// Get's the name of the block type.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the block's opacity value.  An opacity of 0 is fully transparent to light.
        /// </summary>
        public int Opacity 
        {
            get { return _opacity; }
        }
        
        /// <summary>
        /// Gets the block's luminance value.
        /// </summary>
        /// <remarks>Blocks with luminance act as light sources and transmit light to other blocks.</remarks>
        public int Luminance 
        {
            get { return _luminance; }
        }

        /// <summary>
        /// Checks whether the block transmits light to neighboring blocks.
        /// </summary>
        /// <remarks>A block may stop the transmission of light, but still be illuminated.</remarks>
        public bool TransmitsLight
        {
            get { return _transmitLight; }
        }

        /// <summary>
        /// Checks whether the block partially or fully blocks the transmission of light.
        /// </summary>
        public bool ObscuresLight
        {
            get { return _opacity > MIN_OPACITY || !_transmitLight; }
        }

        /// <summary>
        /// Checks whether the block stops fluid from passing through it.
        /// </summary>
        /// <remarks>A block that does not block fluids will be destroyed by fluid.</remarks>
        public bool BlocksFluid
        {
            get { return _blocksFluid; }
        }

        /// <summary>
        /// Gets the block's physical state type.
        /// </summary>
        public BlockState State
        {
            get { return _state; }
        }

        /// <summary>
        /// Checks whether this block type has been registered as a known type.
        /// </summary>
        public bool Registered
        {
            get { return _registered; }
        }

        public int Tick
        {
            get { return _tick; }
        }

        internal BlockInfo (int id)
        {
            _id = id;
            _name = "Unknown Block";
            _blockTable[_id] = this;
        }

        /// <summary>
        /// Constructs a new <see cref="BlockInfo"/> record for a given block id and name.
        /// </summary>
        /// <param name="id">The id of the block.</param>
        /// <param name="name">The name of the block.</param>
        /// <remarks>All user-constructed <see cref="BlockInfo"/> objects are registered automatically.</remarks>
        public BlockInfo (int id, string name)
        {
            _id = id;
            _name = name;
            _blockTable[_id] = this;
            _registered = true;
        }

        /// <summary>
        /// Sets a new opacity value for this block type.
        /// </summary>
        /// <param name="opacity">A new opacity value.</param>
        /// <returns>The object instance used to invoke this method.</returns>
        /// <seealso cref="AlphaBlockCollection.AutoLight"/>
        public BlockInfo SetOpacity (int opacity)
        {
            _opacity = MIN_OPACITY + opacity;
            _opacityTable[_id] = _opacity;

            if (opacity == MAX_OPACITY) {
                _transmitLight = false;
            }
            else {
                _transmitLight = true;
            }

            return this;
        }

        /// <summary>
        /// Sets a new luminance value for this block type.
        /// </summary>
        /// <param name="luminance">A new luminance value.</param>
        /// <returns>The object instance used to invoke this method.</returns>
        /// <seealso cref="AlphaBlockCollection.AutoLight"/>
        public BlockInfo SetLuminance (int luminance)
        {
            _luminance = luminance;
            _luminanceTable[_id] = _luminance;
            return this;
        }

        /// <summary>
        /// Sets whether or not this block type will transmit light to neigboring blocks.
        /// </summary>
        /// <param name="transmit">True if this block type can transmit light to neighbors, false otherwise.</param>
        /// <returns>The object instance used to invoke this method.</returns>
        /// <seealso cref="AlphaBlockCollection.AutoLight"/>
        public BlockInfo SetLightTransmission (bool transmit)
        {
            _transmitLight = transmit;
            return this;
        }

        /// <summary>
        /// Sets limitations on what data values are considered valid for this block type.
        /// </summary>
        /// <param name="low">The lowest valid integer value.</param>
        /// <param name="high">The highest valid integer value.</param>
        /// <param name="bitmask">A mask representing which bits are interpreted as a bitmask in the data value.</param>
        /// <returns>The object instance used to invoke this method.</returns>
        public BlockInfo SetDataLimits (int low, int high, int bitmask)
        {
            _dataLimits = new DataLimits(low, high, bitmask);
            return this;
        }

        /// <summary>
        /// Sets the physical state of the block type.
        /// </summary>
        /// <param name="state">A physical state.</param>
        /// <returns>The object instance used to invoke this method.</returns>
        public BlockInfo SetState (BlockState state)
        {
            _state = state;

            if (_state == BlockState.SOLID) {
                _blocksFluid = true;
            }
            else {
                _blocksFluid = false;
            }

            return this;
        }

        /// <summary>
        /// Sets whether or not this block type blocks fluids.
        /// </summary>
        /// <param name="blocks">True if this block type blocks fluids, false otherwise.</param>
        /// <returns>The object instance used to invoke this method.</returns>
        /// <seealso cref="AlphaBlockCollection.AutoFluid"/>
        public BlockInfo SetBlocksFluid (bool blocks)
        {
            _blocksFluid = blocks;
            return this;
        }

        /// <summary>
        /// Sets the default tick rate/delay used for updating this block.
        /// </summary>
        /// <remarks>Set <paramref name="tick"/> to <c>0</c> to indicate that this block is not processed by tick updates.</remarks>
        /// <param name="tick">The tick rate in frames between scheduled updates on this block.</param>
        /// <returns>The object instance used to invoke this method.</returns>
        /// <seealso cref="AlphaBlockCollection.AutoTileTick"/>
        public BlockInfo SetTick (int tick)
        {
            _tick = tick;
            return this;
        }

        /// <summary>
        /// Tests if the given data value is valid for this block type.
        /// </summary>
        /// <param name="data">A data value to test.</param>
        /// <returns>True if the data value is valid, false otherwise.</returns>
        /// <remarks>This method uses internal information set by <see cref="SetDataLimits"/>.</remarks>
        public bool TestData (int data)
        {
            if (_dataLimits == null) {
                return true;
            }
            return _dataLimits.Test(data);
        }

        public static BlockInfo Air;
        public static BlockInfo Stone;
        public static BlockInfo Grass;
        public static BlockInfo Dirt;
        public static BlockInfo Cobblestone;
        public static BlockInfo WoodPlank;
        public static BlockInfo Sapling;
        public static BlockInfo Bedrock;
        public static BlockInfo Water;
        public static BlockInfo StationaryWater;
        public static BlockInfo Lava;
        public static BlockInfo StationaryLava;
        public static BlockInfo Sand;
        public static BlockInfo Gravel;
        public static BlockInfo GoldOre;
        public static BlockInfo IronOre;
        public static BlockInfo CoalOre;
        public static BlockInfo Wood;
        public static BlockInfo Leaves;
        public static BlockInfo Sponge;
        public static BlockInfo Glass;
        public static BlockInfo LapisOre;
        public static BlockInfo LapisBlock;
        public static BlockInfoEx Dispenser;
        public static BlockInfo Sandstone;
        public static BlockInfoEx NoteBlock;
        public static BlockInfo Bed;
        public static BlockInfo PoweredRail;
        public static BlockInfo DetectorRail;
        public static BlockInfo StickyPiston;
        public static BlockInfo Cobweb;
        public static BlockInfo TallGrass;
        public static BlockInfo DeadShrub;
        public static BlockInfo Piston;
        public static BlockInfo PistonHead;
        public static BlockInfo Wool;
        public static BlockInfoEx PistonMoving;
        public static BlockInfo YellowFlower;
        public static BlockInfo RedRose;
        public static BlockInfo BrownMushroom;
        public static BlockInfo RedMushroom;
        public static BlockInfo GoldBlock;
        public static BlockInfo IronBlock;
        public static BlockInfo DoubleStoneSlab;
        public static BlockInfo StoneSlab;
        public static BlockInfo BrickBlock;
        public static BlockInfo TNT;
        public static BlockInfo Bookshelf;
        public static BlockInfo MossStone;
        public static BlockInfo Obsidian;
        public static BlockInfo Torch;
        public static BlockInfo Fire;
        public static BlockInfoEx MonsterSpawner;
        public static BlockInfo WoodStairs;
        public static BlockInfoEx Chest;
        public static BlockInfo RedstoneWire;
        public static BlockInfo DiamondOre;
        public static BlockInfo DiamondBlock;
        public static BlockInfo CraftTable;
        public static BlockInfo Crops;
        public static BlockInfo Farmland;
        public static BlockInfoEx Furnace;
        public static BlockInfoEx BurningFurnace;
        public static BlockInfoEx SignPost;
        public static BlockInfo WoodDoor;
        public static BlockInfo Ladder;
        public static BlockInfo Rails;
        public static BlockInfo CobbleStairs;
        public static BlockInfoEx WallSign;
        public static BlockInfo Lever;
        public static BlockInfo StonePlate;
        public static BlockInfo IronDoor;
        public static BlockInfo WoodPlate;
        public static BlockInfo RedstoneOre;
        public static BlockInfo GlowRedstoneOre;
        public static BlockInfo RedstoneTorch;
        public static BlockInfo RedstoneTorchOn;
        public static BlockInfo StoneButton;
        public static BlockInfo Snow;
        public static BlockInfo Ice;
        public static BlockInfo SnowBlock;
        public static BlockInfo Cactus;
        public static BlockInfo ClayBlock;
        public static BlockInfo SugarCane;
        public static BlockInfo Jukebox;
        public static BlockInfo Fence;
        public static BlockInfo Pumpkin;
        public static BlockInfo Netherrack;
        public static BlockInfo SoulSand;
        public static BlockInfo Glowstone;
        public static BlockInfo Portal;
        public static BlockInfo JackOLantern;
        public static BlockInfo CakeBlock;
        public static BlockInfo RedstoneRepeater;
        public static BlockInfo RedstoneRepeaterOn;
        public static BlockInfoEx LockedChest;
        public static BlockInfo Trapdoor;
        public static BlockInfo SilverfishStone;
        public static BlockInfo StoneBrick;
        public static BlockInfo HugeRedMushroom;
        public static BlockInfo HugeBrownMushroom;
        public static BlockInfo IronBars;
        public static BlockInfo GlassPane;
        public static BlockInfo Melon;
        public static BlockInfo PumpkinStem;
        public static BlockInfo MelonStem;
        public static BlockInfo Vines;
        public static BlockInfo FenceGate;
        public static BlockInfo BrickStairs;
        public static BlockInfo StoneBrickStairs;
        public static BlockInfo Mycelium;
        public static BlockInfo LillyPad;
        public static BlockInfo NetherBrick;
        public static BlockInfo NetherBrickFence;
        public static BlockInfo NetherBrickStairs;
        public static BlockInfo NetherWart;
        public static BlockInfoEx EnchantmentTable;
        public static BlockInfoEx BrewingStand;
        public static BlockInfo Cauldron;
        public static BlockInfoEx EndPortal;
        public static BlockInfo EndPortalFrame;
        public static BlockInfo EndStone;
        public static BlockInfo DragonEgg;
        public static BlockInfo RedstoneLampOff;
        public static BlockInfo RedstoneLampOn;
        public static BlockInfo DoubleWoodSlab;
        public static BlockInfo WoodSlab;
        public static BlockInfo CocoaPlant;
        public static BlockInfo SandstoneStairs;
        public static BlockInfo EmeraldOre;
        public static BlockInfoEx EnderChest;
        public static BlockInfo TripwireHook;
        public static BlockInfo Tripwire;
        public static BlockInfo EmeraldBlock;
        public static BlockInfo SpruceWoodStairs;
        public static BlockInfo BirchWoodStairs;
        public static BlockInfo JungleWoodStairs;
        public static BlockInfoEx CommandBlock;
        public static BlockInfoEx BeaconBlock;
        public static BlockInfo CobblestoneWall;
        public static BlockInfo FlowerPot;
        public static BlockInfo Carrots;
        public static BlockInfo Potatoes;
        public static BlockInfo WoodButton;
        public static BlockInfo Heads;
        public static BlockInfo Anvil;

        static BlockInfo ()
        {
            _blockTable = new BlockInfo[MAX_BLOCKS];
            _opacityTable = new int[MAX_BLOCKS];
            _luminanceTable = new int[MAX_BLOCKS];

            _blockTableCache = new CacheTableArray<BlockInfo>(_blockTable);
            _opacityTableCache = new CacheTableArray<int>(_opacityTable);
            _luminanceTableCache = new CacheTableArray<int>(_luminanceTable);

            Air = new BlockInfo(0, "Air").SetOpacity(0).SetState(BlockState.NONSOLID);
            Stone = new BlockInfo(1, "Stone");
            Grass = new BlockInfo(2, "Grass").SetTick(10);
            Dirt = new BlockInfo(3, "Dirt");
            Cobblestone = new BlockInfo(4, "Cobblestone");
            WoodPlank = new BlockInfo(5, "Wooden Plank");
            Sapling = new BlockInfo(6, "Sapling").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            Bedrock = new BlockInfo(7, "Bedrock");
            Water = new BlockInfo(8, "Water").SetOpacity(3).SetState(BlockState.FLUID).SetTick(5);
            StationaryWater = new BlockInfo(9, "Stationary Water").SetOpacity(3).SetState(BlockState.FLUID);
            Lava = new BlockInfo(10, "Lava").SetOpacity(0).SetLuminance(MAX_LUMINANCE).SetState(BlockState.FLUID).SetTick(30);
            StationaryLava = new BlockInfo(11, "Stationary Lava").SetOpacity(0).SetLuminance(MAX_LUMINANCE).SetState(BlockState.FLUID).SetTick(10);
            Sand = new BlockInfo(12, "Sand").SetTick(3);
            Gravel = new BlockInfo(13, "Gravel").SetTick(3);
            GoldOre = new BlockInfo(14, "Gold Ore");
            IronOre = new BlockInfo(15, "Iron Ore");
            CoalOre = new BlockInfo(16, "Coal Ore");
            Wood = new BlockInfo(17, "Wood");
            Leaves = new BlockInfo(18, "Leaves").SetOpacity(1).SetTick(10);
            Sponge = new BlockInfo(19, "Sponge");
            Glass = new BlockInfo(20, "Glass").SetOpacity(0);
            LapisOre = new BlockInfo(21, "Lapis Lazuli Ore");
            LapisBlock = new BlockInfo(22, "Lapis Lazuli Block");
            Dispenser = (BlockInfoEx)new BlockInfoEx(23, "Dispenser").SetTick(4);
            Sandstone = new BlockInfo(24, "Sandstone");
            NoteBlock = new BlockInfoEx(25, "Note Block");
            Bed = new BlockInfo(26, "Bed").SetOpacity(0);
            PoweredRail = new BlockInfo(27, "Powered Rail").SetOpacity(0).SetState(BlockState.NONSOLID);
            DetectorRail = new BlockInfo(28, "Detector Rail").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(20);
            StickyPiston = new BlockInfo(29, "Sticky Piston").SetOpacity(0);
            Cobweb = new BlockInfo(30, "Cobweb").SetOpacity(0).SetState(BlockState.NONSOLID);
            TallGrass = new BlockInfo(31, "Tall Grass").SetOpacity(0).SetState(BlockState.NONSOLID);
            DeadShrub = new BlockInfo(32, "Dead Shrub").SetOpacity(0).SetState(BlockState.NONSOLID);
            Piston = new BlockInfo(33, "Piston").SetOpacity(0);
            PistonHead = new BlockInfo(34, "Piston Head").SetOpacity(0);
            Wool = new BlockInfo(35, "Wool");
            PistonMoving = (BlockInfoEx)new BlockInfoEx(36, "Piston Moving").SetOpacity(0);
            YellowFlower = new BlockInfo(37, "Yellow Flower").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            RedRose = new BlockInfo(38, "Red Rose").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            BrownMushroom = new BlockInfo(39, "Brown Mushroom").SetOpacity(0).SetLuminance(1).SetState(BlockState.NONSOLID).SetTick(10);
            RedMushroom = new BlockInfo(40, "Red Mushroom").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            GoldBlock = new BlockInfo(41, "Gold Block");
            IronBlock = new BlockInfo(42, "Iron Block");
            DoubleStoneSlab = new BlockInfo(43, "Double Slab");
            StoneSlab = new BlockInfo(44, "Slab").SetOpacity(0);
            BrickBlock = new BlockInfo(45, "Brick Block");
            TNT = new BlockInfo(46, "TNT");
            Bookshelf = new BlockInfo(47, "Bookshelf");
            MossStone = new BlockInfo(48, "Moss Stone");
            Obsidian = new BlockInfo(49, "Obsidian");
            Torch = new BlockInfo(50, "Torch").SetOpacity(0).SetLuminance(MAX_LUMINANCE - 1).SetState(BlockState.NONSOLID).SetTick(10);
            Fire = new BlockInfo(51, "Fire").SetOpacity(0).SetLuminance(MAX_LUMINANCE).SetState(BlockState.NONSOLID).SetTick(40);
            MonsterSpawner = (BlockInfoEx)new BlockInfoEx(52, "Monster Spawner").SetOpacity(0);
            WoodStairs = new BlockInfo(53, "Wooden Stairs").SetOpacity(0);
            Chest = (BlockInfoEx)new BlockInfoEx(54, "Chest").SetOpacity(0);
            RedstoneWire = new BlockInfo(55, "Redstone Wire").SetOpacity(0).SetState(BlockState.NONSOLID);
            DiamondOre = new BlockInfo(56, "Diamond Ore");
            DiamondBlock = new BlockInfo(57, "Diamond Block");
            CraftTable = new BlockInfo(58, "Crafting Table");
            Crops = new BlockInfo(59, "Crops").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            Farmland = new BlockInfo(60, "Farmland").SetOpacity(0).SetTick(10);
            Furnace = new BlockInfoEx(61, "Furnace");
            BurningFurnace = (BlockInfoEx)new BlockInfoEx(62, "Burning Furnace").SetLuminance(MAX_LUMINANCE - 1);
            SignPost = (BlockInfoEx)new BlockInfoEx(63, "Sign Post").SetOpacity(0).SetState(BlockState.NONSOLID);
            WoodDoor = new BlockInfo(64, "Wooden Door").SetOpacity(0);
            Ladder = new BlockInfo(65, "Ladder").SetOpacity(0);
            Rails = new BlockInfo(66, "Rails").SetOpacity(0).SetState(BlockState.NONSOLID);
            CobbleStairs = new BlockInfo(67, "Cobblestone Stairs").SetOpacity(0);
            WallSign = (BlockInfoEx)new BlockInfoEx(68, "Wall Sign").SetOpacity(0).SetState(BlockState.NONSOLID);
            Lever = new BlockInfo(69, "Lever").SetOpacity(0).SetState(BlockState.NONSOLID);
            StonePlate = new BlockInfo(70, "Stone Pressure Plate").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(20);
            IronDoor = new BlockInfo(71, "Iron Door").SetOpacity(0);
            WoodPlate = new BlockInfo(72, "Wooden Pressure Plate").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(20);
            RedstoneOre = new BlockInfo(73, "Redstone Ore").SetTick(30);
            GlowRedstoneOre = new BlockInfo(74, "Glowing Redstone Ore").SetLuminance(9).SetTick(30);
            RedstoneTorch = new BlockInfo(75, "Redstone Torch (Off)").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(2);
            RedstoneTorchOn = new BlockInfo(76, "Redstone Torch (On)").SetOpacity(0).SetLuminance(7).SetState(BlockState.NONSOLID).SetTick(2);
            StoneButton = new BlockInfo(77, "Stone Button").SetOpacity(0).SetState(BlockState.NONSOLID);
            Snow = new BlockInfo(78, "Snow").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            Ice = new BlockInfo(79, "Ice").SetOpacity(3).SetTick(10);
            SnowBlock = new BlockInfo(80, "Snow Block").SetTick(10);
            Cactus = new BlockInfo(81, "Cactus").SetOpacity(0).SetTick(10);
            ClayBlock = new BlockInfo(82, "Clay Block");
            SugarCane = new BlockInfo(83, "Sugar Cane").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            Jukebox = new BlockInfo(84, "Jukebox");
            Fence = new BlockInfo(85, "Fence").SetOpacity(0);
            Pumpkin = new BlockInfo(86, "Pumpkin");
            Netherrack = new BlockInfo(87, "Netherrack");
            SoulSand = new BlockInfo(88, "Soul Sand");
            Glowstone = new BlockInfo(89, "Glowstone Block").SetLuminance(MAX_LUMINANCE);
            Portal = new BlockInfo(90, "Portal").SetOpacity(0).SetLuminance(11).SetState(BlockState.NONSOLID);
            JackOLantern = new BlockInfo(91, "Jack-O-Lantern").SetLuminance(MAX_LUMINANCE);
            CakeBlock = new BlockInfo(92, "Cake Block").SetOpacity(0);
            RedstoneRepeater = new BlockInfo(93, "Redstone Repeater (Off)").SetOpacity(0).SetTick(10);
            RedstoneRepeaterOn = new BlockInfo(94, "Redstone Repeater (On)").SetOpacity(0).SetLuminance(7).SetTick(10);
            LockedChest = (BlockInfoEx)new BlockInfoEx(95, "Locked Chest").SetLuminance(MAX_LUMINANCE).SetTick(10);
            Trapdoor = new BlockInfo(96, "Trapdoor").SetOpacity(0);
            SilverfishStone = new BlockInfo(97, "Stone with Silverfish");
            StoneBrick = new BlockInfo(98, "Stone Brick");
            HugeRedMushroom = new BlockInfo(99, "Huge Red Mushroom");
            HugeBrownMushroom = new BlockInfo(100, "Huge Brown Mushroom");
            IronBars = new BlockInfo(101, "Iron Bars").SetOpacity(0);
            GlassPane = new BlockInfo(102, "Glass Pane").SetOpacity(0);
            Melon = new BlockInfo(103, "Melon");
            PumpkinStem = new BlockInfo(104, "Pumpkin Stem").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            MelonStem = new BlockInfo(105, "Melon Stem").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            Vines = new BlockInfo(106, "Vines").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            FenceGate = new BlockInfo(107, "Fence Gate").SetOpacity(0);
            BrickStairs = new BlockInfo(108, "Brick Stairs").SetOpacity(0);
            StoneBrickStairs = new BlockInfo(109, "Stone Brick Stairs").SetOpacity(0);
            Mycelium = new BlockInfo(110, "Mycelium").SetTick(10);
            LillyPad = new BlockInfo(111, "Lilly Pad").SetOpacity(0).SetState(BlockState.NONSOLID);
            NetherBrick = new BlockInfo(112, "Nether Brick");
            NetherBrickFence = new BlockInfo(113, "Nether Brick Fence").SetOpacity(0);
            NetherBrickStairs = new BlockInfo(114, "Nether Brick Stairs").SetOpacity(0);
            NetherWart = new BlockInfo(115, "Nether Wart").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            EnchantmentTable = (BlockInfoEx)new BlockInfoEx(116, "Enchantment Table").SetOpacity(0);
            BrewingStand = (BlockInfoEx)new BlockInfoEx(117, "Brewing Stand").SetOpacity(0);
            Cauldron = new BlockInfo(118, "Cauldron").SetOpacity(0);
            EndPortal = (BlockInfoEx)new BlockInfoEx(119, "End Portal").SetOpacity(0).SetLuminance(MAX_LUMINANCE).SetState(BlockState.NONSOLID);
            EndPortalFrame = new BlockInfo(120, "End Portal Frame").SetLuminance(MAX_LUMINANCE);
            EndStone = new BlockInfo(121, "End Stone");
            DragonEgg = new BlockInfo(122, "Dragon Egg").SetOpacity(0).SetLuminance(1).SetTick(3);
            RedstoneLampOff = new BlockInfo(123, "Redstone Lamp (Off)").SetTick(2);
            RedstoneLampOn = new BlockInfo(124, "Redstone Lamp (On)").SetLuminance(15).SetTick(2);
            DoubleWoodSlab = new BlockInfo(125, "Double Wood Slab");
            WoodSlab = new BlockInfo(126, "Wood Slab");
            CocoaPlant = new BlockInfo(127, "Cocoa Plant").SetLuminance(2).SetOpacity(0);
            SandstoneStairs = new BlockInfo(128, "Sandstone Stairs").SetOpacity(0);
            EmeraldOre = new BlockInfo(129, "Emerald Ore");
            EnderChest = (BlockInfoEx)new BlockInfoEx(130, "Ender Chest").SetLuminance(7).SetOpacity(0);
            TripwireHook = new BlockInfo(131, "Tripwire Hook").SetOpacity(0).SetState(BlockState.NONSOLID);
            Tripwire = new BlockInfo(132, "Tripwire").SetOpacity(0).SetState(BlockState.NONSOLID);
            EmeraldBlock = new BlockInfo(133, "Emerald Block");
            SpruceWoodStairs = new BlockInfo(134, "Sprice Wood Stairs").SetOpacity(0);
            BirchWoodStairs = new BlockInfo(135, "Birch Wood Stairs").SetOpacity(0);
            JungleWoodStairs = new BlockInfo(136, "Jungle Wood Stairs").SetOpacity(0);
            CommandBlock = (BlockInfoEx)new BlockInfoEx(137, "Command Block");
            BeaconBlock = (BlockInfoEx)new BlockInfoEx(138, "Beacon Block").SetOpacity(0).SetLuminance(MAX_LUMINANCE);
            CobblestoneWall = new BlockInfo(139, "Cobblestone Wall").SetOpacity(0);
            FlowerPot = new BlockInfo(140, "Flower Pot").SetOpacity(0);
            Carrots = new BlockInfo(141, "Carrots").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            Potatoes = new BlockInfo(142, "Potatoes").SetOpacity(0).SetState(BlockState.NONSOLID).SetTick(10);
            WoodButton = new BlockInfo(143, "Wooden Button").SetOpacity(0).SetState(BlockState.NONSOLID);
            Heads = new BlockInfo(144, "Heads").SetOpacity(0);
            Anvil = new BlockInfo(145, "Anvil").SetOpacity(0);

            for (int i = 0; i < MAX_BLOCKS; i++) {
                if (_blockTable[i] == null) {
                    _blockTable[i] = new BlockInfo(i);
                }
            }

            // Override default light transmission rules

            Lava.SetLightTransmission(false);
            StationaryLava.SetLightTransmission(false);
            StoneSlab.SetLightTransmission(false);
            WoodStairs.SetLightTransmission(false);
            Farmland.SetLightTransmission(false);
            CobbleStairs.SetLightTransmission(false);
            BrickStairs.SetLightTransmission(false);
            StoneBrickStairs.SetLightTransmission(false);
            NetherBrickStairs.SetLightTransmission(false);
            WoodSlab.SetLightTransmission(false);
            SandstoneStairs.SetLightTransmission(false);
            SpruceWoodStairs.SetLightTransmission(false);
            BirchWoodStairs.SetLightTransmission(false);
            JungleWoodStairs.SetLightTransmission(false);

            // Override default fluid blocking rules

            SignPost.SetBlocksFluid(true);
            WallSign.SetBlocksFluid(true);
            Cactus.SetBlocksFluid(false);

            // Set Tile Entity Data

            Dispenser.SetTileEntity("Trap");
            NoteBlock.SetTileEntity("Music");
            PistonMoving.SetTileEntity("Piston");
            MonsterSpawner.SetTileEntity("MobSpawner");
            Chest.SetTileEntity("Chest");
            Furnace.SetTileEntity("Furnace");
            BurningFurnace.SetTileEntity("Furnace");
            SignPost.SetTileEntity("Sign");
            WallSign.SetTileEntity("Sign");
            EnchantmentTable.SetTileEntity("EnchantTable");
            BrewingStand.SetTileEntity("Cauldron");
            EndPortal.SetTileEntity("Airportal");
            EnderChest.SetTileEntity("EnderChest");
            CommandBlock.SetTileEntity("Control");
            BeaconBlock.SetTileEntity("Beacon");

            // Set Data Limits

            Wood.SetDataLimits(0, 2, 0);
            Leaves.SetDataLimits(0, 2, 0);
            Jukebox.SetDataLimits(0, 2, 0);
            Sapling.SetDataLimits(0, 15, 0);
            Cactus.SetDataLimits(0, 15, 0);
            SugarCane.SetDataLimits(0, 15, 0);
            Water.SetDataLimits(0, 7, 0x8);
            Lava.SetDataLimits(0, 7, 0x8);
            TallGrass.SetDataLimits(0, 2, 0);
            Crops.SetDataLimits(0, 7, 0);
            PoweredRail.SetDataLimits(0, 5, 0x8);
            DetectorRail.SetDataLimits(0, 5, 0x8);
            StickyPiston.SetDataLimits(1, 5, 0x8);
            Piston.SetDataLimits(1, 5, 0x8);
            PistonHead.SetDataLimits(1, 5, 0x8);
            Wool.SetDataLimits(0, 15, 0);
            Torch.SetDataLimits(1, 5, 0);
            RedstoneTorch.SetDataLimits(0, 5, 0);
            RedstoneTorchOn.SetDataLimits(0, 5, 0);
            Rails.SetDataLimits(0, 9, 0);
            Ladder.SetDataLimits(2, 5, 0);
            WoodStairs.SetDataLimits(0, 3, 0x4);
            CobbleStairs.SetDataLimits(0, 3, 0x4);
            Lever.SetDataLimits(0, 6, 0x8);
            WoodDoor.SetDataLimits(0, 3, 0xC);
            IronDoor.SetDataLimits(0, 3, 0xC);
            StoneButton.SetDataLimits(1, 4, 0x8);
            Snow.SetDataLimits(0, 7, 0);
            SignPost.SetDataLimits(0, 15, 0);
            WallSign.SetDataLimits(2, 5, 0);
            Furnace.SetDataLimits(2, 5, 0);
            BurningFurnace.SetDataLimits(2, 5, 0);
            Dispenser.SetDataLimits(2, 5, 0);
            Pumpkin.SetDataLimits(0, 3, 0);
            JackOLantern.SetDataLimits(0, 3, 0);
            StonePlate.SetDataLimits(0, 0, 0x1);
            WoodPlate.SetDataLimits(0, 0, 0x1);
            StoneSlab.SetDataLimits(0, 5, 0);
            DoubleStoneSlab.SetDataLimits(0, 5, 0x8);
            Cactus.SetDataLimits(0, 5, 0);
            Bed.SetDataLimits(0, 3, 0x8);
            RedstoneRepeater.SetDataLimits(0, 0, 0xF);
            RedstoneRepeaterOn.SetDataLimits(0, 0, 0xF);
            Trapdoor.SetDataLimits(0, 3, 0x4);
            StoneBrick.SetDataLimits(0, 2, 0);
            HugeRedMushroom.SetDataLimits(0, 10, 0);
            HugeBrownMushroom.SetDataLimits(0, 10, 0);
            Vines.SetDataLimits(0, 0, 0xF);
            FenceGate.SetDataLimits(0, 3, 0x4);
            SilverfishStone.SetDataLimits(0, 2, 0);
            BrewingStand.SetDataLimits(0, 0, 0x7);
            Cauldron.SetDataLimits(0, 3, 0);
            EndPortalFrame.SetDataLimits(0, 0, 0x7);
            WoodSlab.SetDataLimits(0, 5, 0);
            DoubleWoodSlab.SetDataLimits(0, 5, 0x8);
            TripwireHook.SetDataLimits(0, 3, 0xC);
            Tripwire.SetDataLimits(0, 0, 0x5);
            Anvil.SetDataLimits(0, 0, 0xD);
        }
    }

    /// <summary>
    /// An extended <see cref="BlockInfo"/> that includes <see cref="TileEntity"/> information.
    /// </summary>
    public class BlockInfoEx : BlockInfo
    {
        private string _tileEntityName;

        /// <summary>
        /// Gets the name of the <see cref="TileEntity"/> type associated with this block type.
        /// </summary>
        public string TileEntityName
        {
            get { return _tileEntityName; }
        }

        internal BlockInfoEx (int id) : base(id) { }

        /// <summary>
        /// Constructs a new <see cref="BlockInfoEx"/> with a given block id and name.
        /// </summary>
        /// <param name="id">The id of the block type.</param>
        /// <param name="name">The name of the block type.</param>
        public BlockInfoEx (int id, string name) : base(id, name) { }

        /// <summary>
        /// Sets the name of the <see cref="TileEntity"/> type associated with this block type.
        /// </summary>
        /// <param name="name">The name of a registered <see cref="TileEntity"/> type.</param>
        /// <returns>The object instance used to invoke this method.</returns>
        /// <seealso cref="TileEntityFactory"/>
        public BlockInfo SetTileEntity (string name) {
            _tileEntityName = name;
            return this;
        }
    }
}
