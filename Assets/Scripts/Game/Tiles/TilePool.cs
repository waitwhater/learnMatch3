using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts.Game.Tiles
{
    public class TilePool
    {
        private GameObject _tilePrefab;
        private List<Tile> _tilePool = new List<Tile>();
        private IObjectResolver _objectResolver;

        public TilePool(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        private Tile CreateTile(Vector3 position, Transform parent)
        {
            var tilePrefab = _objectResolver.Instantiate(_tilePrefab, position, Quaternion.identity, parent);
            var tile = tilePrefab.GetComponent<Tile>();
        }
    }
}
