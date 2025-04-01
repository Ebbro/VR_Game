using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToyCannon : MonoBehaviour
{

    [SerializeField] private float Interval = 5.0f;
    [SerializeField] private float time = 0.0f;



    [SerializeField] public GameObject SpawnablePiece;
    [SerializeField] public List<GameObject> ToyPieces = new List<GameObject>();
    [SerializeField] public float Force = 100.0f;

    


    private void ShootToyPiece()
    {
        //Debug.Log("Toy piece Spawning");
        //GameObject Piece = Instantiate(SpawnablePiece, transform.GetChild(0)); //spawn specific piece

        int RandomInt = Random.Range(0, ToyPieces.Count - 1);

        Debug.Log(string.Concat("Toy piece Spawning - ", RandomInt, " - "));
        GameObject Piece = Instantiate(ToyPieces[RandomInt], transform.GetChild(0));


        Piece.GetComponent<Rigidbody>().AddForce(this.transform.GetChild(0).transform.forward * Force, ForceMode.Impulse);
        Debug.Log("Toy piece launching");

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > Interval)
        {
            time = 0;
            ShootToyPiece();
        }
    }
}
