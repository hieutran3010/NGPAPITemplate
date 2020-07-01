﻿using System.Threading.Tasks;
using GraphQLDoorNet.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.GraphQL.Controllers
{
    [Route("api/graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly IResolver resolver;

        public GraphQLController(IResolver resolver)
        {
            this.resolver = resolver;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var response = await this.resolver.Resolve(this.Request.Body);

            return new ContentResult
            {
                Content = response.Content,
                ContentType = "application/json; charset=utf-8",
                StatusCode = response.StatusCode
            };
        }
    }
}