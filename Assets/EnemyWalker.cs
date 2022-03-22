using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : EnemyController
{
  public float speed = 1f;
  private Transform transform;
  private float randX;
  private float randZ;
  private Vector3 newPos;

  private float startTime;
  private float jouneyLength;
    
  void Awake(){
    transform = GetComponent<Transform>();
  }

  void Start(){

    CalculateNewPoint();
  }

  void Update(){
    Wander();
  }

  public void Wander(){
      float distCovered = (Time.time - startTime) * speed;
      float fractionOfJourney = distCovered / jouneyLength;

      transform.position = Vector3.Lerp(transform.position, newPos, fractionOfJourney);
      
      if(transform.position == newPos){
          CalculateNewPoint();
      }

      
    }

     public void CalculateNewPoint(){
    startTime = Time.time;
    
    randX = Random.Range(0,(transform.position.x + 10f));
    randZ = Random.Range(0,(transform.position.z+10f));
    newPos = new Vector3(randX,transform.position.y,randZ);

    jouneyLength = Vector3.Distance(transform.position, newPos);
  }
}

 
