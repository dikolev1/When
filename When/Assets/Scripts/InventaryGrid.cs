// InventaryGrid - Отвечает за контроль сетки инвентаря
using UnityEngine;

public class InventaryGrid
{
    public int width;
    public int height;

    public InventaryCell[,] cellsGrid;

    private long _lastId = 0;

    public InventaryGrid(int width = 5, int height = 5)
    {
        this.width = width;
        this.height = height;
        cellsGrid = new InventaryCell[width, height];
    }

    public bool CanAddItem(Vector2Int pos, ItemData item)
    {
        Vector2Int rightDownPos = pos + item.size;
        if (rightDownPos.x > width || pos.x < 0) return false;
        if (rightDownPos.y > height || pos.y < 0) return false;

        for (int x = pos.x; x < rightDownPos.x; x++)
        {
            for (int y = pos.y; y < rightDownPos.y; y++)
            {
                if (cellsGrid[x, y] != null) return false;
            }
        }

        return true;
    }

    public void AddItem(Vector2Int pos, ItemData item)
    {
        Vector2Int rightDownPos = pos + item.size;

        for (int x = pos.x; x < rightDownPos.x; x++)
        {
            for (int y = pos.y; y < rightDownPos.y; y++)
            {
                cellsGrid[x, y] = new InventaryCell();
                cellsGrid[x, y].AddItem(item, _lastId);
            }
        }
        _lastId++;
    }

    public bool TryAddItem(Vector2Int pos, ItemData item)
    {
        if (!CanAddItem(pos, item))
            return false;
        AddItem(pos, item);
        return true;
    }

    // Only left up corner!!!
    public void RemoveItemByPos(Vector2Int pos)
    {
        if (cellsGrid[pos.x, pos.y] == null) return;

        Vector2Int rightDownPos = pos + cellsGrid[pos.x, pos.y].itemData.size;

        for (int x = pos.x; x < rightDownPos.x; x++)
        {
            for (int y = pos.y; y < rightDownPos.y; y++)
            {
                cellsGrid[x, y] = null;
            }
        }
    }

    public void RemoveItemById(int id)
    {
        if (id < 0) return;
        if (id > _lastId) return;
        bool isFound = false;
        Vector2Int pos = new Vector2Int();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                InventaryCell cell = cellsGrid[x, y];
                if (cellsGrid[x, y] == null) continue;

                if (cell.id == id)
                {
                    isFound = true;
                    pos = new Vector2Int(x, y);
                    break;
                }
            }
            if (isFound)
                break;
        }

        RemoveItemByPos(pos);
    }

}
