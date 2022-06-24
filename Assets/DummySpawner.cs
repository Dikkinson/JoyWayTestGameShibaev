using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySpawner : MonoBehaviour
{
    [SerializeField] private GameObject dummyPrefab;
    [SerializeField] private KeyCode dummyRestartKey;
    private Dummy currentDummy;

    private void Start()
    {
        CreateNewDummy();
    }

    private void Update()
    {
        if (Input.GetKeyDown(dummyRestartKey))
        {
            if (currentDummy != null)
            {
                currentDummy.Restore();
            }else
            {
                CreateNewDummy();
            }
        }
    }

    private void CreateNewDummy()
    {
        currentDummy = Instantiate(dummyPrefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Dummy>();
    }
}
