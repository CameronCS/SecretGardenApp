using APIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILibTests {
    internal class APIResponseComparison {
        public static bool CompareLoginResponse(APILoginResponse expected, APILoginResponse actual) {
            bool cTest = expected.Code == actual.Code;
            if (!cTest) {
                Console.WriteLine($"Failed Response Code: [Expected<{expected.Code}>] | [Actual<{actual.Code}>]S");
                return false;
            }

            bool mTest = expected.Message == actual.Message;
            if (!mTest) {
                Console.WriteLine($"Failed Response Message: [Expectred<{expected.Message}>] | [Actual<{actual.Message}>]");
                return false;
            }

            if (expected.User._ID != actual.User._ID) {
                Console.WriteLine($"Failed User ID: [Expected<{expected.User._ID}>] | [Actual<{actual.User._ID}>]");
                return false;
            }
            if (expected.User.Username != actual.User.Username) {
                Console.WriteLine($"Failed User Username: [Expected<{expected.User.Username}>] | [Actual<{actual.User.Username}>]");
                return false;
            }
            if (expected.User.FirstName != actual.User.FirstName) {
                Console.WriteLine($"Failed User FirstName: [Expected<{expected.User.FirstName}>] | [Actual<{actual.User.FirstName}>]");
                return false;
            }
            if (expected.User.LastName != actual.User.LastName) {
                Console.WriteLine($"Failed User LastName: [Expected<{expected.User.LastName}>] | [Actual<{actual.User.LastName}>]");
                return false;
            }
            if (expected.User.Password != actual.User.Password) {
                Console.WriteLine($"Failed User Password: [Expected<{expected.User.Password}>] | [Actual<{actual.User.Password}>]");
                return false;
            }
            if (expected.User.IsAdmin != actual.User.IsAdmin) {
                Console.WriteLine($"Failed User IsAdmin: [Expected<{expected.User.IsAdmin}>] | [Actual<{actual.User.IsAdmin}>]");
                return false;
            }

            return true;
        }

        public static bool CompareGetChildResponse(APIGetChildrenResponse expected, APIGetChildrenResponse actual) {
            bool cTest = expected.Code == actual.Code;
            if (!cTest) {
                Console.WriteLine("Failed Code Comparison");
                Console.WriteLine($"Codes    : [Expected<{expected.Code}] | [Actual<{actual.Code}>]S");
                return false;
            }

            bool mTest = expected.Message == actual.Message;
            if (!mTest) {
                Console.WriteLine("Failed Message Comparison");
                Console.WriteLine($"Messages : [Expectred<{expected.Message}>] | [Actual<{actual.Message}>]");
                return false;
            }

            bool cntTest = expected.Children.Count == actual.Children.Count;
            if (!cntTest) {
                Console.WriteLine("Failed And Inital Comparison");
                Console.WriteLine($"Count : [Expectred<{expected.Children.Count}>] | [Actual<{actual.Children.Count}>]");
                return false;
            }

            for (int i = 0; i < expected.Children.Count; i++) {
                var expectedChild = expected.Children[i];
                var actualChild = actual.Children[i];

                bool chTest =   (expectedChild._ID       == actualChild._ID) &&
                                (expectedChild.ImagePath == actualChild.ImagePath) &&
                                (expectedChild.FirstName == actualChild.FirstName) &&
                                (expectedChild.LastName  == actualChild.LastName) &&
                                (expectedChild.ClassName == actualChild.ClassName) &&
                                (expectedChild.ParentID1 == actualChild.ParentID1) &&
                                (expectedChild.ParentID2 == actualChild.ParentID2);

                if (!chTest) {
                    Console.WriteLine($"Failed In Children [IDX<{i}>]");
                    Console.WriteLine($"ID        : [Expected<{expectedChild._ID}>] | [Actual<{actualChild._ID}>]");
                    Console.WriteLine($"ImagePath : [Expected<{expectedChild.ImagePath}>] | [Actual<{actualChild.ImagePath}>]");
                    Console.WriteLine($"FirstName : [Expected<{expectedChild.FirstName}>] | [Actual<{actualChild.FirstName}>]");
                    Console.WriteLine($"LastName  : [Expected<{expectedChild.LastName}>] | [Actual<{actualChild.LastName}>]");
                    Console.WriteLine($"ClassName : [Expected<{expectedChild.ClassName}>] | [Actual<{actualChild.ClassName}>]");
                    Console.WriteLine($"ParentID1 : [Expected<{expectedChild.ParentID1}>] | [Actual<{actualChild.ParentID1}>]");
                    Console.WriteLine($"ParentID2 : [Expected<{expectedChild.ParentID2}>] | [Actual<{actualChild.ParentID2}>]");
                    return false;
                }
            }
            return true;
        }

    }
}
