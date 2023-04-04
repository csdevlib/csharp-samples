using FluentAssertions;
using Graphapi.Api;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System;
using System.Linq;
using Xunit;

namespace Graphapi.TestProject
{
    public class UnitTest1:IClassFixture<TestFixtureBase<Startup>>
    {
        private readonly TestFixtureBase<Startup> testFixtureBase;

        public UnitTest1(TestFixtureBase<Startup> testFixtureBase)
        {
            this.testFixtureBase = testFixtureBase;
        }

        [Fact]
        public async void Test1()
        {
            var client = testFixtureBase.CreateWebApplicationFactory();

            var graphQLClient = new GraphQLHttpClient(new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("http://localhost/graphql")
            }, new NewtonsoftJsonSerializer(), client);

            var request = new GraphQLHttpRequest
            {
                Query = @"{
                          products {
                                            id,
                                            name,
                                            price,
                                            description,
                                            components {
                                            id,
                                            name,
                                            description
                                        }
                                    }
                         }"                
            };

            var response = await graphQLClient.SendQueryAsync<ProductQueryResponse>(request);

            var product = response.Data.Products.FirstOrDefault(x => x.Id == 1);

            product.Description.Should().Be("Description 1");
        }
    }
}
