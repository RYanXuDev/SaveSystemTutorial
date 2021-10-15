using UnityEngine;
using UnityEngine.UI;

namespace SaveSystemTutorial
{
    public class UIController : MonoBehaviour
    {
        #region Fields
        
        [Header("-- Texts --")]
        [SerializeField] Text playerNameText;
        [SerializeField] Text playerLevelText;
        [SerializeField] Text playerCoinText;
        [SerializeField] Text playerPositionXText;
        [SerializeField] Text playerPositionYText;
        [SerializeField] Text playerPositionZText;

        [Header("-- Buttons --")]
        [SerializeField] Button buttonSave;
        [SerializeField] Button buttonLoad;

        [Header("-- Player Data --")]
        [SerializeField] PlayerData playerData;

        #endregion

        void Start()
        {
            buttonSave.onClick.AddListener(() => playerData.Save());
            buttonLoad.onClick.AddListener(() => playerData.Load());
        }

        void Update()
        {
            playerNameText.text = playerData.Name;
            playerLevelText.text = playerData.Level.ToString();
            playerCoinText.text = playerData.Coin.ToString();
            playerPositionXText.text = playerData.Position.x.ToString("0.00");
            playerPositionYText.text = playerData.Position.y.ToString("0.00");
            playerPositionZText.text = playerData.Position.z.ToString("0.00");
        }
    }
}