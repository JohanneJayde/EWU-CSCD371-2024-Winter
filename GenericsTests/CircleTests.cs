﻿using Xunit;

namespace GenericsHomework.Tests;

    public class CircleTests
    {

        [Fact]
        public void Constructor_ValidItem_SetsDataSuccessfully()
        {
            Circle<string> circle = new("Names",["Johanne"]);
            Assert.Contains("Johanne", circle.Elements);

        }


        [Fact]
        public void Constructor_NullName_ThrowsArgumentExceptionNull()
        {
            Assert.Throws<ArgumentNullException>(()=> new Circle<string>(null!, ["Dogs"]));

        }

    [Fact]
        public void Add_NewElementEmptyElements_AddsDataSuccessfully()
        {
            Circle<int> circle = new("Empty");

            circle.Add(3);

            Assert.Equal(3, circle.Elements.ElementAt(0));
            Assert.Single(circle.Elements);

        }

        [Fact]
        public void Add_NullElement_ThrowsArgumentNullException()
        {
            Circle<string> circle = new("NullDataElements");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => circle.Add(null!));

        }

        [Fact]
        public void Add_DuplicateElement_ThrowsInvalidOperationException()
        {
        Circle<int> circle = new("Numbers",[3]);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => circle.Add(3));

        }

        [Fact]
        public void Add_MultipleElements_AddsSuccesfully()
        {
            Circle<string> circle = new("B",["Alexa"]);

            circle.Add("Darrington");
            circle.Add("rocks!");

            Assert.Equal(3,circle.Elements.Count);
            Assert.Contains("Darrington", circle.Elements);
            Assert.Contains("rocks!", circle.Elements);
        }

        [Fact]
        public void Remove_NullData_ThrowIllegalArgumentException()
        {
        // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>  new Circle<string>("Greetings",["hi"]).Remove(null!));
        }

        [Fact]
        public void Remove_ValidData_RemovesSuccessfully()
        {
            Circle<(string,string)> circle = new("BasketBall Players",[("James", "Smith"),("Michael","Jordan")]);

            circle.Remove(("Michael","Jordan"));
            Assert.Single(circle.Elements);
            Assert.DoesNotContain(("Michael","Jordan"), circle.Elements);
        }

        [Fact]
        public void Remove_NonexistentElement_ElementsUntouched()
        {
            Circle<(string, int)> circle = new("Students",[("James Tyler", 394838), ("David West", 997821)]);

            circle.Remove(("Lebron James", 000000));
            Assert.Equal(2,circle.Elements.Count);
        }

        [Fact]
        public void ToString_NonEmptyElements_ReturnsStringElementsSuccessfully()
        {
            Circle<string> circle = new("Colors",["Blue", "Green"]);

            Assert.Equal("Colors: {Blue, Green}", circle.ToString());

        }
        [Fact]
        public void ToString_EmptyElements_ReturnsEmptyStringSuccessfully()
        {
            Circle<string> circle = new("EmptyList");

            Assert.Equal("EmptyList: {}", circle.ToString());

        }
}
