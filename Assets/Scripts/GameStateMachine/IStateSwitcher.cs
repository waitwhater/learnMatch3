using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.GameStateMachine
{
    internal interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;
    }
}
