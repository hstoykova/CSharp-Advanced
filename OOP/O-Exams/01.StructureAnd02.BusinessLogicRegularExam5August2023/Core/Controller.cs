using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core;

public class Controller : IController
{
    private LoanRepository loans;
    private BankRepository banks;

    public Controller()
    {
        loans = new LoanRepository();
        banks = new BankRepository();
    }
    public string AddBank(string bankTypeName, string name)
    {
        string[] validBankTypes = new[] { "BranchBank", "CentralBank" };

        if (!validBankTypes.Contains(bankTypeName))
        {
            throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
        }

        IBank bank;

        if (bankTypeName == "BranchBank")
        {
            bank = new BranchBank(name);
        }
        else //CentralBank
        {
            bank = new CentralBank(name);
        }

        banks.AddModel(bank);
        return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
    }

    public string AddLoan(string loanTypeName)
    {
        string[] validLoanTypes = new[] { "MortgageLoan", "StudentLoan" };

        if (!validLoanTypes.Contains(loanTypeName))
        {
            throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
        }

        ILoan loan;

        if (loanTypeName == "MortgageLoan")
        {
            loan = new MortgageLoan();
        }
        else //StudentLoan
        {
            loan = new StudentLoan();
        }

        loans.AddModel(loan);
        return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
    }

    public string ReturnLoan(string bankName, string loanTypeName)
    {
        var loan = loans.FirstModel(loanTypeName);

        if (loan is null)
        {
            string message = string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName);
            throw new ArgumentException(message);
        }

        var bank = banks.FirstModel(bankName);
        bank.AddLoan(loan);
        loans.RemoveModel(loan);

        return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
    }

    public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
    {
        string[] validClientTypes = new[] { "Student", "Adult" };

        if (!validClientTypes.Contains(clientTypeName))
        {
            throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
        }

        var bank = banks.FirstModel(bankName);

        if (clientTypeName == "Student" && bank.GetType().Name == "CentralBank")
        {
            return string.Format(OutputMessages.UnsuitableBank);
        }
        if (clientTypeName == "Adult" && bank.GetType().Name == "BranchBank")
        {
            return string.Format(OutputMessages.UnsuitableBank);
        }

        IClient client;

        if (clientTypeName == "Student")
        {
            client = new Student(clientName, id, income);
        }
        else //Adult
        {
            client = new Adult(clientName, id, income);
        }

        bank.AddClient(client);
        return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
    }

    public string FinalCalculation(string bankName)
    {
        var bank = banks.FirstModel(bankName);
        var incomeAmount = bank.Clients.Select(c => c.Income).DefaultIfEmpty(0).Sum();
        var loansAmount = bank.Loans.Select(c => c.Amount).DefaultIfEmpty(0).Sum();

        return $"The funds of bank {bankName} are {(incomeAmount + loansAmount):F2}.";
    }

    public string Statistics()
    {
        StringBuilder sb = new();

        foreach (var bank in banks.Models)
        {
            sb.AppendLine(bank.GetStatistics());
        }

        return sb.ToString().Trim();
    }
}
