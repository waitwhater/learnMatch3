using Assets.Scripts.Game.Levels;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.Tiles
{
    public class BlankTilesSetup
    {
        public bool[,] blanks { get; private set; }

        public void SetupBlanks(LevelConfig levelConfig)
        {
            blanks = new bool[levelConfig.Width, levelConfig.Height];
            for(int i = 0; i < levelConfig.BlankTilesLayout.Count; i++)
                blanks[levelConfig.BlankTilesLayout[i].XPosition, levelConfig.BlankTilesLayout[i].YPosition] = true;
        }
    }
}