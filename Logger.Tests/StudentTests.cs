﻿using Xunit;

namespace Logger.Tests;

public class StudentTests
{
    #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void Student_NullFirstname_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Student(null, "Robertson", 39289));
    }

    [Fact]
    public void Student_NullLastName_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Student("Jeffrey", null, 39289));
    }

    [Fact]
    public void Student_NullID_ThrowsNullPointerException()
    {
        Assert.Throws<ArgumentNullException>(() => new Student("Jeffrey", "Robertson", null));
    }
    #pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

    [Fact]
    public void Name_ValidStudent_ReturnsFormattedName()
    {
        Guid testGuid = Guid.NewGuid();

        IEntity student = new Student("Jeffrey", "Robertson", 39489)
        {
            Id = testGuid,
        };

        Assert.Equal($"EntityType: Student, EntityID: {testGuid}, Name: Jeffrey Robertson, StudentID: 39489", student.Name);
    }

    [Fact]
    public void ToString_ValidStudent_ReturnsCorrectFormat()
    {
        Student emp = new("Christina", "Aguilera", 39489);

        Assert.Equal("Name: Christina Aguilera, StudentID: 39489", emp.ToString());
    }

    [Fact]
    public void Equals_SameNameAndID_ReturnsTrue()
    {

        Guid testId = Guid.NewGuid();
        Student student1 = new("James", "Baily", 46949)
        {
            Id = testId
        };
        Student student2 = new("James", "Baily", 46949)
        {
            Id = testId
        };

        Assert.True(student1.Equals(student2));
        Assert.True(student1 == student2);


    }

    [Fact]
    public void Equals_DifferntEmployeeProperties_ReturnsFalse()
    {
        var student = new Student("Thomas", "Young", 11123)
        {
            Id = Guid.NewGuid(),
        };

        Student studentDifferentFirstName = student with { FirstName = "John", };
        Student studentDifferentId = student with { Id = Guid.NewGuid(), };
        Student studentDifferentStudentId = student with { StudentID = 1092109 };

        Assert.False(student.Equals(studentDifferentFirstName));
        Assert.False(student == studentDifferentId);
        Assert.NotEqual(student, studentDifferentStudentId);


    }

}

