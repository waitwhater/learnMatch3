using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Game.Tiles
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class Tile : MonoBehaviour
	{
		public TileConfig TileConfig { get; private set; }
		public bool IsMatched;
		public bool IsInteractable;

		public void SetTileConfig (TileConfig tileConfig)
		{
			TileConfig = tileConfig;
			IsMatched = false;
			IsInteractable = tileConfig.IsInteractable;
			GetComponent<SpriteRenderer>().sprite = tileConfig.Sprite;
		}

        public bool SetMatch(bool value) => IsMatched = value;
    }
}