using System;
using UnityEngine;

public class BodyPartController : MonoBehaviour
{
    public float roomRadius = 12;
    private RelativeJoint2D RJ = null;
    Vector2 relativeJointPosition = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<RelativeJoint2D>() != null)
        {
            RJ = GetComponent<RelativeJoint2D>();
            relativeJointPosition = RJ.linearOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.magnitude > roomRadius)
        {
            transform.position = Vector3.zero;
        }
        if (RJ != null)
        {
            if (RJ.linearOffset != relativeJointPosition)
            {
                RJ.linearOffset = relativeJointPosition;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactForce = collision.relativeVelocity.magnitude;

        if (collision.relativeVelocity.magnitude > 2
            && collision.gameObject.tag != "BodyPart"
            && collision.gameObject.tag != "Player")
        {
            int soundID = 0;
            if (collision.gameObject.tag == "Damage")
                soundID = Int32.Parse(collision.gameObject.name.Substring(0, 2));
            //Debug.Log(collision.gameObject.name.Substring(0, 2));
            
            transform.parent.gameObject.SendMessage("BodyCollision", impactForce.ToString() + " " + soundID.ToString());
        }
    }
}
