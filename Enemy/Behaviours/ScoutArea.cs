using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ScoutArea : IState
{
    private readonly Enemy enemy;
    public void Tick()
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.destination.position, enemy.moveSpeed * Time.deltaTime);
        //Debug.Log("ovo anda ai kkk");
    }

    public ScoutArea(Enemy _enemy)
    {
        enemy = _enemy;
    }

    public void OnEnter() { }
    public void OnExit() { }
}
