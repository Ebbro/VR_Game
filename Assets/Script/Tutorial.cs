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
    [SerializeField] private bool IsStart= false;





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")CheckToDo();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (IsStart) StartCoroutine(ExampleCoroutine());
        //Start the coroutine we define below named ExampleCoroutine.

    }

    private void CheckToDo()
    {
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
            TurnOffLights(CannonOn);
        }


    }

    IEnumerator ExampleCoroutine()
    {
        
        yield return new WaitForSeconds(2);
        TurnOnLights(LightOn);
        
    }

    private void TurnOnLights(GameObject Light)
    {
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
