using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRagDollScript : MonoBehaviour
{
    private Vector3 position;
    public Collider2D targetDoll;
    public bool mouseDown = false;
    public float maxSpeed;
    public int dollCollision= 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        position =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z= 0;
        transform.position = position;
        if (Input.GetMouseButtonDown(0))
            mouseDown= true;
        if (targetDoll != null)
        {
            targetDoll.attachedRigidbody.MovePosition(transform.position);
            if (targetDoll.attachedRigidbody.velocity.magnitude > maxSpeed)
            {
                targetDoll.attachedRigidbody.velocity = targetDoll.attachedRigidbody.velocity.normalized * maxSpeed;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            targetDoll = null;
            mouseDown = false;
            
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "BodyPart" || collision.transform.tag == "Player")
            dollCollision ++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "BodyPart" || collision.transform.tag == "Player")
            dollCollision --;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (mouseDown && (collision.transform.tag == "BodyPart" || collision.transform.tag == "Player"))
        {
            targetDoll= collision;            
            
        }
    }
}
