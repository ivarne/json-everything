using Json.Schema.CodeGeneration.Language;

namespace Json.Schema.CodeGeneration.Tests;

public static class AssertHelpers
{
	public static void VerifyCSharp(JsonSchema schema, string expected)
	{
		var code = schema.GenerateCode(CodeWriters.CSharp);

		Console.WriteLine(code);
		Assert.AreEqual(expected, code);
	}

	public static void VerifyFailure(JsonSchema schema)
	{
		var ex = Assert.Throws<UnsupportedSchemaException>(() =>
		{
			var actual = schema.GenerateCode(CodeWriters.CSharp);

			Console.WriteLine(actual);
		});

		Console.WriteLine(ex);
	}
}