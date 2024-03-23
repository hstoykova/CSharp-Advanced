using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models;

public class Team : ITeam
{
    public Team(string name)
    {
        Name = name;
        //PointsEarned = 0;
        players = new List<IPlayer> ();
    }

    private string name;

    public string Name
    {
        get { return name; }
        private set 
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(ExceptionMessages.TeamNameNull);
            }
            name = value; 
        }
    }

    private int pointsEarned;

    public int 	PointsEarned
    {
        get { return pointsEarned; }
        private set { pointsEarned = value; }
    }

    //private double overallRating;

    public double OverallRating
    {
        get 
        {
            if (players.Count == 0)
            {
                return 0;
            }

            return Math.Round(Players.Average(p => p.Rating), 2); 
        } // return 0 not implemented
        // can be private set
    }

    private List<IPlayer> players;

    public IReadOnlyCollection<IPlayer> Players
    {
        get { return players; }
        //private set { players = value; }
    }

    public void Draw()
    {
        PointsEarned += 1;
        foreach (var player in players)
        {
            if (player is Goalkeeper)
            {
                player.IncreaseRating();
            }
        }
    }

    public void Lose()
    {
        foreach (var player in players)
        {
            player.DecreaseRating();
        }
    }

    public void SignContract(IPlayer player)
    {
        players.Add(player);
    }

    public void Win()
    {
        PointsEarned += 3;
        foreach (var player in players)
        {
            player.IncreaseRating();
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
        sb.AppendLine($"--Overall rating: {OverallRating}");
        sb.Append("--Players: ");

        if (players.Any())
        {
            sb.Append(string.Join(", ", players.Select(p => p.Name)));
        }
        else
        {
            sb.Append("none");

        }

        return sb.ToString().Trim();
    }
}
