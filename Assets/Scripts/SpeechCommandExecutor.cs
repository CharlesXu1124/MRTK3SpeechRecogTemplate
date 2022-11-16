using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechCommandExecutor : MonoBehaviour
{
    public GameObject cube;
    private bool isColorChanged;
    
    void Start()
    {
        
    }

    public void MoveUp()
    {
        transform.position += Vector3.up * 0.1f;
    }

    public void MoveDown()
    {
        transform.position -= Vector3.up * 0.1f;
    }

    public void ChangeColor()
    {
        var cubeRenderer = cube.GetComponent<Renderer>();

        if (isColorChanged)
        {
            cubeRenderer.material.SetColor("_Color", Color.red);
        } else
        {
            cubeRenderer.material.SetColor("_Color", Color.green);
        }

        isColorChanged = !isColorChanged;


    }

}
