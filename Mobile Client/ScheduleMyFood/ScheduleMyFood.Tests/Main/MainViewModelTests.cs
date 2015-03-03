using FluentAssertions;
using NUnit.Framework;
using ScheduleMyFood.Recipes;

namespace ScheduleMyFood.Tests.Main
{
	[TestFixture ()]
	public class MainViewModelTests
	{
	    private IMainViewModel _sut;


	    [TestFixtureSetUp]
	    public void Initialize()
	    {
	        _sut = ViewModelTestIoCContainer.CreateTestSubject<IMainViewModel>();
	    }

		[Test ()]
		public void MainViewModel_should_contain_a_maint_text ()
		{
		    _sut.RecipeProxy.Should().NotBeNull();
		}
	}
}

