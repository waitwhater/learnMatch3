using Assets.Scripts.Game.Board;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GameStateMachine.States
{
    internal class PrepareState : IState
    {
        private readonly IStateSwitcher _stateSwitcher;
        private GameBoard _gameBoard;

        public PrepareState(IStateSwitcher stateSwitcher, GameBoard gameBoard)
        {
            _stateSwitcher = stateSwitcher;
            _gameBoard = gameBoard;
        }

        public void Enter()
        {
            _gameBoard.CreateBoard();
        }

        public void Exit()
        {
            Debug.Log("Game was started");
        }
    }
}
