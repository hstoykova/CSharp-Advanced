using System;

namespace BirthdayCelebrations;

public class Robot : IIdentifialbe
{
    public Robot(string id, string model)
    {
        Model = model;
        Id = id;
    }
    public string Model { get; init; }
    public string Id { get; set; }
}
