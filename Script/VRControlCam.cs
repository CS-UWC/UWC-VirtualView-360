using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VRControlCam : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
   public Tour tour;
   public Rotate rotation;
   public Image vrBG;
   public Image vrJoystick;
   public Vector3 drag{ set; get;}
   public float x;
   public float y;

   public void Start(){
    drag = Vector3.zero;
   }

   public virtual void OnDrag(PointerEventData ped){
    tour.myBool = true;
    Vector2 bind = Vector2.zero;
    Vector2 sizeBG = vrBG.rectTransform.sizeDelta;
    if(RectTransformUtility.ScreenPointToLocalPointInRectangle(vrBG.rectTransform, ped.position, ped.pressEventCamera, out bind))
    {
        bind.x = (bind.x/sizeBG.x);
        bind.y = (bind.y/sizeBG.y);
        x = bind.x*2-1;
        y = bind.y*2-1;
        if(vrBG.rectTransform.pivot.x == 1)
        {
            x = bind.x*2+1;
        }
        else if(vrBG.rectTransform.pivot.y == 1)
        {
             y = bind.y*2+1;
        }

        drag = new Vector3(x, 0, y);
        if(drag.magnitude > 1)
        {
            drag = drag.normalized;
        }
        vrJoystick.rectTransform.anchoredPosition = new Vector3(drag.x*(sizeBG.x/5), (drag.z*(sizeBG.y/5)));
        }
        // drag to Rotate
        rotation.RotateCamera(drag);
     
   }
   public virtual void OnPointerUp(PointerEventData ped){
    tour.myBool = false;
     Debug.Log("Up");
   }
   public virtual void OnPointerDown(PointerEventData ped){
    tour.myBool = true;
     Debug.Log("Down");
   } 
}
