using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    string ButtonString = "3";
    [SerializeField] Text ButtonText;

    public void PlayButtonMethod()
    {
        StartCoroutine(CountForStart());
    }


    IEnumerator CountForStart()
    {
        ButtonText.text = ButtonString;
        yield return new WaitForSeconds(1);
        ButtonString = "2";
        ButtonText.text = ButtonString;
        yield return new WaitForSeconds(1);
        ButtonString = "1";
        ButtonText.text = ButtonString;
        yield return new WaitForSeconds(1);
        ButtonString = "0";
        ButtonText.text = ButtonString;
        SceneManager.LoadScene(2);

    }
}
