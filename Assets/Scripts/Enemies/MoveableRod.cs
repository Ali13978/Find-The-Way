using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableRod : MonoBehaviour
{
    [SerializeField] Transform LeftLimit;
    [SerializeField] Transform RightLimit;
    [SerializeField] float MoveSpeed;
    Transform Target;
    private void Update() 
    {
        Move();
        if(!InsideOfLimits())
        {
            SelectTarget();
        }
    }

    private void Start() {
        Target = LeftLimit;
    }
    private void Move()
    {
        Vector2 TargetPos = new Vector2(Target.position.x ,transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position , TargetPos , MoveSpeed * Time.deltaTime);
    }

    private bool InsideOfLimits()
    {
        return transform.position.x > LeftLimit.position.x && transform.position.x < RightLimit.position.x;
    }
    public void SelectTarget()
    {
        float DistanceToLeft = Vector2.Distance(transform.position , LeftLimit.position);
        float DistanceToRight = Vector2.Distance(transform.position , RightLimit.position);
        if(DistanceToLeft > DistanceToRight)
        {
            Target = LeftLimit;
        }
        else
        {
            Target = RightLimit;
        }
    }
}
