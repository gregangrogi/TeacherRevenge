using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float flySpeed;
    public float damage;
    public float lifeTime;
    public GameObject particle;
    public Vector3 rotationOffset;
    private Rigidbody2D rb;
    private Transform Doll;
    private bool live = true;
    void Start()
    {
        Doll = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (Doll.position - transform.position).normalized*flySpeed;
        transform.Rotate(0, 0, math.degrees(math.atan2(rb.velocity.y, rb.velocity.x)));
    }

    // Update is called once per frame
    void Update()
    {
        if (!live)
            lifeTime -= Time.deltaTime;        
        if(lifeTime<0)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "BodyPart" || collision.transform.tag == "Player")
        {
            if (live)
            {
                transform.parent = collision.transform;
                GameObject hitParticle = Instantiate(particle);
                hitParticle.transform.position = (collision.contacts[0].point);
                hitParticle.transform.LookAt(transform.position);
                hitParticle.transform.Rotate(0, 0, 180);
                hitParticle.transform.parent = transform;
                Destroy(GetComponent<Rigidbody2D>());
                live = false;
            }
        }        
    }
}
