using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] GameObject fighter;
    [SerializeField] GameObject enemy;
    private Vector3 fighterCoordinate;
    private Vector3 enemyCoordinate;
    private Vector3 targetDir;

    private void Update()
    {
        DistanceCalculator();
    }

    private void DistanceCalculator()
    {
        float distance;
        float angle;
        
        fighterCoordinate = fighter.transform.position;
        enemyCoordinate = enemy.transform.position;
        targetDir = enemy.transform.position - fighter.transform.position;
        angle = Vector3.SignedAngle(targetDir, -fighter.transform.forward,-Vector3.forward);
        distance = Vector3.Distance(enemyCoordinate , fighterCoordinate);
        Debug.Log("düşmanın uzaklığı: " +distance+ "düşmanın açısı: "+ angle);


    }

    

}
