using Assets.Scripts.Core.WalletStorage;
using Assets.Scripts.Core.Storage;
using Assets.Scripts.Core.Saving;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameSaveProvider saveProvider;
        [SerializeField] private PlayerElementsStorage storage;
        [SerializeField] private PlayerWalletStorage walletStorage;

        private void Awake()
        {
            DontDestroyOnLoad(saveProvider);
            DontDestroyOnLoad(storage);
            DontDestroyOnLoad(walletStorage);
        }
    }
}