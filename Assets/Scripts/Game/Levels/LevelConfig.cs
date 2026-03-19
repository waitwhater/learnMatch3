using Assets.Scripts.Game.Tiles;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Game.Levels
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [Header("Grid")]
        [SerializeField] private List<BlankTile> _blankTilesLayout;
        [SerializeField] private int _height;
        [SerializeField] private int _width;

        [Header("Level")]
        [SerializeField] private int _goalScore;
        [SerializeField] private int _moves;
        [SerializeField] private int _levelNumber;
        [SerializeField] private TileSets _tileSets;

        public int Height => _height;
        public int Width => _width;
        public int GoalScore => _goalScore;
        public int Moves => _moves;
        public int LevelNumber => _levelNumber;
        public TileSets TileSets => _tileSets;
        internal List<BlankTile> BlankTilesLayout => _blankTilesLayout;
    }

    public enum TileSets
    {
        Kingdom,
        Gem
    }
}