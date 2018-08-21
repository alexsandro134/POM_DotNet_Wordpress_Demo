using Microsoft.VisualStudio.TestTools.UnitTesting;
using POM_SELENIUM;

namespace Tests.Smoke_Tests
{
    [TestClass]
    public class AllPostsTests : BaseTest
    {
        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            ListPostPage.GoTo(PostType.Posts);
            ListPostPage.StoreCount();
            PostCreator.CreatePost();
            ListPostPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostPage.PreviousPostCount + 1, ListPostPage.CurrentPostCount, "Could of posts did not increase");
            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));
            ListPostPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostPage.PreviousPostCount, ListPostPage.CurrentPostCount, "Could not trash post");
        }

        [TestMethod]
        public void Can_Search_Posts()
        {
            PostCreator.CreatePost();
            ListPostPage.SearchForPost(PostCreator.PreviousTitle);
            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));
        }
    }
}
