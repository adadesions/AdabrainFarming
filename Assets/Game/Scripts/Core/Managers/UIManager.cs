using UnityEngine;

namespace Game.Scripts.Core.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
                Time.timeScale = _inventoryPanel.activeSelf ? 0 : 1;
            }
        }
    }
}
