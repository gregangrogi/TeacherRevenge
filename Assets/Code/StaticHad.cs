using UnityEngine;

public class StaticHad : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject headPositionPoint;


    private void Update()
    {
        if ((head.transform.position - headPositionPoint.transform.position).magnitude >= 1f)
        {
            head.transform.position = new Vector3(headPositionPoint.transform.position.x, headPositionPoint.transform.position.y, 0);


        }

        head.transform.rotation = body.transform.rotation;

    }

}
