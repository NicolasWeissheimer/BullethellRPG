using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Help : IState
{
    private readonly Enemy enemy;
    private readonly GameObject helpCaller;
    public void Tick()
    {
        if(helpCaller != null)
        {
            if (Vector2.Distance(enemy.transform.position, helpCaller.transform.position) > enemy.distance) 
            {
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, helpCaller.transform.position, enemy.moveSpeed * Time.deltaTime);
            }
        }
        //Debug.Log("tasukete");
    }

    public Help(Enemy _enemy, GameObject _helpCaller)
    {
        enemy = _enemy;
        helpCaller = _helpCaller;
    }

    public void OnEnter() { }
    public void OnExit() { }
}
