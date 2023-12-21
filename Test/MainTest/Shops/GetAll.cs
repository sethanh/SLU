using SERVICE.Dtos.Results;
using SERVICE.Dtos.Shops;
using Test.Setup;

namespace Test.MainTest.Shops;

public class GetAll : MainTestBase
{
    private const string API_PATH = "/Shops";

    public GetAll(MainApp mainApp) : base(mainApp)
    {
    }

    public override Task SeedTestData()
    {
        return Task.CompletedTask;
    }

    [Fact]
    public async Task Get_All_Shop()
    {
        var response = await AppClient.GetAsync($"{API_PATH}");
        var responseData = await response.Content.ReadAsAsync<ActionResultDto<ShopDto>>();

        Assert.NotNull(responseData.Data);
        Assert.Equal(MainSession.Shop.Id, responseData.Data.Id);
        Assert.Equal(MainSession.Shop.Name, responseData.Data.Name);
    }

    [Fact]
    public async Task Get_By_ShopId()
    {
        var response = await AppClient.GetAsync($"{API_PATH}/{MainSession.Shop.Id}");
        var responseData = await response.Content.ReadAsAsync<ActionResultDto<ShopDto>>();

        Assert.NotNull(responseData.Data);
        Assert.Equal(MainSession.Shop.Id, responseData.Data.Id);
        Assert.Equal(MainSession.Shop.Name, responseData.Data.Name);
    }
}
