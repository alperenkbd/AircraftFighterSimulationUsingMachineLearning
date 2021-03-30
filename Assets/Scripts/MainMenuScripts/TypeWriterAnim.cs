using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterAnim : MonoBehaviour
{
    [SerializeField] float DelayTime;
    [SerializeField] string AllTxt;
    [SerializeField] string CurrentTxt;

    void Start()
    {
        StartCoroutine(TypeWriter());
    }

     IEnumerator TypeWriter()
    {
        for (int i = 0; i < AllTxt.Length+1; i++)
        {
            CurrentTxt = AllTxt.Substring(0, i);
            this.GetComponent<Text>().text = CurrentTxt;
            yield return new WaitForSeconds(DelayTime);

            if (i % 3 == 0) DelayTime = 0.3f;
            else DelayTime = 0.1f;

        }
    }



}
