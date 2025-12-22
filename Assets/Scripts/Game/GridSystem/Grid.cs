using Assets.Scripts.Game.Tiles;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Game.GridSystem
{
    public class Grid
    {
        public Tile[,] GameGrid { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Vector2Int CurrentPosition { get; private set; }
        public Vector2Int TargetPosition { get; private set; }

        /*public Grid(int height, int width)
        {
            Debug.Log("public Grid");
            Height = height;
            Width = width;
            GameGrid = new Tile[Height, Width];
        }*/

        public void SetGrid(int height, int width)
        {
            Height = height;
            Width = width;
            GameGrid = new Tile[Height, Width];
        }

        public Vector2Int SetCurrentPosition(Vector2Int position) => CurrentPosition = position;
        public Vector2Int SetTargetPosition(Vector2Int position) => TargetPosition = position;

        public Vector3 GridToWorld(int x, int y) => new Vector3(x, y, 0);

        public Vector2Int WorldToGrid(Vector3 worldPosition)
        {
            var x = Mathf.FloorToInt(worldPosition.x);
            var y = Mathf.FloorToInt(worldPosition.y);
            return new Vector2Int(x, y);
        }

        public bool IsValidPosition (int x, int y)
        {
            return x >=0 
                && y >=0 
                && x < Height 
                && y < Width;
        }

        public void SetValue(int x, int y, Tile tile)
        { 
            if (IsValidPosition(x, y))
                GameGrid[x, y] = tile;
        }

        public void SetValue(Vector3 worldPosition, Tile tile)
        {
            var worldPos = WorldToGrid(worldPosition);
            SetValue(worldPos.x, worldPos.y, tile);
        }

        public Tile GetValue(int x, int y)
        {
            if(IsValidPosition(x, y))
                return GameGrid[x, y];
            return default;
        }

        public Tile GetValue(Vector3 worldPosition)
        {
            var worldPos = WorldToGrid(worldPosition);
            return GetValue(worldPos.x, worldPos.y);
        }
    }
}
