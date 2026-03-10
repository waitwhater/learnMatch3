using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Game.GridSystem
{
    public class GameDebug
    {
        private Grid _grid;

        public GameDebug(Grid grid)
        {
            _grid = grid;
        }

        public void ShowDebug(Transform parent)
        {
            for(int x = 0; x < _grid.Width; x++)
                for(int y = 0; y < _grid.Height; y++)
                {
                    CreateDebugText(parent, $"{x}, {y}",
                        _grid.GridToWorld(x, y));
                }
        }

        public void CreateDebugText(Transform parent, string text, Vector3 position)
        {
            var debugText = new GameObject("debugText", typeof(TextMeshPro));
            debugText.transform.SetParent(parent);
            debugText.transform.position = position + new Vector3(0, 0, -1);
            debugText.transform.forward = Vector3.forward;
            var TMP = debugText.GetComponent<TextMeshPro>();
            TMP.text = text;
            TMP.color = Color.white;
            TMP.alignment = TextAlignmentOptions.Center;
            TMP.fontSize = 3f;
        }
    }
}
