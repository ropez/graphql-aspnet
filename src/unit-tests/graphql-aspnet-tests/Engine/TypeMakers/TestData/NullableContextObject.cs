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

    public class NullableContextObject
    {
        public required int NonNullInteger { get; set; }

        public int? NullableInteger { get; set; }

        public required string NonNullString { get; set; }

        public string? NullableString { get; set; }

        public required List<string> NonNullListNonNullItems { get; set; }

        public List<string>? NullableListNonNullItems { get; set; }

        // Annotation is required here, because we assume list items are non-null
        [GraphField(TypeExpression = "[Type]!")]
        public required List<string?> NonNullListNullableItems { get; set; }

        // Annotation is required here, because we assume list items are non-null
        [GraphField(TypeExpression = "[Type]")]
        public List<string?>? NullableListNullableItems { get; set; }

        [GraphField]
        public string NonNullMethod() => "";

        [GraphField]
        public string? NullableMethod() => "";
    }
}