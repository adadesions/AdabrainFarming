using System;
using System.Collections;
using Game.Scripts.Items;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts.Trees
{
    [RequireComponent(typeof(ProductItem))]
    public class TreeComponent : MonoBehaviour
    {
        [SerializeField] private int _hp = 5;
        [SerializeField] private GameObject _logPrefab;
        private Animator _anim;
        private GameObject _treeSprite;
        private GameObject _logSprite;
        private ProductItem _productItem;

        public int Hp
        {
            get => _hp;
            set => _hp = value;
        }

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _treeSprite = transform.Find("TreeSprite").gameObject;
            _logSprite = transform.Find("LogSprite").gameObject;
            _productItem = GetComponent<ProductItem>();
        }

        public void Cut()
        {
            Hp -= 1;
            HandleTreeStates();
        }

        private void HandleTreeStates()
        {
            if (Hp <= 0)
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
            
            // TODO: Drop Item
            _productItem.DropItem();
            
            yield return new WaitForSeconds(0.7f);
            _logSprite.SetActive(true);
        }
    }
}
