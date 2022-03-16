using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform target;
    public float minHeight, maxHeight;
    public Transform farBackground, middleBackground;
    private float lastXPosition;
    private float lastYPosition;
    // Start is called before the first frame update
    void Start()
    {
        lastXPosition = transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        float amountToMoveX = transform.position.x - lastXPosition;

        farBackground.position = farBackground.position + new Vector3(amountToMoveX,0f,0f);
        middleBackground.position +=  new Vector3(amountToMoveX*0.5f,0f,0f);

        lastXPosition = transform.position.x;
    }
}
