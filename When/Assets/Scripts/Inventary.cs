// Inventary - находится на объектах с инвентарем, отвечает за связь мира и игрока, с инвентарем
// Пока не имеет должного функционала, скорее всего все здесь надо переделать
using UnityEngine;

public class Inventary : MonoBehaviour
{
    public InventaryGrid inventaryGrid = new InventaryGrid();

    public int width = 0;
    public int height = 0;

    // this shit must be deleted
    public int itemSizeX;
    public int itemSizeY;
    public int itemPosX;
    public int itemPosY;
    public string itemName;
    public float itemWeight;
    public int itemMaxStack;
    public Sprite itemIcon;

    public int removeItemId = 0;
    public int removeItemX;
    public int removeItemY;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector2Int pos = new Vector2Int(itemPosX, itemPosY);
            ItemData item = new ItemData();
            item.size = new Vector2Int(itemSizeX, itemSizeY);
            item.icon = itemIcon;
            item.name = itemName;
            item.weight = itemWeight;
            item.maxStack = itemMaxStack;
            item.icon = itemIcon;

            if (inventaryGrid.TryAddItem(pos, item))
            {

                Debug.Log("Item added!");
            }
            else
            {
                Debug.Log("Item cant be added!");
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            inventaryGrid.RemoveItemByPos(new Vector2Int(removeItemX, removeItemY));
            Debug.Log("Item removed by positon!");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            inventaryGrid.RemoveItemById(removeItemId);
            Debug.Log("Item removed by ID!");
        }
    }
    //

    public void SizeUpdate()
    {
        inventaryGrid.width = width == 0 ? inventaryGrid.width : width;
        inventaryGrid.height = height == 0 ? inventaryGrid.height : height;
        inventaryGrid.cellsGrid = new InventaryCell[width, height];
    }

    public Vector2Int GetSize() { return new Vector2Int(inventaryGrid.width, inventaryGrid.height); }
    public InventaryCell[,] GetItemsGrid() { return inventaryGrid.cellsGrid; }
}
