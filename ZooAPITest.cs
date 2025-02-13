
using Xunit;
using ZooAPI.Controllers;
namespace ZooAPI;

public class ZooAPITest
{
    [Fact]
    public void TestHashing()
    {
        string raw = "Axolotl123";
        string salt = "F6683A44-0F0B-4C05-BC68-08DD4A903961";
        string expected = "ba983f7a870acac44aa595bc0f6f5a6643ab6c2f6bc15b8bf7cd28304fb9c02e";
        raw = UserController.Hash(raw);
        Assert.Equal(expected, raw); 
    }


}
