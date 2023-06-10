using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IEnemyState
{

    StatePatternEnemy enemy;

    private float attackTimer;

    public AttackState(StatePatternEnemy statePatternEnemy)//kun statepatternenemyn new patrolstate(); rivi ajetaan ni tää ajetaan
    {
        enemy = statePatternEnemy; //enemy muuttuja on koko StatePatternEnemy -luokka. Näin päästään käsiksi StatePatternEnemyn muuttujiin ja funktioihin.
    }
    // Start is called before the first frame update
    public void ToPatrolState()
    {

    }

    public void ToAttackState()
    {
        
    }

    public void ToTrackingState()
    {
        enemy.currentState = enemy.trackingState;
         attackTimer = 0f;
    }

    public void ToAlertState()
    {
        enemy.currentState = enemy.alertState;
         attackTimer = 0f;
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void OnCollisionEnter(Collision other) 
    {
        
    }


    public void ToChaseState()
    {
        attackTimer = 0f;
        enemy.currentState = enemy.chaseState;
    }

    public void UpdateState()
    {
        Attack();
        Look();
    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;

        Debug.Log("attacking");
        enemy.navMeshAgent.speed = 0f;

        if (attackTimer > 1f)
        {
            enemy.enemysCollider.enabled = true;
            ToChaseState();
        }

    }

    private void Look()
    {
        Vector3 enemyToTarget = enemy.chaseTarget.position - enemy.eye.position;//suunta silmästä pelaajaan

        Debug.DrawRay(enemy.eye.position, enemyToTarget, Color.yellow);

        //näkösäde on raycast
        RaycastHit hit; //info mihin raycast osuu

        if (Physics.Raycast(enemy.eye.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            //toteutuu jos säde osuu pelaajaan
            //jos säde osuu pelaajaan, vihu tunnistaa kohteen ja lähtee jahtaamaan
            Debug.Log("pelaaja on näkyvissä");
            enemy.chaseTarget = hit.transform;
            enemy.lastKnownPlayerPosition = enemy.chaseTarget.position;
        }
        else
        {
            Debug.Log("Pelaaja hävisi");
            ToTrackingState();
        }

    }

    IEnumerator PreventAnotherAttack()
    {
        yield return new WaitForSeconds(1.05f);
        {
            Debug.Log("COROUTINE STARTED");
            enemy.navMeshAgent.speed = 5f;
            enemy.enemysCollider.enabled = true;

        }
    }
}
