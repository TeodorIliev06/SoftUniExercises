using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository repo;

        [SetUp]
        public void Setup()
        {
            repo = new InfluencerRepository();
        }

        [Test]
        public void RegisterInfluencer_ShouldAddInfluencer_WhenNew()
        {
            // Arrange
            var influencer = new Influencer("newUser", 100);

            // Act
            var result = repo.RegisterInfluencer(influencer);

            // Assert
            StringAssert.Contains("Successfully added", result);
            Assert.AreEqual(1, repo.Influencers.Count());
        }

        [Test]
        public void RegisterInfluencer_ShouldThrow_WhenInfluencerExists()
        {
            // Arrange
            var influencer = new Influencer("existingUser", 100);
            repo.RegisterInfluencer(influencer);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => repo.RegisterInfluencer(influencer));
            StringAssert.Contains("already exists", ex.Message);
        }

        [Test]
        public void RegisterInfluencer_WhenNull_ShouldThrowError()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.RegisterInfluencer(null));
        }

        [Test]
        public void RemoveInfluencer_ShouldDecreaseCount_WhenExists()
        {
            // Arrange
            var influencer = new Influencer("userToRemove", 100);
            repo.RegisterInfluencer(influencer);

            // Act
            var result = repo.RemoveInfluencer("userToRemove");

            // Assert
            Assert.IsTrue(result);
            Assert.IsEmpty(repo.Influencers);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void RemoveInfluencer_WhenUsernameIsNullOrWhiteSpace_ShouldThrowError(string username)
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.RemoveInfluencer(username));
        }

        [Test]
        public void GetInfluencerWithMostFollowers_ShouldReturnCorrectInfluencer()
        {
            // Arrange
            repo.RegisterInfluencer(new Influencer("user1", 100));
            repo.RegisterInfluencer(new Influencer("user2", 200)); // This user has the most followers

            // Act
            var result = repo.GetInfluencerWithMostFollowers();

            // Assert
            Assert.AreEqual("user2", result.Username);
        }

        [Test]
        public void GetInfluencer_ShouldReturnCorrectInfluencer_WhenExists()
        {
            // Arrange
            var influencer = new Influencer("userToFind", 100);
            repo.RegisterInfluencer(influencer);

            // Act
            var result = repo.GetInfluencer("userToFind");

            // Assert
            Assert.AreEqual(influencer, result);
        }

        [Test]
        public void GetInfluencer_WhenUsernameNotFound_ShouldReturnNull()
        {
            // Act
            var result = repo.GetInfluencer("nonexistent");

            // Assert
            Assert.IsNull(result);
        }
    }
}