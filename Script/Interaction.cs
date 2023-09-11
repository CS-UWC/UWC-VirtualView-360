using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interaction : MonoBehaviour
{

    public GameObject window;
    public Tour tour;
 
    void Start()
    {
        window.SetActive(false);

    }
    
     public void openWindow()
    {
        window.SetActive(true);
        tour.isCameraMove = false;
    }
     public void closeWindow()
    {
        window.SetActive(false);    
    }
}

