using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    public Transform target;
    private float smoothTime = 0f;
    private Vector3 velocity = Vector3.zero;
    public BlastOffScript blastoffscript;
    private bool isInBattle = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInBattle == false)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
    public void ChangeIsInBattle()
    {
        isInBattle = !isInBattle;        
    }
    public bool GetIsInBattle()
    {
        return isInBattle;
    }
}
