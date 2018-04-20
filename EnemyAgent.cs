using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : Agent
{
    Rigidbody2D enemyRGB2D;

    private void Start()
    {
        enemyRGB2D = GetComponent<Rigidbody2D>();
    }

    public override void AgentReset()
    {
        // reset position and health
    }
}
