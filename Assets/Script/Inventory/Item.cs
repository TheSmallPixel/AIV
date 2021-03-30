
using System;

[Serializable]
public class Item
{
    public Item()
    {

    }

    public Item(string type, int position)
    {
        this.Type = type;
        this.Position = position;
        this.Id = Guid.NewGuid().ToString();
    }

    public int Position = -1;

    public string Type;

    public string Id;

}
