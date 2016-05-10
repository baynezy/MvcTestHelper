using System.Web;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;

namespace MvcTestHelper.Controllers
{
	public class TestControllerBase
	{
		protected HttpSessionStateBase Session;

		[SetUp]
		public virtual void Setup()
		{
			Session = new MockHttpSession();
		}

		protected void EnrichWithContext(Controller controller)
		{
			var context = new Mock<ControllerContext>();
			context.Setup(m => m.HttpContext.Session).Returns(Session);

			controller.ControllerContext = context.Object;
		}
	}
}
