using System;
using UnityEngine;

namespace Assets.Scripts.Core.WalletStorage
{
    internal class PlayerWalletStorage : MonoBehaviour
    {
        private const int MAX_MONEY_AMOUNT = 99999999;
        private const int MAX_DIAMOND_AMOUNT = 99999999;

        public int Money { get; private set; }
        public int Diamonds { get; private set; }

        public event Action<int> OnMoneyIncrease;
        public event Action<int> OnMoneyDecrease;

        public event Action<int> OnDiamondsIncrease;
        public event Action<int> OnDiamondsDecrease;

        public void AddMoney(int amount)
        {
            Money = Mathf.Clamp(Money + amount, 0, MAX_MONEY_AMOUNT);
            OnMoneyIncrease?.Invoke(amount);
        }
        public void RemoveMoney(int amount)
        {
            Money = Mathf.Clamp(Money - amount, 0, MAX_MONEY_AMOUNT);
            OnMoneyDecrease?.Invoke(amount);
        }
        public void AddDiamonds(int amount)
        {
            Diamonds = Mathf.Clamp(Diamonds + amount, 0, MAX_DIAMOND_AMOUNT);
            OnDiamondsIncrease?.Invoke(amount);
        }
        public void RemoveDiamonds(int amount)
        {
            Diamonds = Mathf.Clamp(Diamonds - amount, 0, MAX_DIAMOND_AMOUNT);
            OnDiamondsDecrease?.Invoke(amount);
        }
    }
}
