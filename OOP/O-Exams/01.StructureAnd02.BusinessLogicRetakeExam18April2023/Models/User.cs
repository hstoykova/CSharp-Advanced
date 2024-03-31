using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models;

public class User : IUser
{
    private string firstName;
    private string lastName;
    private string drivingLicenseNumber;
    private double rating;
    private bool isBlocked;

    public User(string firstName, string lastName, string drivingLicenseNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        DrivingLicenseNumber = drivingLicenseNumber;
        Rating = 0;
        IsBlocked = false;
    }

    public string FirstName
    {
        get { return firstName; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.FirstNameNull);
            }
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.LastNameNull);
            }
            lastName = value;
        }
    }

    public string DrivingLicenseNumber
    {
        get { return drivingLicenseNumber; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
            }
            drivingLicenseNumber = value;
        }
    }

    public double Rating // Set initial value to 0 !!!
    {
        get { return rating; }
        private set
        {
            rating = value;
        }
    }

    public bool IsBlocked // Set initial value to false
    {
        get { return isBlocked; }
        private set { isBlocked = value; }
    }

    public void IncreaseRating()
    {
        Rating += 0.5;
        if (Rating > 10)
        {
            Rating = 10;
        }
    }

    public void DecreaseRating()
    {
        Rating -= 2;
        if (Rating < 0)
        {
            Rating = 0;
            IsBlocked = true;
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} Driving license: {DrivingLicenseNumber} Rating: {Rating}";
    }
}
