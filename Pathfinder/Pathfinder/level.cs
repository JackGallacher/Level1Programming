﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.IO;

namespace Pathfinder
{
    //loads a map from an ascii text file
    class Level
    {
        private const int gridSize = 160; //set the map grid size
        public int [,] tiles; //a 2d array of 0's and 1's: 0 = free cell, 1 = blocked cell

        //pathfinding algorithms.
        public Dijkstra dijkstra;
        public AStar astar;
        public Scentmap scentmap;

        //check algorithm builds
        public bool build_astar = false;
        public bool build_dijkstra = false;
        public bool build_astar_unoptomised = false;

        public bool astar_chosen = false;
        public bool dijkstra_chosen = false;
        public bool scentmap_chosen = false;
        public bool astar_unoptomised_chosen = false;

        //choose astar heuristic.
        public bool manhatten = false;
        public bool diagonal = false;
        public bool euclidian = false;

        public int path_count = 0;

        //constructor initialises the grid array
        public Level()
        {
            path_count = new int();
            dijkstra = new Dijkstra();
            astar = new AStar();
            scentmap = new Scentmap();
            tiles = new int[gridSize, gridSize];
            for (int i = 0; i < gridSize; i++)
                for (int j = 0; j < gridSize; j++)
                    tiles[i,j] = 0;
        }

        //accessors
        public int GridSize
        {
            get { return gridSize; }
        }

        //validates a grid position (passed as a 2d vector): returns false if position is blocked, or if x or y 
        //positions are greater than grid size, or less than 0
        public bool ValidPosition(Coord2 pos)
        {
            if (pos.X < 0) return false;
            if (pos.X >= gridSize) return false;
            if (pos.Y < 0) return false;
            if (pos.Y >= gridSize) return false;
            return (tiles[pos.X,pos.Y] == 0);
        }

        //loads the map from a text file
        public void Loadmap(string path)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                //Debug.Assert(line.Length == gridSize, "loaded map string line width must be 30");
                Debug.Assert(line.Length == gridSize, String.Format("loaded map string line width must be {0}.", gridSize));
                while (line != null)
                {
                    lines.Add(line);
                    line = reader.ReadLine();
                }
            }
            Debug.Assert(lines.Count == gridSize, String.Format("loaded map string must have {0} lines.",gridSize));

            // Loop over every tile position,
            for (int y = 0; y < gridSize; ++y)
            {
                for (int x = 0; x < gridSize; ++x)
                {
                    // to load each tile.
                    char tileType = lines[y][x];
                    if (tileType == '.') tiles[x, y] = 0;
                    else tiles[x, y] = 1;
                }
            }
        }
    }
}
