using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;


public class DialogueAppear : MonoBehaviour
{
    public string before;
    private string currentText = "";

    public float delay = 0.1f;
  
    void Start()
    {
        StartCoroutine(testAppears());
    }


    IEnumerator testAppears()
    {
        for (int i = 0; i < before.Length; i++)
        {
            currentText = before.Substring(0,i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

    }
  
}
