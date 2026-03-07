using Assets.Scripts.ResourcesLoading;
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

        private List<Tile> _tilePool = new List<Tile>();
        private IObjectResolver _objectResolver;
        private GameResourcesLoader _resourcesLoader;

        public TilePool(IObjectResolver objectResolver, GameResourcesLoader resourcesLoader)
        {
            _objectResolver = objectResolver;
            _resourcesLoader = resourcesLoader;
        }

        private Tile CreateTile(Vector3 position, Transform parent)
        {
            var tilePrefab = _objectResolver.Instantiate(_resourcesLoader.TilePrefab, position, Quaternion.identity, parent);
            var tile = tilePrefab.GetComponent<Tile>();
        }
    }
}
