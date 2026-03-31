using Assets.Scripts.Game.Tiles;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Game.Animations
{
    public interface IAnimation
    {
        UniTask Reveal(GameObject target, float delay);
        UniTask HideTile(GameObject target);
        void DoPunchAnimate(GameObject target, Vector3 scale, float duration);
        void MoveUI (RectTransform target, Vector3 position, float duration, Ease ease);
        void AnimateTile(Tile tile, float value);
        void MoveTile(Tile tile, Vector3 position, Ease ease);
    }
}
