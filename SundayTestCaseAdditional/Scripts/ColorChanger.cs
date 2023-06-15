using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer _cupMaterial;

    private void Start()
    {
        Application.targetFrameRate = 60;

        _cupMaterial = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        _cupMaterial.material.color = new Color(Random.value,Random.value,Random.value);
    }
}
