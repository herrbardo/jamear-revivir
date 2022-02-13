using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float DistanceToPursuitPlayer;
    [SerializeField] Enemy enemyManager;

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        SearchPlayer();
    }

    void SearchPlayer()
    {
        if(CheckForPlayer(-Vector2.right))
            enemyManager.MoveLeft();
        else if(CheckForPlayer(Vector2.right))        
            enemyManager.MoveRight();
        else
            enemyManager.Stop();
    }

    bool CheckForPlayer(Vector2 direction)
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(direction) * DistanceToPursuitPlayer, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(direction), DistanceToPursuitPlayer);

        return hit.collider != null && hit.collider.gameObject.tag == "Player";
    }
}


