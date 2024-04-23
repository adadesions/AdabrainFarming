using UnityEngine;

namespace Resources.PlayerData
{
    public class PlayerDataSystem : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (!PlayerPrefs.HasKey("Money"))
            {
                PlayerPrefs.SetInt("Money", 500);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time % 60 == 0)
            {
                PlayerPrefs.Save();
            }
        }
    }
}
