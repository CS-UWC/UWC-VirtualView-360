using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Tour : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject[] interactables;
    public GameObject[] buildings;
    public GameObject mainMenu;
    public GameObject map;
    public GameObject crew;
    public GameObject gyroControl;
    public GameObject[] canvas;
    public bool isCameraMove = false;
    public Interaction ah;
    public Interaction mta;
    public Gyro gyroN;
    public GameObject[] images;
    public ScrollRect[] myScrollRect;
    public Scrollbar[] myScrollBar;
    public GameObject vrControl;
    public VRControlCam vrControlCamInstance;
    public bool myBool = false;
    
 
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(mainMenu.activeSelf){
            for(int i =0; i<rooms.Length;i++){
               if(rooms[i].name != "MainMenu")
                {
                    rooms[i].SetActive(false);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
            {
                isCameraMove = false;
                gyroNavOff();
                GoHome(); 
                for(int i=0; i<buildings.Length;i++){
                buildings[i].SetActive(false);
                }
                for(int i=0; i<interactables.Length;i++){
                interactables[i].SetActive(false);
                }
                  
            }
        else if(mainMenu.activeSelf && Input.GetKeyDown(KeyCode.Escape)){
                exitApp();
            }
        if(isCameraMove)
        {
            if(Input.GetMouseButton(0)){
                if(myBool==false){
        
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit, 100.0f))
                {
                    if(hit.transform.gameObject.tag == "NextRoom")
                    {
                        OpenRoom(hit.transform.gameObject.GetComponent<Navigation>().NavigateToNextRoom());
                        if(rooms[15].activeSelf){
                            crew.SetActive(true);
                            isCameraMove = false;
                            // gyroNavOff();
                        }

                    }
                    else if(hit.transform.gameObject.tag == "Interactive")
                    {
                        hit.transform.gameObject.GetComponent<Interaction>().openWindow();
                        // gyroNavOff();
                    }        
                }
                }
        }
            }

        
    }

  

    public void gyoNav(){
    GameObject controlStick = GameObject.FindWithTag("cameraControls");
    GameObject gyroControl = GameObject.FindWithTag("cameraControls");
    controlStick.GetComponent<CameraControl>().enabled = false;
    gyroControl.GetComponent<Gyro>().enabled = true;
    }

    public void InputNav(){
    vrControl.SetActive(true);
    gyroControl.GetComponent<Gyro>().enabled = false;
    }


    public void gyroNavOff(){
    gyroControl.GetComponent<Gyro>().enabled = false;
    }
    public void gyroNavOn(){
  
    gyroControl.GetComponent<Gyro>().enabled = true;
    vrControl.SetActive(false);
    }
    public void Back(int interactableNumber){
       interactables[interactableNumber].SetActive(false);
       isCameraMove = true;
    //    gyroNavOn();
    }

    public void Window(int interactableNumber){
       interactables[interactableNumber].SetActive(true);
       isCameraMove = false;
       gyroNavOff();
    }

    public void OpenRoom(int room)
    {
        isCameraMove = true;
        // gyroNavOn();
        for(int i=0;i<rooms.Length; i++)
         {
            rooms[i].SetActive(false);
         } 
        rooms[room].SetActive(true);
        map.SetActive(false);
    }

    public void GoHome()
    {
         for (int i = 0; i < rooms.Length; i++)
         {
        if(rooms[i].activeSelf)
        {
            rooms[i].SetActive(false);   
        }  
         }
         mainMenu.SetActive(true);
    }

     public void Navigate(int room)
    {
         for (int i = 0; i < rooms.Length; i++)
    {
        if(rooms[i].activeSelf && rooms[i] != rooms[room])
        {
            rooms[i].SetActive(false);
        }
         if (rooms[i] == rooms[room])
        {
            rooms[i].SetActive(true);  
            if(rooms[i].name == "MainMenu" || rooms[i].name == "Map" || rooms[i].name == "Shortcut" || rooms[i].name == "ShortcutLSB" || rooms[i].name == "OptionsMenu" || rooms[i].name == "CompSciOffices")
            {
                isCameraMove = false;
                // gyroNavOff();
            }
            else 
            {
                isCameraMove = true;
                // gyroNavOn();
            }
        }  
    } 
     
    }
    public void navMap(int building){
        for(int i=0; i<buildings.Length;i++){
            buildings[i].SetActive(false);
        }
        buildings[building].SetActive(true);
    }

    public void changeImage(int image){
        images[image].SetActive(true);
        for(int i=0; i<images.Length;i++){
            if(images[i] !=  images[image])
            {
            images[i].SetActive(false);
            }
    }
    }

    public void scrollbarReset(int bar)
    {
        if(!images[0].activeSelf){
        for(int i=0; i<myScrollBar.Length;i++){
        if(!myScrollBar[i] != myScrollBar[bar])
        {
        myScrollRect[i].verticalNormalizedPosition = 1.0f;
        }
         }
        }
        else
        {
         for(int i=0; i<myScrollRect.Length;i++){
        {
            myScrollRect[i].verticalNormalizedPosition = 1.0f;
        }
         }
        }
    }

     public void exitApp(){   
        Application.Quit ();
    }

}
