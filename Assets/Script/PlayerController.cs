using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Running
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private Transform playerObject;
        [SerializeField] private float moveSpeed;

        [Header("Position")]
        [SerializeField] private Transform positionContainer;
        [SerializeField] private int positionIndex;
        [SerializeField] private List<Transform> positions = new List<Transform>();
        private bool canMove = true;
        // Start is called before the first frame update
        void Start()
        {
            InitPlayer();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }
        private void InitPlayer()
        {
            playerObject = transform.parent;
            playerObject.GetComponent<Transform>();
            positionIndex = 1;
            for (int i = 0; i < positionContainer.childCount; i++)
            {
                positions.Add(positionContainer.GetChild(i));
            }
        }
        private void MoveToNextPosition()
        {
            if (positionIndex >= positions.Count - 1)
                return;
            positionIndex++;


        }

        private void MoveToPreviousPosition()
        {
            if (positionIndex == 0)
                return;
            positionIndex--;
        }
        private void Movement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput < 0 && canMove)
            {

                MoveToPreviousPosition();

                canMove = false;

            }
            else if (horizontalInput > 0 && canMove)
            {
                MoveToNextPosition();
                canMove = false;

            }

            if (horizontalInput == 0)
            {
                canMove = true;
            }
            Vector3 targetPosition = positions[positionIndex].position;
            playerObject.position = Vector3.MoveTowards(playerObject.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}