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
        [SerializeField] private GameObject _tilePrefab;
        [SerializeField] private TileConfig _tileConfig;
        private readonly List<Tile> _tilesToRefill = new (); 
        private GridSystem.Grid _grid;
        private SetupCamera _setupCamera;

        void Start()
        {
            Debug.Log("Start");
            CreateBoard();
            _setupCamera.SetCamera(_grid.Width, _grid.Height, false);
        }

        public void CreateBoard ()
        {
            FillBoard();
        }

        private void FillBoard() 
        {
            //_grid = new GridSystem.Grid(10, 10); //временное решение для создания сетки
            _grid.SetGrid(10, 10);

            for (int x = 0; x < _grid.Width; x++) 
                for (int y = 0; y < _grid.Height; y++)
                {
                    if (_grid.GetValue(x, y) != null)
                        continue;
                    var tile = Instantiate(_tilePrefab, transform);
                    tile.transform.position = _grid.GridToWorld(x, y);
                    var tileComponent = tile.GetComponent<Tile>();
                    tileComponent.SetTileConfig(_tileConfig);
                    _grid.SetValue(x, y, tileComponent);
                }
        } 

        [Inject] 
        public void Construct (GridSystem.Grid grid, SetupCamera setupCamera)
        {
            Debug.Log("Inject");
            _grid = grid;
            _setupCamera = setupCamera;
        }
    }
}