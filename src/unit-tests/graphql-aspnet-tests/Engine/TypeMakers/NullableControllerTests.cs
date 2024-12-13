// *************************************************************
// project:  graphql-aspnet
// --
// repo: https://github.com/graphql-aspnet
// docs: https://graphql-aspnet.github.io
// --
// License:  MIT
// *************************************************************
namespace GraphQL.AspNet.Tests.Engine.TypeMakers
{
    using System.Linq;
    using GraphQL.AspNet.Tests.Engine.TypeMakers.TestData;
    using GraphQL.AspNet.Tests.Framework;
    using NUnit.Framework;

    [TestFixture]
    public class NullableControllerTests : GraphTypeMakerTestBase
    {
        [Test]
        public void HasNullableStringArgument()
        {
            var action = GraphQLTemplateHelper.CreateActionMethodTemplate<NullableReferenceController>(nameof(NullableReferenceController.NullableString));
            var field = this.MakeGraphField(action);

            var arg = field.Arguments.Single();
            Assert.AreEqual("String", arg.TypeExpression.ToString());

            // Return type
            Assert.AreEqual("String", field.TypeExpression.ToString());
        }

        [Test]
        public void HasNonNullableStringArgument()
        {
            var action = GraphQLTemplateHelper.CreateActionMethodTemplate<NullableReferenceController>(nameof(NullableReferenceController.NonNullableString));
            var field = this.MakeGraphField(action);

            var arg = field.Arguments.Single();
            Assert.AreEqual("String!", arg.TypeExpression.ToString());

            // Return type
            Assert.AreEqual("String!", field.TypeExpression.ToString());
        }

        [Test]
        public void HasNullableEntityArgument()
        {
            var action = GraphQLTemplateHelper.CreateActionMethodTemplate<NullableReferenceController>(nameof(NullableReferenceController.NullableEntity));
            var field = this.MakeGraphField(action);

            var arg = field.Arguments.Single();
            Assert.AreEqual("Entity", arg.TypeExpression.ToString());

            // Return type
            Assert.AreEqual("Entity", field.TypeExpression.ToString());
        }

        [Test]
        public void HasNonNullableEntityArgument()
        {
            var action = GraphQLTemplateHelper.CreateActionMethodTemplate<NullableReferenceController>(nameof(NullableReferenceController.NonNullableEntity));
            var field = this.MakeGraphField(action);

            var arg = field.Arguments.Single();
            Assert.AreEqual("Entity!", arg.TypeExpression.ToString());

            // Return type
            Assert.AreEqual("Entity!", field.TypeExpression.ToString());
        }

        [Test]
        public void HasNullableListArgument()
        {
            var action = GraphQLTemplateHelper.CreateActionMethodTemplate<NullableReferenceController>(nameof(NullableReferenceController.NullableList));
            var field = this.MakeGraphField(action);

            var arg = field.Arguments.Single();
            Assert.AreEqual("[Entity!]", arg.TypeExpression.ToString());

            // Return type
            Assert.AreEqual("[Entity!]", field.TypeExpression.ToString());
        }

        [Test]
        public void HasNonNullableListArgument()
        {
            var action = GraphQLTemplateHelper.CreateActionMethodTemplate<NullableReferenceController>(nameof(NullableReferenceController.NonNullableList));
            var field = this.MakeGraphField(action);

            var arg = field.Arguments.Single();
            Assert.AreEqual("[Entity!]!", arg.TypeExpression.ToString());

            // Return type
            Assert.AreEqual("[Entity!]!", field.TypeExpression.ToString());
        }

        [Test]
        public void HasNonNullableStringActionResult()
        {
            var action = GraphQLTemplateHelper.CreateActionMethodTemplate<NullableReferenceController>(nameof(NullableReferenceController.NonNullableStringActionResult));
            var field = this.MakeGraphField(action);

            Assert.AreEqual("String!", field.TypeExpression.ToString());
        }

        [Test]
        public void HasNonNullableEntityActionResult()
        {
            var action = GraphQLTemplateHelper.CreateActionMethodTemplate<NullableReferenceController>(nameof(NullableReferenceController.NonNullableEntityActionResult));
            var field = this.MakeGraphField(action);

            Assert.AreEqual("Entity!", field.TypeExpression.ToString());
        }

        [Test]
        public void HasNonNullableInputFields()
        {
            var action = GraphQLTemplateHelper.CreateActionMethodTemplate<NullableReferenceController>(nameof(NullableReferenceController.NonNullableEntity));
            var field = this.MakeGraphField(action);

            var template = GraphQLTemplateHelper.CreateInputObjectTemplate<NullableReferenceController.Entity>();

            var arg = field.Arguments.Single();
            Assert.AreEqual("Entity!", field.TypeExpression.ToString());
        }

        [Test]
        public void BuildsSchemaWithoutErrors()
        {
            var server = new TestServerBuilder()
                .AddType<NullableReferenceController>()
                .Build();

            var types = server.Schema.KnownTypes.ToList();

            Assert.IsNotEmpty(types);
        }
    }
}