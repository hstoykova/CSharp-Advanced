using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Core;

public class Controller : IController
{
    private PlayerRepository players;

    private TeamRepository teams;

    public Controller()
    {
        players = new PlayerRepository();
        teams = new TeamRepository();
    }

    public string NewTeam(string name)
    {
        if (teams.ExistsModel(name))
        {
            return string.Format(OutputMessages.TeamAlreadyExists, name, typeof(TeamRepository).Name);
        }
        else
        {
            var team = new Team(name);
            teams.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, typeof(TeamRepository).Name);
        }
    }

    public string NewPlayer(string typeName, string name)
    {
        string[] validTypes = new[] { "Goalkeeper", "CenterBack", "ForwardWing" };

        if (!validTypes.Contains(typeName))
        {
            return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
        }


        if (players.ExistsModel(name))
        {
            var player = players.GetModel(name);
            return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, typeof(PlayerRepository).Name, player.GetType().Name);
        }
        else
        {
            if (typeName == "Goalkeeper")
            {
                players.AddModel(new Goalkeeper(name));
            }
            else if (typeName == "CenterBack")
            {
                players.AddModel(new CenterBack(name));
            }
            else
            {
                players.AddModel(new ForwardWing(name));
            }
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }
    }

    public string NewContract(string playerName, string teamName)
    {
        if (!players.ExistsModel(playerName))
        {
            return string.Format(OutputMessages.PlayerNotExisting, playerName, typeof(PlayerRepository).Name);
        }

        if (!teams.ExistsModel(teamName))
        {
            return string.Format(OutputMessages.TeamNotExisting, teamName, typeof(TeamRepository).Name);
        }

        var player = players.GetModel(playerName);
        var team = teams.GetModel(teamName);

        if (player.Team != null)
        {
            return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
        }

        player.JoinTeam(team.Name);
        team.SignContract(player);

        return string.Format(OutputMessages.SignContract, playerName, teamName);
    }

    public string NewGame(string firstTeamName, string secondTeamName)
    {
        var firstTeam = teams.GetModel(firstTeamName);
        var secondTeam = teams.GetModel(secondTeamName);

        if (firstTeam.OverallRating > secondTeam.OverallRating)
        {
            firstTeam.Win();
            secondTeam.Lose();
            return string.Format(OutputMessages.GameHasWinner, firstTeam.Name, secondTeam.Name);
            //GameHasWinner = "Team {0} wins the game over {1}!";
        }
        else if (firstTeam.OverallRating < secondTeam.OverallRating)
        {
            secondTeam.Win();
            firstTeam.Lose();
            return string.Format(OutputMessages.GameHasWinner, secondTeam.Name, firstTeam.Name);
            //GameHasWinner = "Team {0} wins the game over {1}!";
        }
        else
        {
            firstTeam.Draw();
            secondTeam.Draw();
            return string.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);
            //GameIsDraw = "The game between {0} and {1} ends in a draw!";
        }
    }

    public string PlayerStatistics(string teamName)
    {
        var team = teams.GetModel(teamName);
        var players = team.Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name).ToList();

        StringBuilder sb = new();
        sb.AppendLine($"***{teamName}***");
        foreach (var player in players)
        {
            sb.AppendLine(player.ToString());
        }
        return sb.ToString().Trim();
    }

    public string LeagueStandings()
    {

        // Console.WriteLine(orderedTeams.Count());
        StringBuilder sb = new();
        sb.AppendLine("***League Standings***");

        List<ITeam> sorted = teams.Models
            .OrderByDescending(t => t.PointsEarned)
            .ThenByDescending(t => t.OverallRating)
            .ThenBy(t => t.Name)
            .ToList();

        foreach (var team in sorted)
        {
            sb.AppendLine(team.ToString());
        }

        return sb.ToString().Trim();
    }
}
