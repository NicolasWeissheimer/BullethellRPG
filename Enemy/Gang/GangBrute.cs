using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GangBrute : Enemy
{
    public StateMachine stateMachine;
    public Transform[] scoutAreas;
    public bool isRandom;
    [HideInInspector]
    public int areaID;
    public float delay;
    public float detectDelay;
    public PlayerDetector playerDetector;
    [HideInInspector]
    public GameObject helpCaller;
    public GameObject helpCall;
    public float helpCallLifetime;
    public float helpCallRadius;
    public float wanderRange;
    public float wanderTimer;
    private float hpTreshold;
    public  bool helping;
    private void Awake()
    {
        Vector2 startingPos = new Vector2(transform.position.x, transform.position.y);
        helping = false;
        hpTreshold = maxHp * 0.2f;
        enemyAttack.GetComponent<EnemyAttack>().player = player.transform;
        destination = scoutAreas[0];
        playerDetector.delay = detectDelay;

        stateMachine = new StateMachine();
        var scoutArea = new ScoutArea(this);
        var attackPlayer = new AttackPlayer(this);
        var help = new Help(this, helpCaller);
        var wander = new Wander(this, startingPos, wanderTimer, wanderRange);

        At(wander, attackPlayer, PlayerDetected());
        At(scoutArea, attackPlayer, PlayerDetected());
        At(attackPlayer, scoutArea, PlayerLost());
        At(help, scoutArea, HelpLost());
        At(scoutArea, wander, Wandering());

        stateMachine.AddAnyTransition(scoutArea, () => playerDetector.detectedPlayer == false && scoutAreas[0] != null && helping == false);
        stateMachine.AddAnyTransition(wander, () => playerDetector.detectedPlayer == false && scoutAreas[0] == null && helping == false);
    }

    private void At(IState to, IState from, Func<bool> condition)
    {
        stateMachine.AddTransition(to, from, condition);
    }

    Func<bool> HelpLost() => () => helping == false;
    Func<bool> PlayerDetected() => () => playerDetector.detectedPlayer == true;
    Func<bool> PlayerLost() => () => playerDetector.detectedPlayer == false;
    Func<bool> Wandering() => () => scoutAreas[0] == null;

    private void Update()
    {
        stateMachine.Tick();

        if (helpCaller == null)
        {
            helping = false;
        }
    }

    public override void OnDamageTaken()
    {
        base.OnDamageTaken();
        if (hp < hpTreshold)
        {
            GameObject call = Instantiate(helpCall, transform.position, transform.rotation);
            var help = call.GetComponent<HelpCall>();
            help.lifeTime = helpCallLifetime;
            help.caller = gameObject;
            help.radius.radius = helpCallRadius;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDest"))
        {
            StartCoroutine(ChangeRoute());
        }

        if (collision.CompareTag("HelpCall"))
        {
            helpCaller = collision.GetComponent<HelpCall>().caller;
            helping = true;
            var help = new Help(this, helpCaller);
            stateMachine.AddAnyTransition(help, () => helping == true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            helping = false;
        }        
    }

    private IEnumerator ChangeRoute()
    {
        if (isRandom == false)
        {
            if (areaID < (scoutAreas.Length - 1))
            {
                areaID++;
            }

            else
            {
                areaID = 0;
            }
        }

        else
        {
            areaID = UnityEngine.Random.Range(0, (scoutAreas.Length - 1));
        }

        yield return new WaitForSeconds(delay);

        destination = scoutAreas[areaID];
    }
}
