using UnityEngine;
using UnityEditor;

namespace Assets.Scripts.Game.Tiles
{
	public enum TileKind 
	{
		Normal, 
		Blank, 
		Jelly
	}

	[CreateAssetMenu(fileName = "TileConfig", menuName = "Config/TileConfig")]
	public class TileConfig : ScriptableObject
	{
        [SerializeField] private Sprite _sprite;
		[SerializeField] private TileKind _tileKind;
		[SerializeField] private bool _isInteractable;

        public Sprite Sprite { get => _sprite; }
        public TileKind TileKind { get => _tileKind; }
        public bool IsInteractable { get => _isInteractable; }
    }
}