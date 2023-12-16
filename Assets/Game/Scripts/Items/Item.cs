using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game.Scripts.Items
{
    // Abstract Class
    public abstract class Item : MonoBehaviour
    {
        protected string _name;
        
        [SerializeField] protected ItemDescription _itemDescription;

        // Virtual Method
        public virtual void Initialization(Sprite sprite)
        {
            _itemDescription.sprite = sprite;
        }
    }
}
