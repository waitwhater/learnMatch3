using Assets.Scripts.Game.GridSystem;
using Assets.Scripts.Game.Levels;
using Assets.Scripts.Game.Tiles;
using Assets.Scripts.Game.Utils;
using Assets.Scripts.Input;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Game.Board
{
    public class GameBoard : MonoBehaviour
    {

        //[SerializeField] private TileConfig _tileConfig;
        [SerializeField] private bool _isDebugging;
        private readonly List<Tile> _tilesToRefill = new ();
        [SerializeField] private LevelConfig _levelConfig;
        private GridSystem.Grid _grid;
        private TilePool _tilePool;
        private BlankTilesSetup _blankTilesSetup;
        private SetupCamera _setupCamera;
        private GameDebug _gameDebug;
        private InputReader _inputReader;

        void Start()
        {
            Debug.Log("Start");
            _inputReader = new InputReader ();
            _inputReader.EnableInputs(true);
            //_inputReader.Click += ClickTest;
            CreateBoard();
            _blankTilesSetup.SetupBlanks(_levelConfig);
            FillBoard();
            _setupCamera.SetCamera(_grid.Width, _grid.Height, false);
            if (_isDebugging)
                _gameDebug.ShowDebug(transform);
        }

        private void OnDisable()
        {
            //_inputReader.Click -= ClickTest;
        }

        //private void ClickTest() => Debug.Log("Click Test");

        public void CreateBoard ()
        {
            _grid.SetGrid(_levelConfig.Height, _levelConfig.Width);
        }

        private void FillBoard() 
        {
            for (int x = 0; x < _grid.Width; x++) 
                for (int y = 0; y < _grid.Height; y++)
                {

                    if (_grid.GetValue(x, y) != null)
                        continue;

                    Tile tile;

                    if (_blankTilesSetup.blanks[x, y])
                    {
                        tile = _tilePool.CreateBlankTile(_grid.GridToWorld(x, y), transform);
                        _grid.SetValue(x, y, tile);
                    }
                    else
                    {
                        tile = _tilePool.GetTile(_grid.GridToWorld(x, y), transform);
                        _grid.SetValue(x, y, tile);
                        tile.gameObject.SetActive(true);
                        _tilesToRefill.Add(tile);
                    }
                }
        } 

        [Inject] 
        public void Construct (GridSystem.Grid grid, SetupCamera setupCamera, TilePool pool, GameDebug gameDebug, BlankTilesSetup blankTilesSetup)
        {
            Debug.Log("Inject");
            _grid = grid;
            _setupCamera = setupCamera;
            _tilePool = pool;
            _gameDebug = gameDebug;
            _blankTilesSetup = blankTilesSetup;
        }
    }
}