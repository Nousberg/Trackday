using Assets.Scripts.Core.WalletStorage;
using Assets.Scripts.Core.Storage;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Core.Saving
{
    [RequireComponent(typeof(PlayerElementsStorage))]
    [RequireComponent(typeof(PlayerWalletStorage))]
    public class GameSaveProvider : MonoBehaviour
    {
        private const string GAME_SAVE_PATH = "Saves";

        private PlayerElementsStorage storage => GetComponent<PlayerElementsStorage>();
        private PlayerWalletStorage walletStorage => GetComponent<PlayerWalletStorage>();

        private string InAppSavePath => Path.Combine(Application.persistentDataPath, GAME_SAVE_PATH);

        public bool Save()
        {
            if (!Directory.Exists(InAppSavePath))
                Directory.CreateDirectory(InAppSavePath);



            return false;
        }
        public bool Load()
        {
            return false;
        }
    }
}