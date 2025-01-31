using Assets.Scripts.Core.WalletStorage;
using Assets.Scripts.Core.Storage;
using Assets.Scripts.Core.Storage.StorageElements;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Shop
{
    [RequireComponent(typeof(DataContainer))]
    public class ShopManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerWalletStorage walletStorage;
        [SerializeField] private PlayerElementsStorage storage;

        [Header("Properties")]
        [SerializeField] private List<StorageElement> buyableElements = new List<StorageElement>();

        private DataContainer container => GetComponent<DataContainer>();

        public void Buy(int id)
        {
            StorageElement findedElement = buyableElements.Find(n => n.Id == id);

            if (findedElement != null && container.AllIngameElements.Contains(findedElement) && walletStorage.Money >= findedElement.MoneyPrice && walletStorage.Diamonds >= findedElement.DiamondsPrice)
            {
                storage.AddElement(findedElement.Id);

                walletStorage.RemoveDiamonds(findedElement.DiamondsPrice);
                walletStorage.RemoveMoney(findedElement.MoneyPrice);
            }
        }
        public void Sell(int id)
        {
            StorageElement findedElement = storage.GetElements.Find(n => n.data.Id == id).data;

            if (findedElement != null)
            {
                storage.RemoveElement(id);

                walletStorage.AddDiamonds(findedElement.DiamondsPrice);
                walletStorage.AddMoney(findedElement.MoneyPrice);
            }
        }
    }
}