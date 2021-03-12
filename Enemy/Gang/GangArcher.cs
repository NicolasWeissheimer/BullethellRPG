using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GangArcher : Enemy
{
    public StateMachine stateMachine;
    public Transform[] scoutAreas;
    [HideInInspector]
    public int areaID;
    public float delay;
    public float detectDelay;
    public PlayerDetector playerDetector;
    public float wanderRange;
    public float wanderTimer;
    private float hpTreshold;
    private bool helping;
    private bool inDanger;
    private void Awake()
    {
        Vector2 startingPos = new Vector2(transform.position.x, transform.position.y);
        inDanger = false;
        helping = false;
        hpTreshold = maxHp * 0.2f;
        enemyAttack.GetComponent<EnemyAttack>().player = player.transform;
        destination = scoutAreas[0];
        playerDetector.delay = detectDelay;

        stateMachine = new StateMachine();
        var scoutArea = new ScoutArea(this);
        var kitePlayer = new KitePlayer(this);
        var flee = new Flee(this);
        var wander = new Wander(this, startingPos, wanderTimer, wanderRange);

        At(wander, kitePlayer, PlayerDetected());
        At(scoutArea, kitePlayer, PlayerDetected());
        At(kitePlayer, scoutArea, PlayerLost());
        At(kitePlayer, flee, InDanger());
        At(scoutArea, flee, InDanger());
        At(wander, flee, InDanger());
        At(scoutArea, wander, Wandering());

        stateMachine.AddAnyTransition(scoutArea, () => playerDetector.detectedPlayer == false && scoutAreas[0] != null && helping == false && inDanger == false);
        stateMachine.AddAnyTransition(wander, () => playerDetector.detectedPlayer == false && scoutAreas[0] == null && helping == false && inDanger == false);
    }

    private void At(IState to, IState from, Func<bool> condition)
    {
        stateMachine.AddTransition(to, from, condition);
    }
    Func<bool> PlayerDetected() => () => playerDetector.detectedPlayer == true;
    Func<bool> PlayerLost() => () => playerDetector.detectedPlayer == false;
    Func<bool> InDanger() => () => hp < hpTreshold;
    Func<bool> Wandering() => () => scoutAreas[0] == null;

    private void Update()
    {
        stateMachine.Tick();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDest"))
        {
            StartCoroutine(ChangeRoute());
        }
    }

    private IEnumerator ChangeRoute()
    {
        if (areaID < (scoutAreas.Length - 1))
        {
            areaID++;
        }

        else
        {
            areaID = 0;
        }

        yield return new WaitForSeconds(delay);

        destination = scoutAreas[areaID];
    }
}
