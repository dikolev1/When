// InventaryCell ’ранит данные одной €чейки инвентар€
public class InventaryCell
{
    public ItemData itemData;
    public long id = 0;
    public int stack = 0;

    public float GetTotalWeight => itemData.weight * stack;

    public void AddItem(ItemData item, long id)
    {
        itemData = item;
        this.id = id;
        stack++;
    }
}
