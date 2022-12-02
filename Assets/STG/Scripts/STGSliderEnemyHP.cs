using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STGSliderEnemyHP : MonoBehaviour
{
    public static STGSliderEnemyHP Instance;

    private void Awake()
    {
        Instance = this;
    }

    Slider sliderHP;

    // Start is called before the first frame update
    void Start()
    {
        sliderHP = GetComponent<Slider>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetValue(int value, int max)
    {
        sliderHP.value = (float)value / (float)max;
        gameObject.SetActive(true);
    }
}
