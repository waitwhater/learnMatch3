using Assets.Scripts.Game.Tiles;
using Assets.Scripts.Game.Utils;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Game.Board
{
    public class GameBoard : MonoBehaviour
    {

        [SerializeField] private TileConfig _tileConfig;
        private readonly List<Tile> _tilesToRefill = new (); 
        private GridSystem.Grid _grid;
        private TilePool _tilePool;
        private SetupCamera _setupCamera;

        void Start()
        {
            Debug.Log("Start");
            CreateBoard();
            _setupCamera.SetCamera(_grid.Width, _grid.Height, false);
        }

        public void CreateBoard ()
        {
            _grid.SetGrid(10, 10);
            FillBoard();
        }

        private void FillBoard() 
        {
            for (int x = 0; x < _grid.Width; x++) 
                for (int y = 0; y < _grid.Height; y++)
                {
                    if (_grid.GetValue(x, y) != null)
                        continue;
                    var tile = _tilePool.GetTile(_grid.GridToWorld(x, y), transform);
                    _grid.SetValue(x, y, tile);
                    tile.gameObject.SetActive(true);
                    _tilesToRefill.Add(tile);
                }
        } 

        [Inject] 
        public void Construct (GridSystem.Grid grid, SetupCamera setupCamera, TilePool pool)
        {
            Debug.Log("Inject");
            _grid = grid;
            _setupCamera = setupCamera;
            _tilePool = pool;
        }
    }
}