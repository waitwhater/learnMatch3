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

namespace Assets.Scripts.DI
{
    internal class GameScope : LifetimeScope
    {
        [SerializeField] private GameBoard _gameBoard;
        [SerializeField] private GameResourcesLoader _loader;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Configure");
            builder.RegisterInstance(_gameBoard);
            builder.RegisterInstance(_loader);
            //я не знаю зачем Register
            builder.Register<Game.GridSystem.Grid>(Lifetime.Singleton);
            builder.Register<SetupCamera>(Lifetime.Singleton);
        }
    }
}
