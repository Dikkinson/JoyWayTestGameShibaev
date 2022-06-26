using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyView : MonoBehaviour
{
    [SerializeField] private Renderer dummyMeshRenderer;
    private const string PROPERTY_NAME = "Color_ae45592293b3423a9a9765fbeaec5b2c";

    public void ChangeColor(Color color)
    {
        dummyMeshRenderer.material.SetColor(PROPERTY_NAME, color);
    }

    public void ResetColor()
    {
        dummyMeshRenderer.material.SetColor(PROPERTY_NAME, Color.white);
    }
}
