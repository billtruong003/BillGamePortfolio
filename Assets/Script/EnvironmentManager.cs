using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Running
{
    public class EnvironmentManager : MonoBehaviour
    {
        [SerializeField] private GameObject groundContainer;
        [SerializeField] private GameObject groundPrefabs;
        [SerializeField] private List<Material> groundMaterials;

        [Range(0, 10)][SerializeField] public float floatingSpeed;
        [SerializeField] private float resetPositionZ;
        [SerializeField] private float endPositionZ;

        private List<Transform> groundPlane = new List<Transform>();

        private void Awake()
        {
            SpawnGround();
        }

        private void Update()
        {
            FloatingGround();
        }
        private void SpawnGround()
        {
            for (int i = 0; i < groundContainer.transform.childCount; i++)
            {
                GameObject InstantiateGround = Instantiate(groundPrefabs, groundContainer.transform.GetChild(i).localPosition, Quaternion.identity);
                Transform InstGroundTrans = InstantiateGround.transform;
                MeshRenderer InstantiateMeshRenderer = InstantiateGround.GetComponent<MeshRenderer>();

                groundPlane.Add(InstantiateGround.transform);
                InstGroundTrans.parent = groundContainer.transform.GetChild(i);
                InstGroundTrans.localPosition = Vector3.zero;

                InstantiateMeshRenderer.sharedMaterial = groundMaterials[i];
            }
        }
        private void ResetGround(Transform groundTransform)
        {
            if (groundTransform.localPosition.z < endPositionZ)
                groundTransform.localPosition = new Vector3(groundTransform.position.x, groundTransform.position.y, resetPositionZ);
        }
        private void FloatingGround()
        {
            Vector3 floatDirection = new Vector3(0, 0, -1f);
            foreach (Transform child in groundContainer.transform)
            {
                child.transform.Translate(floatDirection * floatingSpeed * Time.deltaTime);
                ResetGround(child);
            }
        }

    }
}
