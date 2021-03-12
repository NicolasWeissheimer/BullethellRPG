using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Wander : IState
{
    private readonly Enemy enemy;
    private readonly Vector2 initialPoint;
    private float timer;
    private float elapsed;
    private readonly float range;
    private Vector2 target;
    public void Tick()
    {
        elapsed += Time.deltaTime;

        if(elapsed >= timer)
        {
            elapsed = 0;
            NewTarget();
        }
       
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, target, enemy.moveSpeed * Time.deltaTime);
        //Debug.Log("wherevi");
    }
    public Wander(Enemy _enemy, Vector2 _initialPoint, float _timer, float _range)
    {
        enemy = _enemy;
        initialPoint = _initialPoint;
        timer = _timer;
        range = _range;
    }

    void NewTarget()
    {
        float myX = initialPoint.x;
        float myY = initialPoint.y;

        float posX = Random.Range(myX - range, myX + range);
        float posY = Random.Range(myY - range, myY + range);

        target = new Vector2(posX, posY);
    }

    public void OnEnter()
    {
        NewTarget();
    }
    public void OnExit() { }
}
