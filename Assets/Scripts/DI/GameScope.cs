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

namespace Assets.Scripts.DI
{
    internal class GameScope : LifetimeScope
    {
        [SerializeField] private GameBoard _gameBoard;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Configure");
            //builder.RegisterInstance(_gameBoard);
            builder.Register<Game.GridSystem.Grid>(Lifetime.Singleton);
            builder.Register<SetupCamera>(Lifetime.Singleton);
        }

        /*protected override void Awake()
        {
            base.Awake();
            var controller = Instantiate(_gameBoard);
        }*/
        
    }
}
