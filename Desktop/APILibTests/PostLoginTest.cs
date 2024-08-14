using APIHandler;

namespace APILibTests {
    [TestClass]
    public class PostLoginTest {
        private readonly APIController controller = new("http://192.168.0.187:3050");
        [TestMethod]
        public void LoginKarenSuccess() {
            bool compares = LoginKarenTestAsync().Result;

            Assert.IsTrue(compares);
        }

        private async Task<bool> LoginKarenTestAsync() {
            Dictionary<string, string> userData = new() {
                { "username", "kabotha" },
                { "password", "Password01" }
            };

            APILoginResponse actual = await controller.PostLogIn("user/login", userData);
            User expectedUser = new(
                "66ba6a8f4c5de8d09861ad8d",
                "kabotha",
                "Karen",
                "Botha",
                "$2b$10$3//aIm.0IC6JRi0aIErYcuG3whnGhKGLMza6aw5tZAO5Qhgakiv3G",
                false,
                ""
            );

            APILoginResponse expectedResponse = new(200, "User: kabotha user and password match", expectedUser);

            bool @return = APIResponseComparison.CompareLoginResponse(expectedResponse, actual);
            return @return;
        }

        [TestMethod]
        public void LoginCharlieSuccess() {
            Dictionary<string, string> userData = new() {
                { "username", "chsteyn" },
                { "password", "Password01" }
            };

            APILoginResponse actual = controller.PostLogIn("user/login", userData).Result;
            User expectedUser = new(
                "66ba6a924c5de8d09861ad8f",
                "chsteyn",
                "Charlie",
                "Steyn",
                "$2b$10$zoBEE7BLdKS/lWgD5orFV.vMFqvuxA0ib9odJVzReVnnQP0taTPv6",
                true,
                ""
            );

            APILoginResponse expectedResponse = new(200, "User: chsteyn user and password match", expectedUser);

            bool compares = APIResponseComparison.CompareLoginResponse(expectedResponse, actual);

            Assert.IsTrue(compares);
        }
        [TestMethod]
        public void LoginKarenFailed() {
            Dictionary<string, string> userData = new() {
                { "username", "kabotha" },
                { "password", "ThisIsAFakePassword" }
            };

            APILoginResponse actual = controller.PostLogIn("user/login", userData).Result;
            User expectedUser = new(
                null,
                null,
                null,
                null,
                null,
                false,
                null
            );

            APILoginResponse expectedResponse = new(401, "Username or password incorrect", expectedUser);

            bool compares = APIResponseComparison.CompareLoginResponse(expectedResponse, actual);

            Assert.IsTrue(compares);
        }

        [TestMethod]
        public void LoginCharlieFailed() {
            Dictionary<string, string> userData = new() {
                { "username", "chsteyn" },
                { "password", "ThisIsAnotherFakePassword" }
            };

            APILoginResponse actual = controller.PostLogIn("user/login", userData).Result;
            User expectedUser = new(
                null,
                null,
                null,
                null,
                null,
                false,
                null
            );

            APILoginResponse expectedResponse = new(401, "Username or password incorrect", expectedUser);

            bool compares = APIResponseComparison.CompareLoginResponse(expectedResponse, actual);

            Assert.IsTrue(compares);
        }
    }
}