using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToPlayManager : MonoBehaviour
{

    private void Update()
    {
        SceneMan();
    }


    void SceneMan()
    {
        if (Input.GetKey(KeyCode.Space)){

            SceneManager.LoadScene(1);

        }
        

    }

}
