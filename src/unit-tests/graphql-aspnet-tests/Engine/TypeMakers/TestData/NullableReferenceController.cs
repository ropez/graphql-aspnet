// *************************************************************
// project:  graphql-aspnet
// --
// repo: https://github.com/graphql-aspnet
// docs: https://graphql-aspnet.github.io
// --
// License:  MIT
// *************************************************************

// Enabling the nullable reference feature makes the type engine expose reference types
// like String and List as non-null, unless annotated with the nullable (?) operator.
#nullable enable

namespace GraphQL.AspNet.Tests.Engine.TypeMakers.TestData
{
    using System.Collections.Generic;
    using GraphQL.AspNet.Attributes;
    using GraphQL.AspNet.Controllers;
    using GraphQL.AspNet.Interfaces.Controllers;

    public class NullableReferenceController : GraphController
    {
        [Query]
        public string? NullableString(string? arg)
        {
            return arg;
        }

        [Query]
        public string NonNullableString(string arg)
        {
            return arg;
        }

        [Mutation]
        public Entity? NullableEntity(Entity? arg)
        {
            return arg;
        }

        [Mutation]
        public Entity NonNullableEntity(Entity arg)
        {
            return arg;
        }

        [Mutation]
        public List<Entity>? NullableList(List<Entity>? arg)
        {
            return arg;
        }

        [Mutation]
        public List<Entity> NonNullableList(List<Entity> arg)
        {
            return arg;
        }

        [Mutation("nonNullableStringActionResult", typeof(string))]
        public IGraphActionResult NonNullableStringActionResult()
        {
            return BadRequest("");
        }

        [Mutation("nonNullableEntityActionResult", typeof(Entity))]
        public IGraphActionResult NonNullableEntityActionResult()
        {
            return BadRequest("");
        }

        [Mutation("nonNullableListActionResult", typeof(List<Entity>))]
        public IGraphActionResult NonNullableListActionResult()
        {
            return BadRequest("");
        }

        [GraphType(InputName = nameof(Entity))]
        public class Entity
        {
            public required int Id { get; init; }
        }
    }
}