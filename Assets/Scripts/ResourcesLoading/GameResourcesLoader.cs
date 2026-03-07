using Assets.Scripts.Game.Tiles;
using System.Collections;
using UnityEngine;
using UnityEngine.TerrainUtils;

namespace Assets.Scripts.ResourcesLoading
{
    public class GameResourcesLoader : MonoBehaviour
    {

        [SerializeField] private GameObject _tilePrefab;
        [SerializeField] private TileSetConfig _tileSetConfig;

        public GameObject TilePrefab => _tilePrefab;
        public TileSetConfig TileSetConfig => _tileSetConfig;
    }
}