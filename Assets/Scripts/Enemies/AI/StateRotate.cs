using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRotate : IState
{
    private CharacterBaseControl m_Control;

    public StateRotate(GameObject o_player, CharacterBaseControl control)
    {

        m_Control = control;
    }

    public override void Enter()
    {

    }

    public override void Execute()
    {

    }
}
