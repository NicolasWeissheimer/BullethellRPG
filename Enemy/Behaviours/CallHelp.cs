using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class CallHelp : IState
{
    private readonly Enemy enemy;
    private readonly GameObject helpCall;
    public void Tick()
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, -1 * enemy.moveSpeed * Time.deltaTime);
    }

    public CallHelp(Enemy _enemy, GameObject _helpCall)
    {
        enemy = _enemy;
        helpCall = _helpCall;
    }

    public void OnEnter() 
    {

    }
    public void OnExit() { }
}
