using APIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILibTests {
    [TestClass]
    public class GetChildrenTest {
        private readonly APIController controller = new("http://192.168.0.187:3050");

        [TestMethod]
        public void TestGetChildrenHasData() {
            APIGetChildrenResponse actual = controller.GetChildren("user/children/66ba6a8f4c5de8d09861ad8d").Result;

            APIGetChildrenResponse expected = new(
                200,
                "Children found",
                [
                    new() {
                        _ID = "66bbbc4f29ecb3926e005cf7",
                        ImagePath = "http://192.168.0.187:3050/1723579471208.jpg",
                        FirstName = "Peter",
                        LastName = "Botha",
                        ClassName = "Dinosaur Class",
                        ParentID1 = "66ba6a8f4c5de8d09861ad8d",
                        ParentID2 = "N/A"
                    },
                    new() {
                        _ID = "66bbbc5f29ecb3926e005cf9",
                        ImagePath = "http://192.168.0.187:3050/1723579487840.jpg",
                        FirstName = "John",
                        LastName = "Botha",
                        ClassName ="Butterfly",
                        ParentID1 = "66ba6a8f4c5de8d09861ad8d",
                        ParentID2 = "N/A"
                    }
                ]
            );

            bool comaparison = APIResponseComparison.CompareGetChildResponse(expected, actual);
            Assert.IsTrue(comaparison);
        }
    }
}
