using System.Collections.Generic;
using UnityEngine;

namespace YG
{
    public partial class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int MaxLevel { get; private set; } = 12;
        public float TimeLevel = 0;
        public float sensitivity = 3;
        public int money = 0;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public List<int> idWeaponBuy = new List<int>();
        public int idWeaponSelect = 1;
        public List<int> levels = new List<int>();

        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива
            sensitivity = Application.isMobilePlatform ? 5 : 3;
            idWeaponBuy.Add(1);
            levels.Add(1);
            idWeaponSelect = 1;
            openLevels[1] = true;
        }
    }
}
