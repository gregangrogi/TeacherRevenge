using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public float menuOpenTime;
    public float menuWidth;
    public ScreenAspect screenAspect;
    private RectTransform rectTransform;
    [SerializeField]
    private float screenHeight = 1080,
        screenWidth,
        timer;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = (float)Screen.width / (float)Screen.height * screenHeight;
        rectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            float scale = timer / menuOpenTime * menuWidth;
            if (isOpen)
            {
                scale = menuWidth - scale;
            }
            rectTransform.anchoredPosition = new Vector3((screenWidth - scale) / 2, 0, 0);
            rectTransform.localScale = new Vector3(scale, screenHeight);
            screenAspect.MoveBorder((screenWidth - scale* 2) / screenWidth );
            timer -= Time.deltaTime;
        }
    }

    public void OpenMenu()
    {
        isOpen = !isOpen;
        if (timer > 0)
        {
            timer = menuOpenTime - timer;
            return;
        }
        timer = menuOpenTime;
    }
}
