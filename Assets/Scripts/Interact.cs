using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Interact : MonoBehaviour
{

    public Transform Box;
    private GameObject _item;
    public InputManager InputManager;
    public Item Item;
    public int _index;
    public int _price;
    public GameObject skillMenu;
    public Builder builder;
    public SkillManager skillManager;
    private void Update()
    {
        if(_item != null && Item != null && Item.Itemamount  <= 0)
        {
            InputManager.box = false;
            Destroy(_item);
        }
        
    }
    public void setIndex(int index)
    {
        _index = index;
    }
    public void TakeButton()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit) && hit.collider != null)
        {
            if (hit.collider.GetComponent<Item>() && _item == null)
            {
                GrabItem(hit.collider);
            }
            else if (hit.collider.GetComponent<ShelfLogic>())
            {
                PlaceItemOnShelf(hit.collider, Item.Itemamount );
            }
            else
            {
                Debug.Log("Nothing");
            }
        }
    }


    public void GetToBuild()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit) && hit.collider != null)
        {
            if (hit.collider.CompareTag("Shelf"))
            {
                builder.setShelf(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("Не получилось взять");
            }
        }
    }
    public void SetToBuild()
    {
        builder.PutShelf();
    }

    private void GrabItem(Collider collider)
    {
        GameObject item = Instantiate(collider.gameObject, Box.position, Box.rotation, Box);
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Collider>().enabled = false;
        Item = item.GetComponent<Item>();   
        _item = item;
        _price = Item.ItemPrice;
        Destroy(collider.gameObject);
        InputManager.box = true;
    }

    private void PlaceItemOnShelf(Collider shelfCollider, int _amount)
    {

        var shelfLogic = shelfCollider.GetComponent<ShelfLogic>();


        if (Item.item.typeProduct == shelfLogic.Type)
        {

            Item.Itemamount = Item.Itemamount - shelfLogic.shelfSlots[_index].amountPlace;
        }
        
        shelfLogic.chooseShelf(Item.item, _index, _amount, _price, Item.item.typeProduct);
    }

    public void PutButton()
    {
        if (_item != null)
        {
            PutItem();
        }
    }

    private void PutItem()
    {
        GameObject putItem = Instantiate(_item.GetComponent<Item>().item.prefab, transform.position, Quaternion.identity);
        putItem.GetComponent<Item>().Itemamount = Item.Itemamount; 
        putItem.GetComponent<Collider>().enabled = true;
        Destroy(_item);
        InputManager.box = false;
    }
    public void OpenMenuSkill()
    {
        skillMenu.SetActive(!skillMenu.activeSelf);
    }
}

