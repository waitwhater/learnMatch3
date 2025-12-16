using Assets.Scripts.Game.Tiles;
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

        void Start()
        {
            CreateBoard();
        }

        public void CreateBoard ()
        {
            FillBoard();
        }

        private void FillBoard() 
        {
            _grid = new GridSystem.Grid(10, 10); //временное решение для создания сетки

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

        [Inject] private void Construct (GridSystem.Grid grid)
        {
            _grid = grid;
        }
        /*
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        */
    }
}