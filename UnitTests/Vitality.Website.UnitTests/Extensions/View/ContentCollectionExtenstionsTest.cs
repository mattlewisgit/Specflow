using System.Collections.Generic;
using System.Linq;
using Moq;
using Shouldly;
using Vitality.Website.Areas.Presales.ComponentTemplates.Articles;
using Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection;
using Vitality.Website.Extensions;
using Vitality.Website.Extensions.Views;
using Xunit;

namespace Vitality.Website.UnitTests.Extensions.View
{
    public class ContentCollectionExtenstionsTest
    {
        public class GetContentItemsAsOneListTest
        {
            private ContentCollection _contentCollection;

            public GetContentItemsAsOneListTest()
            {
                _contentCollection = new ContentCollection
                {
                    LargeArticles = new List<LargeArticle> {new LargeArticle {SortOrder = 4}},
                    MediumArticles = new List<MediumArticle> {new MediumArticle {SortOrder = 0}},
                    SmallArticles = new List<SmallArticle> {new SmallArticle {SortOrder = 2}},
                    SocialMediaSections = new List<SocialMediaSection> {new SocialMediaSection {SortOrder = 1}},
                    MpuSections = new List<MpuSection> {new MpuSection {SortOrder = 3}}
                };
            }

            [Fact]
            public void ContentItems_should_be_returned_in_one_list()
            {
                _contentCollection.GetContentItemsAsOneList().Count().ShouldBe(5);
            }

            [Fact]
            public void Returned_list_should_contain_correct_partial_view_name()
            {
                var result = _contentCollection.GetContentItemsAsOneList().ToList();
                result.First(r=>r.Item.GetType()==typeof(LargeArticle)).PartialView.ShouldBe("_LargeArticle");
                result.First(r => r.Item.GetType() == typeof(MediumArticle)).PartialView.ShouldBe("_MediumArticle");
                result.First(r => r.Item.GetType() == typeof(SmallArticle)).PartialView.ShouldBe("_SmallArticle");
                result.First(r => r.Item.GetType() == typeof(SocialMediaSection)).PartialView.ShouldBe("_SocialMedias");
                result.First(r => r.Item.GetType() == typeof(MpuSection)).PartialView.ShouldBe("_Mpus");
            }

            [Fact]
            public void Returned_list_should_be_sorted_by_sort_order()
            {
                var result = _contentCollection.GetContentItemsAsOneList().ToList();
                for (var i = 0; i < result.Count;i++)
                {
                    result[i].SortOrder.ShouldBe(i);
                }
            }
        }

        public class ColumnCssTests
        {
            private ContentCollection _contentCollection;

            public ColumnCssTests()
            {
                _contentCollection = new ContentCollection();
            }

            [Fact]
            public void ColumnCss_should_returns_wide_css_class_when_large_column_is_setto_left_and_requested_for_left_column()
            {
                _contentCollection.LargeColumnSide = "left";
                _contentCollection.ColumnCss("left").ShouldBe("grid-col-8-12");
            }

            [Fact]
            public void ColumnCss_should_returns_narrow_css_class_when_large_column_is_setto_left_and_requested_for_right_column()
            {
                _contentCollection.LargeColumnSide = "left";
                _contentCollection.ColumnCss("right").ShouldBe("grid-col-4-12");
            }
            [Fact]
            public void ColumnCss_should_returns_wide_css_class_when_large_column_is_setto_right_and_requested_for_right_column()
            {
                _contentCollection.LargeColumnSide = "left";
                _contentCollection.ColumnCss("left").ShouldBe("grid-col-8-12");
            }

            [Fact]
            public void ColumnCss_should_returns_narrow_css_class_when_large_column_is_setto_right_and_requested_for_left_column()
            {
                _contentCollection.LargeColumnSide = "left";
                _contentCollection.ColumnCss("right").ShouldBe("grid-col-4-12");
            }
        }

        public class SmallArticleTextCss
        {
            private SmallArticle _smallArticle;

            public SmallArticleTextCss()
            {
                _smallArticle = new SmallArticle();
            }
            [Fact]
            public void SmallArticleTextCss_should_retuns_dark_text_css_when_colour_scheme_is_dark()
            {
                _smallArticle.ColourScheme = "dark";
                _smallArticle.SmallArticleTextCss().ShouldBe("text-dark");
            }

            [Fact]
            public void SmallArticleTextCss_should_retuns_light_text_css_when_colour_scheme_is_light()
            {
                _smallArticle.ColourScheme = "light";
                _smallArticle.SmallArticleTextCss().ShouldBe("text-light");
            }
        }

        public class LargeArticleTextCss
        {
            private LargeArticle _largeArticle;
            
            public LargeArticleTextCss()
            {
                _largeArticle = new LargeArticle();
            }
            [Fact]
            public void LargeArticleTextCss_should_retuns_dark_text_css_when_colour_scheme_is_dark()
            {
                _largeArticle.ColourScheme = "dark";
                _largeArticle.LargeArticleTextCss().ShouldBe("text-dark");
            }

            [Fact]
            public void LargeArticleTextCss_should_retuns_light_text_css_when_colour_scheme_is_light()
            {
                _largeArticle.ColourScheme = "light";
                _largeArticle.LargeArticleTextCss().ShouldBe("text-light");
            }
        }

        public class LargeArticleButtonCss
        {
            private LargeArticle _largeArticle;

            public LargeArticleButtonCss()
            {
                _largeArticle = new LargeArticle();
            }
            
            [Fact]
            public void LargeArticleButtonCss_should_returns_dark_button_css_when_colour_scheme_is_dark()
            {
                _largeArticle.ColourScheme = "dark";
                _largeArticle.LargeArticleButtonCss().ShouldBe("box-button box-button--rounded");
            }
            [Fact]
            public void LargeArticleButtonCss_should_returns_light_button_css_when_colour_scheme_is_light()
            {
                _largeArticle.ColourScheme = "light";
                _largeArticle.LargeArticleButtonCss().ShouldBe("box-button box-button--light box-button--rounded");
            }
        }
    }
}
