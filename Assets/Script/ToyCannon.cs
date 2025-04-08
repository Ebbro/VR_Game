using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToyCannon : MonoBehaviour
{

    [SerializeField] private float Interval = 5.0f;
    [SerializeField] private float time = 0.0f;
    [SerializeField] private bool active = true;

    [SerializeField] public float Force = 100.0f;
    [SerializeField] public List<GameObject> ToyPieces = new List<GameObject>();
    


    private void SwitchActivate(){
        if(active) active = false;
        else active = true;
        }
    
    private void UpdateTime()
    {
        if (active)
        {
            time += Time.deltaTime;
            if (time > Interval)
            {
                time = 0;
                ShootToyPiece();
            }
        }
    }

    private void ShootToyPiece()
    {
        //Debug.Log("Toy piece Spawning");
        //GameObject Piece = Instantiate(SpawnablePiece, transform.GetChild(0)); //spawn specific piece

        int RandomInt = Random.Range(0, ToyPieces.Count);

        Debug.Log(string.Concat("Toy piece Spawning - ", RandomInt, " - "));
        GameObject Piece = Instantiate(ToyPieces[RandomInt], transform.GetChild(0));


        Piece.GetComponent<Rigidbody>().AddForce(this.transform.GetChild(0).transform.forward * Force, ForceMode.Impulse);
        Piece.transform.parent = null;
        Debug.Log("Toy piece launching");

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }
}
