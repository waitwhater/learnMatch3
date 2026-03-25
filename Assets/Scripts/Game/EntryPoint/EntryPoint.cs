using Assets.Scripts.Game.Board;
using Assets.Scripts.GameStateMachine;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameBoard _gameBoard;
        private StateMachine _stateMachine;

        // Use this for initialization
        void Start()
        {
            Debug.Log("Start");
            _stateMachine = new StateMachine(_gameBoard);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}