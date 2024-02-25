﻿
namespace PersonsInfo;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        Name = name;
        firstTeam = new();
        reserveTeam = new();
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public IReadOnlyCollection<Person> FirstTeam { get { return firstTeam.AsReadOnly(); } }
    public IReadOnlyCollection<Person> ReserveTeam { get { return reserveTeam.AsReadOnly(); } }

    public void AddPlayer(Person player)
    {
        if (player.Age < 40)
        {
            firstTeam.Add(player);
        }
        else
        {
            reserveTeam.Add(player);
        }
    }
}
