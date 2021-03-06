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
    private RectTransform radarRectTransform;
    private Vector3 fighterCoordinate;
    private Vector3 enemyCoordinate;
    private Vector3 targetDir;
    private float rotationOfEnemy;
    private int speedOfRadarRotate=10;


    private void Start()
    {
        enemyRectTransform = enemyImg.transform.GetComponent<RectTransform>();
        radarRectTransform = gameObject.GetComponent<RectTransform>();
    }


    private void Update()
    {
        EnemyPositioner();
        RadarRotationer();
    }

    private float DistanceCalculator()
    {
        float distance;
        
        fighterCoordinate = fighter.transform.position;
        if(enemy !=null)
        enemyCoordinate = enemy.transform.position;
        distance = Vector3.Distance(enemyCoordinate , fighterCoordinate);

        return distance;
    }


    private float AngleCalculator()
    {
        float angle;
        if(enemy!=null)
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

            
            enemyRectTransform.anchoredPosition = new 
                Vector3(enemyRectTransform.anchoredPosition.x, 
                localDistance, enemyRectTransform.anchoredPosition3D.z);
        }
    }

    
    private void RadarRotationer()
    {
        rotationOfEnemy = AngleCalculator();

        radarRectTransform.rotation = Quaternion.Lerp
            (radarRectTransform.rotation, Quaternion.Euler(0, 0, rotationOfEnemy),
            Time.deltaTime * speedOfRadarRotate);
    }
    

}
