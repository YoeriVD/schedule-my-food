using FluentAssertions;
using NUnit.Framework;
using ScheduleMyFood.Main;
using ScheduleMyFood.Tests.IoC;

namespace ScheduleMyFood.Tests.Main
{
	[TestFixture ()]
	public class MainViewModelTests
	{
	    private IMainViewModel _sut;


	    [TestFixtureSetUp]
	    public void Initialize()
	    {
	        _sut = IoCContainer.CreateTestSubject<IMainViewModel>();
	    }

		[Test ()]
		public void MainViewModel_should_contain_a_maint_text ()
		{
		    _sut.MainText.Should().Be("Hello!");
		}
	}
}

