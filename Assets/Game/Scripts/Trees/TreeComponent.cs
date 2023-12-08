using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts.Trees
{
    public class TreeComponent : MonoBehaviour
    {
        [SerializeField] private int _hp = 5;
        [SerializeField] private GameObject _logPrefab;
        private Animator _anim;
        private GameObject _treeSprite;
        private GameObject _logSprite;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _treeSprite = transform.Find("TreeSprite").gameObject;
            _logSprite = transform.Find("LogSprite").gameObject;
        }

        public void Cut()
        {
            _hp -= 1;
            HandleTreeStates();
        }

        private void HandleTreeStates()
        {
            if (_hp <= 0)
            {
                _anim.SetTrigger("NextState");
                StartCoroutine(TreeDestroying());
            }
        }

        private IEnumerator TreeDestroying()
        {
            var sprite = _treeSprite.GetComponent<SpriteRenderer>();
            for (int i = 0; i < 5; i++)
            {
                sprite.color = new Color(1, 1, 1, 1.0f);
                yield return new WaitForSeconds(0.3f);
                sprite.color = new Color(1, 1, 1, 0.5f);
                yield return new WaitForSeconds(0.3f);
            }
            Destroy(_treeSprite);
            _anim.SetTrigger("NextState");
            transform.rotation = Quaternion.Euler(Vector3.zero);
            yield return new WaitForSeconds(0.7f);
            _logSprite.SetActive(true);
            
        }
    }
}
