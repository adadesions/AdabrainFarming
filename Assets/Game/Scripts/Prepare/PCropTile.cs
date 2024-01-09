using UnityEngine;

namespace Game.Scripts.Prepare
{
    public class PCropTile : MonoBehaviour
    {
        private Camera _camera;
        private Collider2D _collider2D;
        private bool _isEntered;
        private GameObject _highLight;
        [SerializeField] private Object _cropItemPrefab;

        // Start is called before the first frame update
        void Start()
        {
            _collider2D = GetComponent<Collider2D>();
            _highLight = transform.Find("Highlight").gameObject;
            _camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (_isEntered && Input.GetMouseButtonDown(0))
            {
                OnMouseClick();
            }
        }

        private void OnMouseClick()
        {
            var cropItemClone = Instantiate(_cropItemPrefab, transform.position, Quaternion.identity);
        }


        private void OnMouseEnter()
        {
            print("Mouse Entered: CropTile");
            _isEntered = true;
            _highLight.SetActive(true);
        }
        
        private void OnMouseExit()
        {
            print("Mouse Leaved: CropTile");
            _isEntered = false;
            _highLight.SetActive(false);
        }
        
        private bool IsMouseOverlap()
        {
            var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            return _collider2D.OverlapPoint(mousePos);
        }
    }
}
