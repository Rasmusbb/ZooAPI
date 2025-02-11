
using Xunit;
using ZooAPI.Controllers;
namespace ZooAPI;

public class ZooAPITest
{
    [Fact]
    public void TestHashing()
    {
        string raw = "Hashing";
        string expected = "89a4382b6164bfe171507d674d5673551d87274b1bfdeba70940d326b186f5ee";
        raw = UserController.Hash(raw);
        Assert.Equal(expected, raw); 
    }
}
