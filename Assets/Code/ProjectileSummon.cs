using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ProjectileSummon : MonoBehaviour
{
    public GameObject projectile;
    public float summonCD;
    private float timer;
    private MoveRagDollScript mouse;
    private GameObject doll;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        mouse = GameObject.FindGameObjectWithTag("Mouse").GetComponent<MoveRagDollScript>();
        timer = summonCD;
        doll = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (mouse.mouseDown && mouse.targetDoll ==null && mouse.dollCollision == 0)
        {
            transform.position = mouse.transform.position;
            transform.eulerAngles = Vector3.zero;
            transform.Rotate(0, 0, math.degrees(math.atan2(doll.transform.position.y, doll.transform.position.x)));
            rb.velocity = Vector3.zero;
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = summonCD;
                GameObject proj = Instantiate(projectile);
                proj.transform.position = mouse.transform.position;
            }
        }
    }
}
