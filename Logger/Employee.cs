﻿
namespace Logger.Tests
{
    public record class Employee(string FirstName, string LastName) : Person(FirstName, LastName), IEntity
    {

        //Name member of IEntity should explicit becuase it has collision with Employee's name
        string IEntity.Name {get=> $"{nameof(Employee)}: {Name}"; }

        public Guid Id { get; init; }

        public override string ToString() => base.ToString();


    }
}