using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitePlayer : IState
{
    private readonly Enemy enemy;
    public void Tick()
    {
        if (Vector2.Distance(enemy.transform.position, enemy.player.transform.position) > enemy.distance)
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, enemy.moveSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(enemy.transform.position, enemy.player.transform.position) < enemy.distance)
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.player.transform.position, -1 * enemy.moveSpeed * Time.deltaTime);
        }
        //Debug.Log("olhga a flexa");
    }

    public KitePlayer(Enemy _enemy)
    {
        enemy = _enemy;
    }

    public void OnEnter()
    {
        enemy.enemyAttack.SetActive(true);
    }
    public void OnExit()
    {
        enemy.enemyAttack.SetActive(false);
    }
}
