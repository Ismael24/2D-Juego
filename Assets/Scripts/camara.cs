using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Es el script que aplicara cambios de posición, efectos u otros a la cámara
 * @author Ismael Paloma Narváez
 */
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
        //este código es para colocar la camara para que siga al target en este caso el Player
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y+1, minHeight, maxHeight), transform.position.z);
        float amountToMoveX = transform.position.x - lastXPosition;
        //este código es para realizar el effecto paralax con los fondos
        farBackground.position = farBackground.position + new Vector3(amountToMoveX,0f,0f);
        middleBackground.position +=  new Vector3(amountToMoveX*0.5f,0f,0f);
        lastXPosition = transform.position.x;
    }
}
