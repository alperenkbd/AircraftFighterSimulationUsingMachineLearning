using UnityEngine;
using UnityEngine.UI;

public class EnemyQuestPointer : MonoBehaviour
{

    public GameObject Player;
    public GameObject Pointer;
    public GameObject Player1;
    public GameObject Pointer1;
    public GameObject Player2;
    public GameObject Pointer2;

    private bool flag;
    private bool flag1;
    private bool flag2;

    [SerializeField] Text CountOfEnemyText;
    private static int countOfEnemy=3;


    void Update()
    {
        
        if (Player != null)
        {
            var screenPos = Camera.main.WorldToScreenPoint(Player.transform.position);
            Pointer.transform.position = screenPos;

        }
        else
        {
            if(flag == false)
            {
                flag = true;
                Pointer.SetActive(false);
                countOfEnemy--;
                CountOfEnemyText.text = countOfEnemy.ToString();
            }
            
        }

        if (Player1 != null)
        {
            var screenPos1 = Camera.main.WorldToScreenPoint(Player1.transform.position);
            Pointer1.transform.position = screenPos1;

        }
        else
        {
            if (flag1 == false)
            {
                flag1 = true;
                Pointer1.SetActive(false);
                countOfEnemy--;
                CountOfEnemyText.text = countOfEnemy.ToString();
            }
        }

        if (Player2 != null)
        {
            var screenPos2 = Camera.main.WorldToScreenPoint(Player2.transform.position);
            Pointer2.transform.position = screenPos2;

        }
        else
        {
            if (flag2 == false)
            {
                flag2 = true;
                Pointer2.SetActive(false);
                countOfEnemy--;
                CountOfEnemyText.text = countOfEnemy.ToString();
            }
        }

    }


}
