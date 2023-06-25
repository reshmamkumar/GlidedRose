using GlidedRose.Domain.BusinessLogic.Constants;
using GlidedRose.Domain.BusinessLogic.Factory;
using GlidedRose.Domain.Models;

namespace GlidedRose.Test
{
    [TestFixture]
    public class Tests
    {
        private Item GenerateItem(string name, int selllIn, int quality)
        {
            UpdateItemPolicy updateItemPolicy = new UpdateItemPolicy();
            IList<Item> items = new List<Item>() { new Item { Name = name, SellIn = selllIn, Quality = quality } };
            foreach (var item in items)
            {
                var policy = updateItemPolicy.Create(item);
                policy.UpdateItem(item);
            }
            return items[0];
        }

        [Test]
        public void QualitySellInLowerByOneForRegularItem()
        {
            Item item = GenerateItem(GlidedRoseLogicConstants.GENERIC_ITEM, 15, 25);
            Assert.That(item.SellIn, Is.EqualTo(14));
            Assert.That(item.Quality, Is.EqualTo(24));
        }

        [Test]
        public void QualityDegradeTwiceAsFastAfterSellInDatePassed()
        {
            Item item = GenerateItem(GlidedRoseLogicConstants.GENERIC_ITEM, 0, 25);
            Assert.That(item.Quality, Is.EqualTo(23));
        }

        [Test]
        public void QualityOfItemIsNeverNegative()
        {
            Item item = GenerateItem(GlidedRoseLogicConstants.GENERIC_ITEM, 15, 0);
            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void QualityOfItemPastSellInDateIsNeverNegative()
        {
            Item item = GenerateItem(GlidedRoseLogicConstants.GENERIC_ITEM, 0, 0);
            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void QualityOfAgedBrieIncreaseOverTime()
        {
            Item item = GenerateItem(GlidedRoseLogicConstants.AGED_BRIE, 15, 25);
            Assert.That(item.Quality, Is.EqualTo(26));
        }
        [Test]
        public void QualityOfSulfurasCanNeverBeChanged()
        {
            Item item = GenerateItem(GlidedRoseLogicConstants.SULFURAS, 15, 80);
            Assert.That(item.Quality, Is.EqualTo(80));
        }

        [Test]
        public void QualityOfBackStagePassesIncreaseLikeNormalProduct()
        {
            Item item = GenerateItem(GlidedRoseLogicConstants.BACKSTAGE_PASSES, 15, 25);
            Assert.That(item.Quality, Is.EqualTo(26));
        }

        [Test]
        public void QualityOfBackStagePassesIncreaseByTwoWhenSellInDateLessThanTen()
        {
            Item item = GenerateItem(GlidedRoseLogicConstants.BACKSTAGE_PASSES, 10, 25);
            Assert.That(item.Quality, Is.EqualTo(27));
        }


        [Test]
        public void QualityOfBackStagePassesIncreaseByThreeWhenSellInDateLessThanFive()
        {
            Item item = GenerateItem(GlidedRoseLogicConstants.BACKSTAGE_PASSES, 5, 25);
            Assert.That(item.Quality, Is.EqualTo(28));
        }
        [Test]
        public void QualityOfBackStagePassesDropsToZeroPastSellInDate()
        {
            Item item = GenerateItem(GlidedRoseLogicConstants.BACKSTAGE_PASSES, 0, 25);
            Assert.That(item.Quality, Is.EqualTo(0));
        }
        [Test]
        public void QualityDegradeTwiceAsFastForConjured()
        {
            Item item = GenerateItem(GlidedRoseLogicConstants.CONJURED, 15, 25);
            Assert.That(item.Quality, Is.EqualTo(23));
        }
    }
}