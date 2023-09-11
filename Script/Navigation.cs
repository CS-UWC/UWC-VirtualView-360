using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
   [SerializeField] private int navigateTo = 0;
   

   public int NavigateToNextRoom()
   {
    return navigateTo;
   }
}
