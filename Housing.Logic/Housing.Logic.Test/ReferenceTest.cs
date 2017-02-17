using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Housing.Logic.Test
{
    public class ReferenceTest
    {              
        [Fact]
        public void testupdate()
        {
            Domain.DataAccess data = new Domain.DataAccess();
            var old = data.GetItemsFromApi<List<Domain.DataTransferObjects.GenderDTO>>("gender").Result.Find(m => m.Name.Equals("male v2"));
            var oldId = old.Name;
            old.Name = "male";
            var actual = data.UpdateItemUsingApi(old, "gender", oldId).Result;
            Assert.True(actual);
        }

        #region revashare-srv tests
        /*
        [Fact]
        public void test_GetVehicles()
        {
            RevaShareDataServiceClient dataClient = new RevaShareDataServiceClient();

            List<VehicleDAO> getVehicles = dataClient.GetVehicles().ToList();

            Assert.NotNull(getVehicles);

        }
        [Fact]
        public void test_GetVehicles_RiderLogic()
        {
            ServiceClient sc = new ServiceClient();
            RiderLogic rdrLogic = new RiderLogic(sc);
            var a = rdrLogic.getVehicles();


            Assert.NotEmpty(a);

        }

        [Fact]
        public void test_getVehicleByOwner_RiderLogic()
        {
            ServiceClient sc = new ServiceClient();
            RiderLogic rdrLogic = new RiderLogic(sc);
            var name = new UserDTO { Name = "name 4" };
            var a = rdrLogic.getVehicleByOwner(name);


            Assert.Null(a);

        }


        [Fact]
        public void Test_ViewPassengers()
        {
            var mock = new Mock<IDriverRepository>();
            mock.Setup(m => m.ViewPassengers(new RideDTO()));


            var ctrl = new DriverController(mock.Object);
            ctrl.Request = Substitute.For<HttpRequestMessage>();
            ctrl.Configuration = Substitute.For<HttpConfiguration>();
            HttpResponseMessage res = ctrl.ViewPassengers(new RideDTO());

            Assert.Equal(res.StatusCode, HttpStatusCode.OK);
        }

        */
        #endregion
    }
}
