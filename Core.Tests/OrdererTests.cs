using Core.Categories;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Core.Tests
{
    [TestFixture]
    public class OrdererTests
    {
        [Test]
        public void Orderer_Equals_CompareNames()
        {
            var category1regex = new RegexCategory("a", new List<Rule>(), 1, 1);
            var category2regex = new RegexCategory("b", new List<Rule>(), 1, 1);

            var category1auto = new AutoCategory("a", 1, 1, "a");
            var category2auto = new AutoCategory("b", 1, 1, "a");

            var category1composite = new CompositeCategory("a", 1, 1, new List<string>());
            var category2composite = new CompositeCategory("b", 1, 1, new List<string>());

            var orderer = new CategoriesOrderer();
            
            var regexResult = orderer.Compare(category1regex, category2regex);
            var autoResult = orderer.Compare(category1auto, category2auto);
            var compositeResult = orderer.Compare(category1composite, category2composite);

            regexResult.Should().Be(-1);
            autoResult.Should().Be(-1);
            compositeResult.Should().Be(-1);
        }

        [Test]
        public void Orderer_CompositeRegex_CompositFirst()
        {
            var category1regex = new RegexCategory("a", new List<Rule>(), 1, 1);
            var category1composite = new CompositeCategory("a", 1, 1, new List<string>());

            var orderer = new CategoriesOrderer();

            var result = orderer.Compare(category1composite, category1regex);

            result.Should().Be(-1);
        }

        [Test]
        public void Orderer_CompositeAuto_CompositFirst()
        {
            var category1auto = new AutoCategory("a", 1, 1, "a");
            var category1composite = new CompositeCategory("a", 1, 1, new List<string>());

            var orderer = new CategoriesOrderer();

            var result = orderer.Compare(category1composite, category1auto);

            result.Should().Be(-1);
        }

        [Test]
        public void Orderer_RegexAuto_RegexFirst()
        {
            var category1auto = new AutoCategory("a", 1, 1, "a");
            var category1regex = new RegexCategory("a", new List<Rule>(), 1, 1);

            var orderer = new CategoriesOrderer();

            var result = orderer.Compare(category1regex, category1auto);

            result.Should().Be(-1);
        }
    }
}
