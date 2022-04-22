using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletDecal;
    private float speed = 50f;
    private float timeToDestry = 3f;
    public Vector3 target { get; set; } 
    public bool hit { get; set; }


    private void OnEnable()
    {
        Destroy(this.gameObject, timeToDestry);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        // hit: if distance between bullet and target is less than a small threshhold, and we're not hitting anything
        if(!hit && Vector3.Distance(transform.position, target) < 0.01f)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnenmyDeath>().life--;

        }


        ContactPoint contact = other.GetContact(0);
        // spawn bullet hole
        GameObject.Instantiate(bulletDecal, contact.point + contact.normal*.0001f, Quaternion.LookRotation(contact.normal));
        Destroy(this.gameObject);
    }
}
