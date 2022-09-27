using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFKRotateWall : MonoBehaviour
{

    public Transform a;

    // Start is called before the first frame update
    void Start()
    {
        StartRotating();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(a.position, new Vector3(0, 0, 90), 1);
    }


    public void StartRotating()
    {
        
        //this.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1, 0);

        //this.transform.rotation = Quaternion.Euler(0, 0, 90);

        transform.RotateAround(a.position, new Vector3(0, 0, 90), 90);
        
    }




}
