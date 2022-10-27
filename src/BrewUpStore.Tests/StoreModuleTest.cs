using System.Net;

namespace BrewUpStore.Tests;

[Collection("Integration Fixture")]
public class StoreModuleTest
{
    private readonly AppHttpClientFixture _integrationFixture;

    public StoreModuleTest(AppHttpClientFixture integrationFixture)
    {
        _integrationFixture = integrationFixture;
    }

    [Fact]
    public async Task Can_Get_Ingredients()
    {
        var result = await _integrationFixture.Client.GetAsync("/v1/store/ingredients");

        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }
}