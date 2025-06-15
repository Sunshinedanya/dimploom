using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scene_Setup
{
    public class ItemRandomPlacer : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _items;

        private List<GameObject> _itemsToSpawn = new();
        
        private void Awake()
        {
            while (_itemsToSpawn.Count < 2)
            {
                var randomItem = _items[Random.Range(0, _items.Count)];
                
                if(_itemsToSpawn.Contains(randomItem) == false)
                    _itemsToSpawn.Add(randomItem);
            }
            
            foreach (var item in _items)
                item.SetActive(false);
            
            foreach (var item in _itemsToSpawn)
                item.SetActive(true);
        }
    }
}