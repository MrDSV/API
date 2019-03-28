using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using IdentityModel;
using MongoDB.Driver.Core.Authentication;

namespace ToDoAPI.Configuration
{
    class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[]
            {
                new ApiResource("todoResources", "ToDo Resources")
            };
        }

        public static IEnumerable<IdentityServer4.Models.Client> Clients()
        {
            return new[]
            {
                new IdentityServer4.Models.Client
                {
                    ClientId = "todoResources",
                    ClientSecrets = new[] {new Secret("SKB Kontur".Sha256())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new[] {"todoResources"}
                }
            };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[]
            {
                new TestUser
                {
                    SubjectId = "User1",
                    Username = "m1@mail.ru",
                    Password = "password1",
                },

                new TestUser
                {
                    SubjectId = "User2",
                    Username = "m2@mail.ru",
                    Password = "password2",
                },

                new TestUser
                {
                    SubjectId = "User3",
                    Username = "m3@mail.ru",
                    Password = "password3",
                }
            };
        }
    }
}
