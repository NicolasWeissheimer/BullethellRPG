using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

internal class Flee : IState
{
    private readonly Enemy enemy;
    public void Tick()
    {
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, -1 * enemy.moveSpeed * Time.deltaTime);
        //Debug.Log("nigerundayo");
    }
    public Flee(Enemy _enemy)
    {
        enemy = _enemy;
    }

    public void OnEnter() 
    { 

    }
    public void OnExit() { }
}
