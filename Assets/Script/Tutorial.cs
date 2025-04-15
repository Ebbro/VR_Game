using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [SerializeField] private GameObject LightOn;
    [SerializeField] private GameObject LightOff;
    [SerializeField] private Color LightColor;
    [SerializeField] private GameObject SchermiOn;
    [SerializeField] private GameObject CannonOn;
    [SerializeField] private GameObject PunteggioOn;
    [SerializeField] private GameObject UI;
    [SerializeField] private bool IsStart= false;
    [SerializeField] private bool RoomLight = false;




    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        if (other.gameObject.tag == "MainCamera")
        {
            CheckToDo();
            Debug.Log("Player Entered Trigger");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (IsStart) StartCoroutine(ExampleCoroutine());
        
        //Start the coroutine we define below named ExampleCoroutine.

    }

    private void CheckToDo()
{

        // Attiva solo al primo trigger
        if (SchermiOn != null)
        {
            Debug.Log("Attivo Schermi al primo trigger");
            SchermiOn.SetActive(true);
        }

    if (LightOn != null)
    {
        TurnOnLights(LightOn);
    }
    if (LightOff != null)
    {
        TurnOffLights(LightOff);
    }
    if (CannonOn != null)
    {
        TurnOnLights(CannonOn);
    }
    if (RoomLight)
    {
        RenderSettings.ambientLight = LightColor;
    }
     if (PunteggioOn != null)
        {
            Debug.Log("Attivo Schermi al primo trigger");
            PunteggioOn.SetActive(true);
        }
        if (UI != null)
        {
            Debug.Log("Attivo Schermi al primo trigger");
            UI.SetActive(true);
        }
}


    IEnumerator ExampleCoroutine()
    {
        
        yield return new WaitForSeconds(2);
        TurnOnLights(LightOn);
        
    }

    private void TurnOnLights(GameObject Light)
    {
        Debug.Log("TurningOnLights");
        Light.SetActive(true);
    }


    private void TurnOffLights(GameObject Light)
    {
        Light.SetActive(false);
    }





    // Update is called once per frame
    void Update()
    {
        
    }
    


    


}
