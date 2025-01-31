using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CoreUi
{
    public class MenuSwitcher : MonoBehaviour
    {
        [SerializeField] private List<MenuData> menus = new List<MenuData>();

        public event Action<Menu> OnMenuSwitch;

        private int currentMenu;

        public void Switch(int offset)
        {
            int indexOffset = currentMenu + offset;

            if (indexOffset < 0 || indexOffset >= menus.Count)
                return;

            currentMenu = indexOffset;

            menus.ForEach(n => n.gameObject.SetActive(false));
            menus[currentMenu].gameObject.SetActive(true);

            OnMenuSwitch?.Invoke(menus[currentMenu].MenuType);
        }

        public enum Menu : byte
        {
            Main,
            Garage,
            Tuning
        }
    }
}
