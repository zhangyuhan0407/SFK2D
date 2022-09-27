using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFKRotatePipe : MonoBehaviour
{

    public Transform a;

    // Start is called before the first frame update
    void Start()
    {
        //StartRotating();

        StartCoroutine(StartRotating());

    }

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(a.position, new Vector3(0, 0, 90), 1);
    }


    public IEnumerator StartRotating()
    {
        int i = 0;
        while ( i < 90)
        {
            i++;
            //Vector3 dest = Vector3.Lerp(Vector3.zero, new Vector3(0, 0, 90), 30);
            transform.RotateAround(a.position, new Vector3(0, 0, 90), -1);
            yield return new WaitForEndOfFrame();
        }
        
    }



}
