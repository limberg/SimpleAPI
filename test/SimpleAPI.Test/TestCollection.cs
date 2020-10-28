using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SimpleAPI.Test
{
    [CollectionDefinition("Integration Tests")]
    public class TestCollection :ICollectionFixture<WebApplicationFactory<SimpleAPI.Startup>>
    {

    }    
}