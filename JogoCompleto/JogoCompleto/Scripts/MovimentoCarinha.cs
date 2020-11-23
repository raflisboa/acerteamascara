using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoCarinha : MonoBehaviour
{
    public float accelerationTime = 4f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;
    public Rigidbody2D rb;
    private Vector2 maskposition;
    
    
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        StartCoroutine(AdjustVolume());
        maskposition = new Vector2(-0.13f,0.04f);
 
    }
    
    void Update(){
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0){
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime;
        }
    }
 
    void FixedUpdate(){
        rb.AddForce(movement * maxSpeed);
    }


    IEnumerator AdjustVolume () {
     
     while(true) {
 
         if(GetComponent<AudioSource>().isPlaying) { 
 
            float distanceToTarget = Vector2.Distance(transform.position, maskposition); 
     
            if(distanceToTarget < 1) { distanceToTarget = 1; }
     
            GetComponent<AudioSource>().volume = 1/distanceToTarget; 
     
            yield return new WaitForSeconds(0); 
     
            }
        }
    }
}
