using Assets.Scripts.Game.Tiles;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Game.Animations
{
    internal class AnimationManager : IAnimation, IDisposable
    {
        private CancellationTokenSource _cts;

        public void Dispose()
        {
            _cts?.Dispose();
        }


        public void AnimateTile(Tile tile, float value)
        {
            tile.transform.DOScale(value, 0.3f).SetEase(Ease.OutCubic);
        }

        public void DoPunchAnimate(GameObject target, Vector3 scale, float duration)
        {
            target.transform.DOPunchScale(scale, duration, 1, 0.5f); // я не понимаю, почему везде есть cts, а тут - нет
        }

        public async UniTask HideTile(GameObject target)
        {
            _cts = new CancellationTokenSource();
            target.transform.DOScale(Vector3.zero, 0.05f).SetEase(Ease.OutBounce); // я не понимаю, почему в курсе нет ожидания этой анимации
            target.SetActive(false);
            target.transform.localScale = Vector3.one;
            await UniTask.Delay(TimeSpan.FromMinutes(0.05f), _cts.IsCancellationRequested); //я не понимаю, зачем в курсе ожидание какого-то времени
            _cts.Cancel();
        }

        public void MoveTile(Tile tile, Vector3 position, Ease ease)
        {
            tile.transform.DOLocalMove(position, 0.2f).SetEase(ease);
        }

        public void MoveUI(RectTransform target, Vector3 position, float duration, Ease ease)
        {
            target.DOAnchorPos(position, duration).SetEase(ease);
        }

        public async UniTask Reveal(GameObject target, float delay)
        {
            _cts = new CancellationTokenSource();
            target.transform.localScale = Vector3.one * 0.1f;
            await target.transform.DOScale(Vector3.one, delay).SetEase(Ease.OutBounce);
            _cts.Cancel();
        }
    }
}
