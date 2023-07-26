using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Running
{
    public class SpawnEnvironmentObject : MonoBehaviour
    {
        [SerializeField] private GameObject ObstaclePrefab;
        [SerializeField] private EnvironmentManager environmentManager;
        void Start()
        {
            environmentManager = GetComponent<EnvironmentManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private IEnumerator SpawnObstaclesObject()
        {
            yield return null;
        }
    }
}
