using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    [SerializeField] GameObject fighter;
    [SerializeField] GameObject enemy;
    [SerializeField] RawImage enemyImg;
    [SerializeField] Image radarComponent;

    private RectTransform enemyRectTransform;
    private Vector3 fighterCoordinate;
    private Vector3 enemyCoordinate;
    private Vector3 targetDir;


    private void Start()
    {
        enemyRectTransform = enemyImg.transform.GetComponent<RectTransform>();
    }


    private void Update()
    {
        EnemyPositioner();
    }

    private float DistanceCalculator()
    {
        float distance;
        
        fighterCoordinate = fighter.transform.position;
        enemyCoordinate = enemy.transform.position;
        distance = Vector3.Distance(enemyCoordinate , fighterCoordinate);

        return distance;
    }


    private float AngleCalculator()
    {
        float angle;
        targetDir = enemy.transform.position - fighter.transform.position;
        angle = Vector3.SignedAngle(targetDir, -fighter.transform.forward, -Vector3.forward);

        return angle;
    }


    private void EnemyPositioner()
    {
        float localDistance;

        localDistance = DistanceCalculator() / 100f;
        
        if(localDistance > 70)
        {
            enemyImg.gameObject.SetActive(false);
        }
        else
        {
            enemyImg.gameObject.SetActive(true);
            Debug.Log(localDistance);
            
            enemyRectTransform.anchoredPosition = new 
                Vector3(enemyRectTransform.anchoredPosition.x, 
                localDistance, enemyRectTransform.anchoredPosition3D.z);
        }
    }


    private void RadarComponentRotationer()
    {
        float rotationOfEnemy;
        rotationOfEnemy = AngleCalculator();

        
    }

}
