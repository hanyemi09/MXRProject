using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject toReposition;
    PlacementMarker placement;

    // Start is called before the first frame update
    void Start()
    {
        placement = FindObjectOfType<PlacementMarker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {
                if (!toReposition.activeSelf)
                {
                    Debug.Log("Spawning the gameObject");
                    toReposition.SetActive(true);
                }
            }
        }
    }
}
