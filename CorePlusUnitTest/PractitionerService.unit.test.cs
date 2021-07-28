//using CorePlusWebApi.BLL;
//using CorePlusWebApi.BLL.Services;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;
//using System.Collections.Generic;

//namespace CorePlusUnitTest
//{
//    [TestClass]
//    public class PractitionerServiceTest
//    {
//        private Mock<IDataReadService<List<Practitioner>>> mockDataService;
//        private PractitionerService service;
//        [TestInitialize]
//        public void BeforeEach()
//        {
//            mockDataService = new Mock<IDataReadService<List<Practitioner>>>();
//            mockDataService.Setup(o => o.Read(It.IsAny<string>())).Returns(new List<Practitioner>() {
//                new Practitioner(){
//                    Id = 1,
//                    Name = "Name 1",
//                    Appointments = new List<Appointment>(){
//                        new Appointment()
//                        {
//                            Id = 1,
//                            ClientName = "Client Name",
//                            Cost = 1,
//                            Revenue = 2,
//                            Date = new DateTime(2015, 1, 1),
//                            Type = "Type 1",
//                            Duration = 2
//                        }
//                    }

//                }, new Practitioner(){
//                    Id = 2,
//                    Name = "Name 2",
//                    Appointments = new List<Appointment>(){
//                          new Appointment()
//                        {
//                            Id = 1,
//                            ClientName = "Client Name",
//                            Cost = 1,
//                            Revenue = 2,
//                           Date = new DateTime(2016, 1, 1),
//                            Type = "Type 2",
//                            Duration = 2
//                        }
//                    }

//                }, new Practitioner(){
//                    Id = 3,
//                    Name = "Name 3",
//                    Appointments = new List<Appointment>(){
//                           new Appointment()
//                        {
//                            Id = 1,
//                            ClientName = "Client Name",
//                            Cost = 1,
//                            Revenue = 2,
//                            Date = new DateTime(2017, 1, 1),
//                            Type = "Type 3",
//                            Duration = 2
//                        }
//                    }

//                }, new Practitioner(){
//                    Id = 4,
//                    Name = "Name 4",
//                    Appointments = new List<Appointment>(){
//                           new Appointment()
//                        {
//                            Id = 1,
//                            ClientName = "Client Name",
//                            Cost = 1,
//                            Revenue = 2,
//                            Date = new DateTime(2018, 1, 1),
//                            Type = "Type 4",
//                            Duration = 2
//                        }
//                    }
//                }
//            });
//            service = new PractitionerService(mockDataService.Object);
//        }

//        [TestMethod]
//        public void GetPractitioners_searchTextIsValid_Return1()
//        {            
           
//            var result = service.GetPractitioners("1");
//            Assert.AreEqual(1, result.Count);
//            Assert.AreEqual(1, result[0].Id);
//        }
//        [TestMethod]
//        public void GetPractitioners_searchTextIsEmpty_ReturnAll()
//        {
//            var result = service.GetPractitioners("");
//            Assert.AreEqual(4, result.Count);
//        }

//        [TestMethod]
//        public void GetPractitioners_start_Return1()
//        {
//            var result = service.GetPractitioners("", new DateTime(2017,12,1));
//            Assert.AreEqual(1, result.Count);
//            Assert.AreEqual(4, result[0].Id);
//        }

//        [TestMethod]
//        public void GetPractitioners_end_Return1()
//        {
//            var result = service.GetPractitioners("", null, new DateTime(2015, 12, 1));
//            Assert.AreEqual(1, result.Count);
//            Assert.AreEqual(1, result[0].Id);
//        }

//        [TestMethod]
//        public void GetPractitioners_type_Return1()
//        {
//            var result = service.GetPractitioners("", null, null, "3");
//            Assert.AreEqual(1, result.Count);
//            Assert.AreEqual(3, result[0].Id);
//        }
//    }
//}
