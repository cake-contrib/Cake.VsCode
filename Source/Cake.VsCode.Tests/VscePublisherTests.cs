using Cake.Core;
using Cake.Testing;
using Xunit;

namespace Cake.VsCode.Tests
{
    public sealed class VscePublisherTests
    {
        public sealed class TheExecutable
        {
            [Fact]
            public void Should_Throw_If_Vsce_Runner_Was_Not_Found()
            {
                // Given
                var fixture = new VscePublisherFixture();
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Vsce: Could not locate executable.", result.Message);
            }

            [Theory]
            [InlineData("/bin/tools/Vsce/Vsce.cmd", "/bin/tools/Vsce/Vsce.cmd")]
            [InlineData("./tools/Vsce/Vsce.cmd", "/Working/tools/Vsce/Vsce.cmd")]
            public void Should_Use_Vsce_Runner_From_Tool_Path_If_Provided(string toolPath, string expected)
            {
                // Given
                var fixture = new VscePublisherFixture { Settings = { ToolPath = toolPath } };
                fixture.GivenSettingsToolPathExist();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Path.FullPath);
            }

            [Theory]
            [InlineData("C:/Vsce/Vsce.cmd", "C:/Vsce/Vsce.cmd")]
            public void Should_Use_Vsce_Runner_From_Tool_Path_If_Provided_On_Windows(string toolPath, string expected)
            {
                // Given
                var fixture = new VscePublisherFixture { Settings = { ToolPath = toolPath } };
                fixture.GivenSettingsToolPathExist();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_Find_Vsce_Runner_If_Tool_Path_Not_Provided()
            {
                // Given
                var fixture = new VscePublisherFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working/tools/vsce.cmd", result.Path.FullPath);
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new VscePublisherFixture();
                fixture.GivenProcessCannotStart();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Vsce: Process was not started.", result.Message);
            }

            [Fact]
            public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
            {
                // Given
                var fixture = new VscePublisherFixture();
                fixture.GivenProcessExitsWithCode(1);

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("Vsce: Process returned an error (exit code 1).", result.Message);
            }

            [Fact]
            public void Should_Set_Package_File()
            {
                // Given
                var fixture = new VscePublisherFixture { Settings = { Package = "C:/temp/package.vsix" } };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("publish --packagePath \"C:/temp/package.vsix\"", result.Args);
            }

            [Fact]
            public void Should_Set_Personal_Access_Token_File()
            {
                // Given
                var fixture = new VscePublisherFixture { Settings = { PersonalAccessToken = "ABCDEF" } };

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("publish --pat ABCDEF", result.Args);
            }
        }
    }
}