using System;
using Score;
using UnityEngine;

namespace SnakeBody
{
    public class AddToBody : MonoBehaviour
    {
        [SerializeField] private GameObject body;
        [SerializeField] private GameObject tail;

        private BodyManager bodyM;

        private float _segmentGrowth = 0.3f; //added slight delay when adding parts to get smoother clipping. 

        private void Start()
        {
            GameManager.instance.collectebleCollected += GrowBody;
            bodyM = GetComponent<BodyManager>();
        }

        private void Update() //TEST//
        {
            _segmentGrowth -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && _segmentGrowth <= 0)
            {
                GrowBody();
                _segmentGrowth = 0.3f;
            }
        }

        private void GrowBody() //adding body and tail so the last added prefab gets the correct model and layer.
        {
            if (_segmentGrowth <= 0)
            {
                 bodyM.AddBodyParts(body);
                 bodyM.RemoveBodyTail();
                 bodyM.AddBodyParts(tail);
                 _segmentGrowth = 0.3f; //made a slight delay so prefabs would get added with correct distance.
            }
        }

        private void OnDestroy()
        {
            GameManager.instance.collectebleCollected -= GrowBody;
        }
    }
}
