using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.SpecialScene.SO_Data
{
    public class PlayerStats : MonoBehaviour
    {

        [SerializeField] private PlayerDataSO _playerData;
        // Start is called before the first frame update
        void Start()
        {
            SceneManager.sceneLoaded += SceneLoaded;
        }

        private void SceneLoaded(Scene s, LoadSceneMode arg1)
        {
            print(s.name);
            StartCoroutine(LoadingScene());
        }

        private IEnumerator LoadingScene()
        {
            var loadingScene = Instantiate(_playerData.LoadingScene);
            Destroy(loadingScene, 5f);
            yield return null;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
    }
}
