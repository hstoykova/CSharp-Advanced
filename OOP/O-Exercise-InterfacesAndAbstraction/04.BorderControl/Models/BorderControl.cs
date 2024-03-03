using System;

namespace BorderControl.Models;

public class BorderControl
{
    private List<BaseEntity> entityList;

    public List<BaseEntity> EntitiesToBeChecked
    {
        get => entityList;
    }

    public BorderControl()
    {
        entityList = new List<BaseEntity>();
    }
    public void AddEntityForBorderCheck (BaseEntity entity)
    {
        entityList.Add(entity);
    }
}
