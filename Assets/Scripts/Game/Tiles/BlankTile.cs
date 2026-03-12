using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Tiles
{
    [Serializable]
    internal class BlankTile
    {
        [SerializeField] private int xPosition;
        [SerializeField] private int yPosition;

        public int XPosition => xPosition;
        public int YPosition => yPosition;
    }
}
