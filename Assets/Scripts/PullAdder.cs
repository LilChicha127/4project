using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullAdder : MonoBehaviour
{
    public List<Item> _products;
    public SkillManager skillManager;
    public Button _button;
   
    private void OnEnable()
    {
        _button.onClick.AddListener(() => { skillManager.UpgradePullProducts(_products); }); // Подписываем кнопку
    }
    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners(); // Отписываемся от кнопки
    }
}
