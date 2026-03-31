using Assets.Scripts.Game.Board;
using Assets.Scripts.Game.GridSystem;
using Assets.Scripts.Game.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Assets.Scripts.ResourcesLoading;
using Assets.Scripts.Game.Tiles;
using Assets.Scripts.Game.Animations;

namespace Assets.Scripts.DI
{
    internal class GameScope : LifetimeScope
    {
        [SerializeField] private GameBoard _gameBoard;
        [SerializeField] private GameResourcesLoader _loader;

        protected override void Configure(IContainerBuilder builder)
        {
            //RegisterInstance - это внедрение конкретного экземпляра класса, который мы как-то получаем извне, чаще всего движком юнити (например, создан на сцене)
            Debug.Log("Configure");
            builder.RegisterInstance(_gameBoard);
            builder.RegisterInstance(_loader);
            //Register - это внедрение нового экземпляра класса (контейнер создает его сам). От Lifetime зависит поведение внедрение, когда он будет создаваться новый, когда уничтожится и т.д.
            builder.Register<IAnimation, AnimationManager>(Lifetime.Singleton);
            builder.Register<Game.GridSystem.Grid>(Lifetime.Singleton);
            builder.Register<SetupCamera>(Lifetime.Singleton);
            builder.Register<TilePool>(Lifetime.Singleton);
            builder.Register<GameDebug>(Lifetime.Singleton);
            builder.Register<BlankTilesSetup>(Lifetime.Singleton);
        }
    }
}
