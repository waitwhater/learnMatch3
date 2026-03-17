using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Tiles
{
    public class BlankTilesSetup : MonoBehaviour
    {
        [SerializeField] private List<BlankTile> _blankTilesLayout;
        public bool[,] blanks { get; private set; }

        public void SetupBlanks(int width, int height)
        {
            blanks = new bool[width, height];
            for(int i = 0; i < _blankTilesLayout.Count; i++)
                blanks[_blankTilesLayout[i].XPosition, _blankTilesLayout[i].YPosition] = true;
        }
    }
}