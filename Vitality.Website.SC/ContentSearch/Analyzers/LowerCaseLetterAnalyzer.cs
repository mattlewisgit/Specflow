namespace Vitality.Website.SC.ContentSearch.Analyzers
{
    using System.IO;

    using Lucene.Net.Analysis;

    public class LowerCaseLetterAnalyzer : KeywordAnalyzer
    {
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            return new LowerCaseFilter(new LetterTokenizer(reader));
        }
    }
}
