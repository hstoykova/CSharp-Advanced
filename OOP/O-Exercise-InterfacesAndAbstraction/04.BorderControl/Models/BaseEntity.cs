using System;

namespace BorderControl.Models;

public abstract class BaseEntity
{
    protected BaseEntity(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
}
