using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShop.Domain.Abstract;
using OnlineShop.Domain.Entities;
using System.Linq;
using OnlineShop.WebUI.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineShop.WebUI.Models;

namespace OnlineShop.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    //Arange
        //    Mock<IProductRepository> mock = new Mock<IProductRepository>();
        //    mock.Setup(p => p.Products).Returns(
        //        new Product[]
        //        {
        //            new Product{ProductID=1, Name="P1"},
        //            new Product{ProductID=2, Name="P2"},
        //            new Product{ProductID=3, Name="P3"},
        //            new Product{ProductID=4, Name="P4"},
        //            new Product{ProductID=5, Name="P5"},
        //            new Product{ProductID=6, Name="P6"},
        //            new Product{ProductID=7, Name="P7"},
        //            new Product{ProductID=8, Name="P8"},
        //            new Product{ProductID=9, Name="P9"},
        //            new Product{ProductID=10, Name="P10"}
        //        }.AsQueryable()
        //        );
        //    ProductController controller = new ProductController(mock.Object);
        //    controller.pageSize = 3;
        //    //Act
        //    IEnumerable<Product> result =(IEnumerable<Product>)controller.List(2).Model;
        //    Product[] prodArray = result.ToArray();
        //    //Assert
        //    Assert.IsTrue(prodArray.Length == 3);
        //    Assert.AreEqual(prodArray[0].Name, "P4");
        //    Assert.AreEqual(prodArray[1].Name,"P5");
        //}
        [TestMethod]
        public void TestPageLink()
        {
            //Arrange
            HtmlHelper helper = null;
            PageInfo pInfo = new PageInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            //Act
            Func<int, string> func = x => "Page" + x;
            MvcHtmlString result = helper.PageLink(pInfo, func);
            //Assert
            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>" + @"<a class=""Selected"" href=""Page2"">2</a>" + @"<a href=""Page3"">3</a>");
        }
        [TestMethod]
        public void TestList()
        {
            //Arange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns(
                new Product[]
                {
                    new Product{ProductID=1, Name="P1",Category="C1"},
                    new Product{ProductID=2, Name="P2",Category="C2"},
                    new Product{ProductID=3, Name="P3",Category="C2"},
                    new Product{ProductID=4, Name="P4",Category="C1"},
                    new Product{ProductID=5, Name="P5",Category="C1"},
                    new Product{ProductID=6, Name="P6",Category="C3"},
                    new Product{ProductID=7, Name="P7",Category="C4"},
                    new Product{ProductID=8, Name="P8",Category="C5"},
                    new Product{ProductID=9, Name="P9",Category="C2"},
                    new Product{ProductID=10, Name="P10",Category="C1"}
                }.AsQueryable()
                );
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;
            //Act
            ProductListPageInfoToView result = (ProductListPageInfoToView)controller.List("C2",1).Model;
            Product[] prodArray = result.Products.ToArray();
            //Assert
            Assert.IsTrue(prodArray[0].Name == "P2" && prodArray[0].Category == "C2");
            Assert.IsTrue(prodArray[1].Name == "P3" && prodArray[0].Category == "C2");
        }

        [TestMethod]
        public void TestPages()
        {
            //Arange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns(
                new Product[]
                {
                    new Product{ProductID=1, Name="P1",Category="C1"},
                    new Product{ProductID=2, Name="P2",Category="C2"},
                    new Product{ProductID=3, Name="P3",Category="C2"},
                    new Product{ProductID=4, Name="P4",Category="C1"},
                    new Product{ProductID=5, Name="P5",Category="C1"},
                    new Product{ProductID=6, Name="P6",Category="C3"},
                    new Product{ProductID=7, Name="P7",Category="C4"},
                    new Product{ProductID=8, Name="P8",Category="C5"},
                    new Product{ProductID=9, Name="P9",Category="C2"},
                    new Product{ProductID=10, Name="P10",Category="C1"}
                }.AsQueryable()
                );
            ProductController controller = new ProductController(mock.Object);
            controller.pageSize = 3;
            //Act
            ProductListPageInfoToView result = (ProductListPageInfoToView)controller.List("C2", 1).Model;
            ProductListPageInfoToView result2= (ProductListPageInfoToView)controller.List(null,1).Model;
            Product[] prodArray = result.Products.ToArray();
            //Assert
            Assert.AreEqual(result.PageInfo.TotalPage(), 1);
            Assert.AreEqual(result2.PageInfo.TotalPage(), 4);
        }


    }
}
