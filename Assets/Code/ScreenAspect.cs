using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAspect : MonoBehaviour
{
    public float screenRatio;
    [SerializeField] private float roomWidth;
    [SerializeField] private Transform lBorder;
    [SerializeField] private Transform rBorder;
    // Start is called before the first frame update
    void Start()
    {
        screenRatio = (float)((float)Screen.width / (float)Screen.height);
        lBorder.position = Vector3.zero;
        lBorder.Translate((float)-roomWidth * screenRatio - 5, 0, 0);
        rBorder.position = Vector3.zero;
        rBorder.Translate((float)roomWidth * screenRatio + 5, 0, 0);
    }

    public void MoveBorder(float posX)
    {
        rBorder.position = Vector3.zero;
        rBorder.Translate((float)roomWidth * posX * screenRatio + 5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
