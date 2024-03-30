using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models;

public abstract class Bank : IBank
{
    private string name;
    private int capacity;
    private List<ILoan> loans;
    private List<IClient> clients;

    protected Bank(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        loans = new List<ILoan>();
        clients = new List<IClient>();
    }

    public string Name
    {
        get { return name; }
        private set 
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
            }
            name = value; 
        }
    }

    public int Capacity
    {
        get { return capacity; }
        private set { capacity = value; }
    }

    public IReadOnlyCollection<ILoan> Loans
    {
        get { return loans.AsReadOnly(); }
        //set { loans = value; }
    }

    

    public IReadOnlyCollection<IClient> Clients
    {
        get { return clients.AsReadOnly(); }
        //set { myVar = value; }
    }

    public double SumRates()
    {
        if (!loans.Any())
        {
            return 0;
        }

        return loans.Select(l => l.InterestRate).Sum();
    }

    public void AddClient(IClient Client)
    {
        if (Capacity > clients.Count)
        {
            clients.Add(Client);
        }
        else
        {
        throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
        }
    }

    public void RemoveClient(IClient Client)
    {
        clients.Remove(Client);
    }

    public void AddLoan(ILoan loan)
    {
        loans.Add(loan);
    }

    public string GetStatistics()
    {
        string clientStats;

        if (clients.Count == 0)
        {
            clientStats = "none";
        }
        else
        {
            var names = clients.Select(c => c.Name);
            clientStats = string.Join(", ", names);
        }

        StringBuilder sb = new();
        sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");
        sb.AppendLine($"Clients: {clientStats}");
        sb.AppendLine($"Loans: {loans.Count}, Sum of Rates: {SumRates()}");

        return sb.ToString().Trim();
    }
}
