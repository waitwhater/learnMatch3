using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.GameStateMachine
{
    internal interface IState
    {
        void Enter();
        void Exit();
    }
}
