using Microsoft.AspNetCore.Mvc;
using Moq;
using ShalekKavy.Api.Controllers;
using ShalekKavy.Api.Services;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using ShalekKavy.Api.Models.Enums;

namespace ShalekKavy.Api.UnitTests.Controllers
{
    public class BeveragesControlerTests
    {
        [Fact]
        public async Task GetBeverages_ReturnsSuccess()
        {
            // Arrange 
            // expected  
            var json = File.ReadAllText("./Data/Beverages.json");
            var expected = JsonConvert.DeserializeObject<List<Beverage>>(json);

            var dataProvider = new Mock<IBeverageRepository>();
            dataProvider.Setup(x => x.GetAll()).ReturnsAsync(expected);

            var controller = new BeveragesController(dataProvider.Object);

            // Act
            var response = await controller.GetBeverages();

            // Assert 
            (response as OkObjectResult).Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetBeverageById_ReturnsSuccess()
        {
            // Arrange 
            // expected 
            var expected = DataHelpers.DataHelpers.GetBeverageById();
            var id = "1";

            var dataProvider = new Mock<IBeverageRepository>();
            dataProvider.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(expected);

            var controller = new BeveragesController(dataProvider.Object);

            // Act
            var response = await controller.GetBeverageById(id);

            // Assert 
            (response as OkObjectResult).Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetByBeverageName_ReturnsSuccess()
        {
            // Arrange 
            var expectedBeverage = DataHelpers.DataHelpers.GetBeverage();

            var beverageName = "latte";

            var dataProvider = new Mock<IBeverageRepository>();

            dataProvider.Setup(it => it.GetByBeverageName(It.IsAny<string>())).ReturnsAsync(expectedBeverage);

            var controller = new BeveragesController(dataProvider.Object);

            // Act 
            var response = await controller.GetByBeverageName(beverageName);

            // Assert
            (response as OkObjectResult).Value.Should().BeEquivalentTo(expectedBeverage);
        }

        [Fact]
        public async Task GetByBeverageType_ReturnsSuccess()
        {
            // Arrange 
            var json = File.ReadAllText("./Data/Beverage.json");
            var expected = JsonConvert.DeserializeObject<List<Beverage>>(json);

            var beverageType = BeverageType.Others;

            var dataProvider = new Mock<IBeverageRepository>();

            dataProvider.Setup(it => it.GetByBeverageType(It.IsAny<BeverageType>())).ReturnsAsync(expected);

            var controller = new BeveragesController(dataProvider.Object);

            // Act 
            var response = await controller.GetByBeverageType(beverageType);

            // Assert
            (response as OkObjectResult).Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void AddBeverage_SuccessfullyAddsBeverageToDb()
        {
            // Arrange
            var json = File.ReadAllText("./Data/Beverages.json");
            var beverages = JsonConvert.DeserializeObject<List<Beverage>>(json);

            var expected = DataHelpers.DataHelpers.GetBeverage();
            expected.Id = "10";
            expected.Name = "banana milkshake";
            expected.Description = "Banana milkshake";
            expected.Ingredients = new List<string> { "banana", "milk" };

            var dataProvider = new Mock<IBeverageRepository>();

            dataProvider.Setup(it => it.GetAll()).ReturnsAsync(beverages);

            dataProvider.Setup(it => it.AddBeverage(It.IsAny<Beverage>()));

            var controller = new BeveragesController(dataProvider.Object);

            // Act 
            var response = await controller.AddBeverage(expected);

            // Assert 
            (response as OkObjectResult).Value.Should().Be(expected);
        }

        [Fact]
        public async void AddBeverage_ReturnsBadRequest()
        {
            // Arrange
            var json = File.ReadAllText("./Data/Beverages.json");
            var beverages = JsonConvert.DeserializeObject<List<Beverage>>(json);

            var beverage = beverages[0];

            var expected = "A beverage with the id you have specified already exists. Please use a unique id";

            var dataProvider = new Mock<IBeverageRepository>();

            dataProvider.Setup(it => it.GetAll()).ReturnsAsync(beverages);

            dataProvider.Setup(it => it.AddBeverage(It.IsAny<Beverage>()));

            var controller = new BeveragesController(dataProvider.Object);

            // Act 
            var response = await controller.AddBeverage(beverage);

            // Assert 
            (response as BadRequestObjectResult).Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void UpdateExistingBeverage_ReturnsSuccess()
        {
            var json = File.ReadAllText("./Data/Beverages.json");
            var beverages = JsonConvert.DeserializeObject<List<Beverage>>(json);

            var beverage = DataHelpers.DataHelpers.GetExistingBeverage();
            var id = beverage.Id;
            beverage.Name = "Water";
            beverage.Description = "Refreshing water.";
            beverage.Allergens = new List<string> { "none" };
            beverage.Ingredients = new List<string> { "none" };

            var expected = new OkResult();

            // Arrange 
            var dataProvider = new Mock<IBeverageRepository>();
            dataProvider.Setup(it => it.GetAll()).ReturnsAsync(beverages);

            dataProvider.Setup(it => it.UpdateBeverage(It.IsAny<Beverage>()));

            var controller = new BeveragesController(dataProvider.Object);

            // Act 
            var response = await controller.UpdateBeverage(beverage);

            // Assert 
            (response as OkObjectResult)?.StatusCode.Should().Be(200);
        }

        [ Fact]
        public async void UpdateExistingBeverage_ReturnsBadRequest()
        {
            // Arrange 
            var json = File.ReadAllText("./Data/Beverages.json");
            var beverages = JsonConvert.DeserializeObject<List<Beverage>>(json);
   
            var beverage = DataHelpers.DataHelpers.GetBeverage();
            beverage.Id = "34";
            var expectedValue = "A beverage with that id does not exist.";

            var dataProvider = new Mock<IBeverageRepository>();

            dataProvider.Setup(it => it.GetAll()).ReturnsAsync(beverages);
            dataProvider.Setup(it => it.UpdateBeverage(It.IsAny<Beverage>()));

            var controller = new BeveragesController(dataProvider.Object);

            // Act 
            var response = await controller.UpdateBeverage(beverage);

            // Assert 
            (response as BadRequestObjectResult).Value.Should().Be(expectedValue);
        }

        [Fact]
        public async void DeleteExistingBeverage_ReturnsSuccess()
        {
            var json = File.ReadAllText("./Data/Beverages.json");
            var beverages = JsonConvert.DeserializeObject<List<Beverage>>(json);

            var beverage = DataHelpers.DataHelpers.GetExistingBeverage();
            var id = beverage.Id;

            // Arrange 
            var dataProvider = new Mock<IBeverageRepository>();
            dataProvider.Setup(it => it.GetAll()).ReturnsAsync(beverages);

            dataProvider.Setup(it => it.DeleteBeverage(It.IsAny<Beverage>()));

            var controller = new BeveragesController(dataProvider.Object);
            // Act 
            var response = await controller.DeleteBeverage(id);

            // Assert 
            (response as OkObjectResult)?.StatusCode.Should().Be(200);
        }

        [Fact]
        public async void DeleteExistingBeverage_ReturnsBadRequest()
        {
            // Arrange 
            var json = File.ReadAllText("./Data/Beverages.json");
            var beverages = JsonConvert.DeserializeObject<List<Beverage>>(json);

            var beverage = DataHelpers.DataHelpers.GetBeverage();
            beverage.Id = "34";
            var expectedValue = "A beverage with that id does not exist.";

            var dataProvider = new Mock<IBeverageRepository>();
            dataProvider.Setup(it => it.GetAll()).ReturnsAsync(beverages);

            dataProvider.Setup(it => it.DeleteBeverage(It.IsAny<Beverage>()));

            var controller = new BeveragesController(dataProvider.Object);

            // Act 
            var response = await controller.DeleteBeverage(beverage.Id);

            // Assert 
            (response as BadRequestObjectResult).StatusCode.Should().Be(400);
            (response as BadRequestObjectResult).Value.Should().Be(expectedValue);
        }
    }
}
