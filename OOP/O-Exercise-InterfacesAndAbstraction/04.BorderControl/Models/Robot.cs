using BorderControl.Models.Interfaces;
using System;

namespace BorderControl.Models;

public class Robot : BaseEntity
{
    public Robot(string id, string model)
        :base(id)
    {
        Model = model;
    }
    public string Model { get; init; }

}